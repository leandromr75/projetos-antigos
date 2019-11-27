//funcao automacao original
using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using RDI.Lince;
using System.Xml;
using RDI.NFe2.ORMAP;
using MMCustom;
using System.Linq;
using RDI.NFe2.SchemaXML;
using System.ServiceModel;

namespace RDI.NFe2.Business
{
    public class FuncaoAutomacao
    {
        int tempoEspera
        {
            get { return oParam.tempoEspera; }
        }
        Boolean connectionOk;
        DateTime dataUltimaConexao;
        DateTime dataUltimaConsulta;
        DateTime dataUltimaCriacaoEnvelope;
        Int32 nTentativas;
        bool _enviarErros;
        string _empresa;
        ClientEnvironment _globalManager;
        ArrayList ListaDeNotas;
        ArrayList ListaDePedidosInutilizacao;
        ArrayList ListaDePedidosCartaDeCorrecao;
        ArrayList ListaDePedidosEventoCancelamento;
        ArrayList ListaDePedidosIntegracao;

        public ClientEnvironment manager
        {
            get { return _globalManager; }
            set { _globalManager = value; }
        }

        //evitar v�rias consultas ao banco.
        private Parametro _param;
        public Parametro oParam
        {
            get
            {
                if (_param == null)
                {
                    ParametroQRY col = new ParametroQRY();
                    col.empresa = _empresa;
                    _param = (Parametro)ParametroDAL.Instance.GetInstances(col, manager)[0];
                }
                return _param;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oGlobalManager">dever� receber uma conexao j� aberta e quem o chamou dever� fecha-la</param>
        public FuncaoAutomacao(string empresa, ClientEnvironment oGlobalManager, bool enviarErros)
        {
            _enviarErros = enviarErros;
            _empresa = empresa;
            manager = oGlobalManager;
            if (manager == null || manager.connection == null || manager.connection.State == System.Data.ConnectionState.Closed)
                throw new Exception("A conex�o n�o esta aberta");


            //verificar se o certificado existe
            X509Certificate2 certificadox509;
            if (oParam.usarCertificadoDisco)
                certificadox509 = Certificado.BuscaCaminho(oParam.caminhoCertificado, oParam.senhaCertificado);
            else
                certificadox509 = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

            if (certificadox509 == null || certificadox509.Subject != oParam.certificado)
                throw new Exception("Certificado n�o encontrado");


            connectionOk = ConsultaStatus();
            dataUltimaConexao = DateTime.Now;
            nTentativas = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="filtro"></param>
        private void MontaLista(ref ArrayList lista, String filtro)
        {
            DirectoryInfo dir = null;
            lista = new ArrayList();
            if (!Directory.Exists(oParam.pastaEntrada))
            {
                dir = Directory.CreateDirectory(oParam.pastaEntrada);
            }
            else
            {
                dir = new DirectoryInfo(oParam.pastaEntrada);
            }

            if (dir != null)
            {
                foreach (FileInfo fileName in dir.GetFiles(filtro))
                    lista.Add(fileName.Name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private long GetFileSize(string FileName)
        {
            FileInfo info = new FileInfo(FileName);

            if (!info.Exists)
                return -1;
            else
                return info.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canLog"></param>
        /// <param name="FileName"></param>
        public void DoOnLoop(Boolean canLog, String FileName)
        {
            int delay = 180;

            if (connectionOk)
            {
                DoStep(canLog, FileName);
            }
            else
            {
                if (DateTime.Now.Subtract(dataUltimaConexao).TotalSeconds > delay)
                {
                    dataUltimaConexao = DateTime.Now;
                    connectionOk = ConsultaStatus();

                    if (connectionOk)
                        nTentativas = 0;
                    else
                        nTentativas++;

                    CriaLog(996, "Tentativa " + nTentativas.ToString() + ". A conex�o com a SEFAZ esta indisponivel. Nova consulta em " + delay.ToString() + " segundos.");
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canLog"></param>
        /// <param name="FileName"></param>
        private void DoStep(Boolean canLog, String FileName)
        {
            try
            {
                #region-------------------------------Monta lote------------------------------------//
                MontaLista(ref ListaDeNotas, "NFe??????" + _empresa + "*.xml");//filtrar pela empresa

                if ((((DateTime.Now.Minute * 60 + DateTime.Now.Second) % oParam.tempoParaLote == 0) ||
                       (ListaDeNotas.Count >= oParam.qtdeNotasPorLotes)) && (ListaDeNotas.Count != 0))
                {
                    if (ListaDeNotas.Count > oParam.qtdeNotasPorLotes)
                        CriaEnvelope(oParam.qtdeNotasPorLotes);
                    else
                        CriaEnvelope(ListaDeNotas.Count);

                }
                #endregion-------------------------------Monta lote------------------------------------//

                #region -------------------------------Inutiliza notas------------------------------------//
                MontaLista(ref ListaDePedidosInutilizacao, "pedInutNFe??????" + _empresa + "*.xml");//filtrar pela empresa

                if (ListaDePedidosInutilizacao.Count > 0)
                {
                    foreach (String origem in ListaDePedidosInutilizacao)
                    {
                        try
                        {

                            try
                            {
                                MMCustom.MMUtils.ConfirmaRecebimentoPedidoInutilizacaoNFe(origem);
                            }
                            catch { }

                            ITInutNFe oInut = (ITInutNFe)Servicos.CarregaXML_HD(oParam.pastaEntrada + origem, oParam.versao, "TInutNFe");

                            String cStat = String.Empty;
                            String xMotivo = String.Empty;
                            String nProt = String.Empty;

                            InutilizaNumeracao(oInut, ref cStat, ref xMotivo, oParam.versao);

                            if (cStat == String.Empty && xMotivo == String.Empty) //recebeu resposta da sefaz
                                throw new Exception("N�o foi poss�vel executar Inutiliza��o. Consulte o LOG do sistema.");

                            if (cStat == "102")
                            {
                                //atualizar registro

                                ITRetInutNFe oRetInut = (ITRetInutNFe)
                                    Servicos.CarregaXML_HD(oParam.pastaRecibo + oInut.infInut.Id + "-inu.xml", oParam.versao, "TRetInutNFe");

                                oInut = (ITInutNFe)Servicos.CarregaXML_HD(oParam.pastaRecibo + oInut.infInut.Id + "-ped-inu.xml", oParam.versao, "TInutNFe");

                                nProt = oRetInut.infInut.nProt;

                                Int32 notaInicial = Int32.Parse(oInut.infInut.nNFIni);
                                Int32 notaFinal = Int32.Parse(oInut.infInut.nNFFin);

                                while (notaInicial <= notaFinal)
                                {
                                    NotaInutilizada oNota = new NotaInutilizada();
                                    oNota.numeroNota = notaInicial.ToString();

                                    //setar a serie da nota
                                    oNota.serieNota = oInut.infInut.serie;
                                    oNota.data = DateTime.Today;
                                    oNota.empresa = oParam.empresa;

                                    oNota.XMLResposta = Servicos.GetXML(oRetInut);
                                    oNota.XMLPedido = Servicos.GetXML(oInut);

                                    oNota.Save(manager);

                                    notaInicial++;
                                }
                            }

                            try
                            {
                                MMCustom.MMUtils.ProcessaResultadoPedidoInutilizacaoNFe(origem, cStat, xMotivo, nProt);
                            }
                            catch { }

                        }
                        catch (Exception exInutilizacao)
                        {
                            try
                            {
                                MMCustom.MMUtils.ErroProcessandoPedidoInutilizacaoNFe(origem, exInutilizacao);
                            }
                            catch { }
                        }
                        finally
                        {
                            //apagar o arquivo
                            if (File.Exists(oParam.pastaEntrada + origem))
                            {
                                File.Delete(oParam.pastaEntrada + origem);
                            }
                        }
                    }
                }
                #endregion-------------------------------Inutiliza notas------------------------------------//

                #region --------------------------envia carta de corre��o--------------------------

                MontaLista(ref ListaDePedidosCartaDeCorrecao, "CCe_??????" + _empresa + "*.xml"); //arquivo do tipo Evento Carta de corre��o
                if (ListaDePedidosCartaDeCorrecao.Count > 0)
                {
                    foreach (String origem in ListaDePedidosCartaDeCorrecao)
                    {
                        string xmlEvento = string.Empty;
                        string xmlRetorno = string.Empty;
                        TipoSituacaoEvento situacao = TipoSituacaoEvento.NaoExecutadoErro;
                        int numeroNovoLote = 0;
                        ITEvento oEvento = null;
                        NotaFiscal oNotaFiscal = null;
                        NotaFiscalQry oNotaFiscalQry = null;
                        string nomeArquivoAssinado = string.Empty;


                        try
                        {

                            try
                            {
                                MMCustom.MMUtils.ConfirmaRecebimentoPedidoCartaCorrecao(origem);
                            }
                            catch { }

                            #region Pegar o ultimo lote criado.
                            EventoQry oTbEventoQry = new EventoQry();
                            oTbEventoQry.empresa = oParam.empresa;
                            numeroNovoLote = EventoDAL.Instance.GetMax(oTbEventoQry, manager);
                            #endregion

                            oNotaFiscalQry = new NotaFiscalQry();

                            #region verificar se � possivel ler o arquivo e apagar arquivo de origem
                            try
                            {
                                using (StreamReader SR = File.OpenText(oParam.pastaEntrada + origem))
                                {
                                    xmlEvento = SR.ReadToEnd();
                                    SR.Close();
                                }
                                GC.Collect();

                                //apaga arquivo sem assinatura : origem
                                if (File.Exists(oParam.pastaEntrada + origem))
                                    File.Delete(oParam.pastaEntrada + origem);
                            }
                            catch (Exception ex)
                            {
                                situacao = TipoSituacaoEvento.NaoExecutadoErro;
                                throw new Exception("N�o foi poss�vel abrir o arquivo : " + oParam.pastaEntrada + origem + " > " + ex.Message);
                            }
                            #endregion

                            #region verificar serializacao antes de assinar jogar na classe de NFe
                            try
                            {
                                oEvento = (ITEvento)Servicos.CarregaXML_STR(xmlEvento, oParam.versao, "TEvento");

                                oNotaFiscalQry.empresa = oParam.empresa;// oEvento.infEvento.Item;
                                oNotaFiscalQry.chaveNota = "NFe" + oEvento.infEvento.chNFe;
                                nomeArquivoAssinado = oParam.pastaRecibo + oEvento.infEvento.Id + "-ev.xml";

                                Servicos.SalvaXML(nomeArquivoAssinado, oEvento);
                                oEvento = null;
                            }
                            catch (Exception ex)
                            {
                                situacao = TipoSituacaoEvento.ErroDesearilizacao;
                                throw new Exception("N�o foi possivel Deserializar a nota no Objeto TEvento. - " + ex.Message);
                            }
                            #endregion

                            ArrayList notas = NotaFiscalDAL.Instance.GetInstances(oNotaFiscalQry, manager);
                            if (notas.Count == 0)
                                throw new Exception("Nota fiscal n�o localizada.");

                            bool tentativaLocalizada = false;
                            for (int i = 0; i < notas.Count; i++)
                            {
                                oNotaFiscal = (NotaFiscal)notas[i];
                                if (oNotaFiscal.codigoSituacao == TipoSituacaoNota.Aprovada || oNotaFiscal.codigoSituacao == TipoSituacaoNota.Impressa)//nota aprovada
                                {
                                    tentativaLocalizada = true;
                                    break;
                                }
                            }
                            if (!tentativaLocalizada)
                                throw new Exception("NFe localizada, mas n�o esta aprovada.");

                            //assinar evento.
                            X509Certificate2 cert;
                            if (oParam.usarCertificadoDisco)
                                cert = Certificado.BuscaCaminho(oParam.caminhoCertificado, oParam.senhaCertificado);
                            else
                                cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

                            var CodigoDoResultado = NFeUtils.AssinaXML(nomeArquivoAssinado, "infEvento", cert, oParam.versao);
                            cert = null;

                            //apaga arquivo sem assinatura : -ev.xml
                            if (File.Exists(nomeArquivoAssinado))
                                File.Delete(nomeArquivoAssinado);
                            nomeArquivoAssinado = nomeArquivoAssinado.Substring(0, nomeArquivoAssinado.Length - 7) + "-ass-env.xml";

                            //avaliar retorno da assinatura
                            if (CodigoDoResultado != TipoSituacaoNota.Assinada)
                            {
                                throw new Exception("N�o foi poss�vel assinar o arquivo : ERRO" + CodigoDoResultado.ToString());
                            }

                            //arquivo esta assinado
                            //carregar o xml assinado
                            oEvento = (ITEvento)Servicos.CarregaXML_HD(nomeArquivoAssinado, oParam.versao, "TEvento");
                            xmlEvento = Servicos.GetXML(oEvento);

                            RecepcaoEvento(oEvento, numeroNovoLote, ref xmlRetorno, oParam.versao);

                            if (string.IsNullOrEmpty(xmlRetorno)) //recebeu resposta da sefaz
                                throw new Exception("N�o foi poss�vel executar RecepcaoEvento-CCe. Consulte o LOG do sistema.");

                            ITRetEnvEvento oRetEnvEvento = (ITRetEnvEvento)Servicos.CarregaXML_STR(xmlRetorno, oParam.versao, "TRetEnvEvento");

                            if (oRetEnvEvento.cStat == "128")
                            {

                                //Recebido pelo Sistema de Registro de Eventos, com vincula��o do 
                                //    evento na NF-e, o Evento ser� armazenado no reposit�rio do Sistema de Registro de Eventos 
                                //    com a vincula��o do Evento � respectiva NF-e (cStat=135);

                                //Recebido pelo Sistema de Registro de Eventos � vincula��o do 
                                //    evento � respectiva NF-e prejudicada � o Evento ser� armazenado no reposit�rio do Sistema 
                                //    de Registro de Eventos, a vincula��o do evento � respectiva NF-e fica prejudicada face a 
                                //    inexist�ncia da NF-e no momento do recebimento do Evento (cStat=136);

                                if (oRetEnvEvento.retEvento != null &&
                                    oRetEnvEvento.retEvento[0] != null &&
                                    oRetEnvEvento.retEvento[0].infEvento != null &&
                                    (oRetEnvEvento.retEvento[0].infEvento.cStat == "135" || oRetEnvEvento.retEvento[0].infEvento.cStat == "136"))
                                {
                                    if (oRetEnvEvento.retEvento[0].infEvento.cStat == "135")
                                        situacao = TipoSituacaoEvento.FinalizadoAprovado135;
                                    else
                                        situacao = TipoSituacaoEvento.FinalizadoAprovado136;

                                    //gerar o arquivo de processo

                                    //gerar evento
                                    var oProcEvento = (ITProcEvento)Servicos.XMLFactory(oParam.versao, "TProcEvento");
                                    oProcEvento.evento = oEvento;
                                    oProcEvento.retEvento = oRetEnvEvento.retEvento[0];
                                    oProcEvento.versao = "1.00";
                                    //salvar arquivo na caixa de saida

                                    Servicos.SalvaXML(oParam.pastaSaida + oEvento.infEvento.Id + "_v1.00-procCCe.xml", oProcEvento);
                                }
                                else
                                {
                                    situacao = TipoSituacaoEvento.FinalizadoComRejeicaoRegras;
                                }
                            }
                            else
                            {
                                situacao = TipoSituacaoEvento.FinalizadoComRejeicaoLote;
                            }

                            try
                            {
                                MMCustom.MMUtils.ProcessaResultadoPedidoCartaCorrecao(origem, oRetEnvEvento.cStat, oRetEnvEvento.xMotivo);
                            }
                            catch { }

                        }
                        catch (Exception exCartaCorrecao)
                        {
                            try
                            {
                                MMCustom.MMUtils.ErroProcessandoPedidoCartaCorrecao(origem, exCartaCorrecao);
                            }
                            catch { }

                            CriaLog((sbyte)situacao, "Processamento Carta de Corre��o", exCartaCorrecao);
                        }

                        //registrar o evento no banco
                        try
                        {
                            //apagar o arquivo
                            if (File.Exists(oParam.pastaEntrada + origem))
                            {
                                File.Delete(oParam.pastaEntrada + origem);
                            }

                            if (numeroNovoLote != 0 && oNotaFiscal != null)
                            {
                                //registrar 
                                //criar registro do TEvento
                                Evento oTbEvento = new Evento();
                                oTbEvento.XMLPedido = xmlEvento;
                                oTbEvento.XMLResposta = xmlRetorno;
                                oTbEvento.codigoSituacao = situacao;
                                oTbEvento.tpEvento = TEventoInfEventoTpEvento.CartaCorrecao;

                                oTbEvento.id = numeroNovoLote;
                                oTbEvento.empresa = oNotaFiscal.empresa;
                                oTbEvento.chaveNota = oNotaFiscal.chaveNota;
                                oTbEvento.numeroLote = oNotaFiscal.numeroLote;
                                oTbEvento.Save(manager);

                                //gerar arquivo para danfe.exe
                                if (oEvento != null && oNotaFiscal != null)
                                {
                                    #region imprimir evento
                                    if (oTbEvento.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado135 ||
                                        oTbEvento.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado136)
                                    {

                                        //tratar envio de xml para destinat�rio.
                                        string sufixo = "_v1.00-procCCe.xml";
                                        String nomeArquivo = oEvento.infEvento.Id + sufixo;

                                        ITNFe oNFeXML = (ITNFe)Servicos.CarregaXML_STR(oNotaFiscal.xmlNota, oParam.versao, "TNFe");

                                        //salvar TXT com dados complementares
                                        if (File.Exists(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                                            File.Delete(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt"));

                                        //gerar arquivo TXT com o email do destinat�rio
                                        using (StreamWriter oSW = File.CreateText(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                                        {
                                            //dados destinatarios
                                            oSW.WriteLine(oNFeXML.infNFe.dest.xNome);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xLgr + ", " + oNFeXML.infNFe.dest.enderDest.nro);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xBairro);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.CEP);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xMun);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.fone);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.UF);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.IE);

                                            //dados emitente
                                            oSW.WriteLine(oNFeXML.infNFe.emit.xNome);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xLgr + ", " + oNFeXML.infNFe.emit.enderEmit.nro);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xBairro);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.CEP);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xMun);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.fone);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.UF);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.IE);

                                            oSW.WriteLine(oNFeXML.infNFe.ide.nNF);
                                            oSW.WriteLine(oNFeXML.infNFe.ide.serie);
                                            oSW.WriteLine(oNFeXML.infNFe.ide.dEmi);

                                            oSW.Close();
                                        }
                                        GC.Collect();

                                        oNFeXML = null;

                                        NFeUtils.GeraArquivoProcEventoNFe(oTbEvento, oParam.pastaImpressao + nomeArquivo, oNotaFiscal.versao);
                                    }
                                    #endregion
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            CriaLog(999, "Falha ao registrar evento Carta de Corre��o", ex);
                        }
                    }
                }

                #endregion ------------------------------------------------------------------------

                #region --------------------------envia evento cancelamento--------------------------

                MontaLista(ref ListaDePedidosEventoCancelamento, "evtCanc_??????" + _empresa + "*.xml"); //arquivo do tipo Evento Cancelamento
                if (ListaDePedidosEventoCancelamento.Count > 0)
                {
                    foreach (String origem in ListaDePedidosEventoCancelamento)
                    {
                        string xmlEvento = string.Empty;
                        string xmlRetorno = string.Empty;
                        TipoSituacaoEvento situacao = TipoSituacaoEvento.NaoExecutadoErro;
                        int numeroNovoLote = 0;
                        ITEvento oEvento = null;
                        NotaFiscal oNotaFiscal = null;
                        NotaFiscalQry oNotaFiscalQry = null;
                        string nomeArquivoAssinado = string.Empty;


                        try
                        {

                            try
                            {
                                MMCustom.MMUtils.ConfirmaRecebimentoPedidoEventoCancelamento(origem);
                            }
                            catch { }

                            #region Pegar o ultimo lote criado.
                            EventoQry oTbEventoQry = new EventoQry();
                            oTbEventoQry.empresa = oParam.empresa;
                            numeroNovoLote = EventoDAL.Instance.GetMax(oTbEventoQry, manager);
                            #endregion

                            oNotaFiscalQry = new NotaFiscalQry();

                            #region verificar se � possivel ler o arquivo e apagar arquivo de origem
                            try
                            {
                                using (StreamReader SR = File.OpenText(oParam.pastaEntrada + origem))
                                {
                                    xmlEvento = SR.ReadToEnd();
                                    SR.Close();
                                }
                                GC.Collect();

                                //apaga arquivo sem assinatura : origem
                                if (File.Exists(oParam.pastaEntrada + origem))
                                    File.Delete(oParam.pastaEntrada + origem);
                            }
                            catch (Exception ex)
                            {
                                situacao = TipoSituacaoEvento.NaoExecutadoErro;
                                throw new Exception("N�o foi poss�vel abrir o arquivo : " + oParam.pastaEntrada + origem + " > " + ex.Message);
                            }
                            #endregion

                            #region verificar serializacao antes de assinar jogar na classe de NFe
                            try
                            {
                                oEvento = (ITEvento)Servicos.CarregaXML_STR(xmlEvento, oParam.versao, "TEvento");

                                oNotaFiscalQry.empresa = oParam.empresa;
                                oNotaFiscalQry.chaveNota = "NFe" + oEvento.infEvento.chNFe;
                                nomeArquivoAssinado = oParam.pastaRecibo + oEvento.infEvento.Id + "-ev.xml";

                                Servicos.SalvaXML(nomeArquivoAssinado, oEvento);
                                oEvento = null;
                            }
                            catch (Exception ex)
                            {
                                situacao = TipoSituacaoEvento.ErroDesearilizacao;
                                throw new Exception("N�o foi possivel Deserializar a nota no Objeto TEvento. - " + ex.Message);
                            }
                            #endregion

                            ArrayList notas = NotaFiscalDAL.Instance.GetInstances(oNotaFiscalQry, manager);
                            if (notas.Count == 0)
                                throw new Exception("Nota fiscal n�o localizada.");

                            bool tentativaLocalizada = false;
                            for (int i = 0; i < notas.Count; i++)
                            {
                                oNotaFiscal = (NotaFiscal)notas[i];
                                if (oNotaFiscal.codigoSituacao == TipoSituacaoNota.Aprovada || oNotaFiscal.codigoSituacao == TipoSituacaoNota.Impressa)//nota aprovada
                                {
                                    tentativaLocalizada = true;
                                    break;
                                }
                            }
                            if (!tentativaLocalizada)
                                throw new Exception("NFe localizada, mas n�o esta aprovada.");


                            //assinar evento.
                            X509Certificate2 cert;
                            if (oParam.usarCertificadoDisco)
                                cert = Certificado.BuscaCaminho(oParam.caminhoCertificado, oParam.senhaCertificado);
                            else
                                cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

                            var CodigoDoResultado = NFeUtils.AssinaXML(nomeArquivoAssinado, "infEvento", cert, oParam.versao);
                            cert = null;

                            //apaga arquivo sem assinatura : -ev.xml
                            if (File.Exists(nomeArquivoAssinado))
                                File.Delete(nomeArquivoAssinado);
                            nomeArquivoAssinado = nomeArquivoAssinado.Substring(0, nomeArquivoAssinado.Length - 7) + "-ass-env.xml";

                            //avaliar retorno da assinatura
                            if (CodigoDoResultado != TipoSituacaoNota.Assinada)
                            {
                                throw new Exception("N�o foi poss�vel assinar o arquivo : ERRO" + CodigoDoResultado.ToString());
                            }

                            //arquivo esta assinado
                            //carregar o xml assinado
                            oEvento = (ITEvento)Servicos.CarregaXML_HD(nomeArquivoAssinado, oParam.versao, "TEvento");
                            xmlEvento = Servicos.GetXML(oEvento);

                            RecepcaoEvento(oEvento, numeroNovoLote, ref xmlRetorno, oParam.versao);

                            if (string.IsNullOrEmpty(xmlRetorno)) //recebeu resposta da sefaz
                                throw new Exception("N�o foi poss�vel executar RecepcaoEvento-Cancelamento. Consulte o LOG do sistema.");

                            ITRetEnvEvento oRetEnvEvento = (ITRetEnvEvento)Servicos.CarregaXML_STR(xmlRetorno, oParam.versao, "TRetEnvEvento");

                            if (oRetEnvEvento.cStat == "128")
                            {

                                //Recebido pelo Sistema de Registro de Eventos, com vincula��o do 
                                //    evento na NF-e, o Evento ser� armazenado no reposit�rio do Sistema de Registro de Eventos 
                                //    com a vincula��o do Evento � respectiva NF-e (cStat=135);

                                //Recebido pelo Sistema de Registro de Eventos � vincula��o do 
                                //    evento � respectiva NF-e prejudicada � o Evento ser� armazenado no reposit�rio do Sistema 
                                //    de Registro de Eventos, a vincula��o do evento � respectiva NF-e fica prejudicada face a 
                                //    inexist�ncia da NF-e no momento do recebimento do Evento (cStat=136);

                                if (oRetEnvEvento.retEvento != null &&
                                    oRetEnvEvento.retEvento[0] != null &&
                                    oRetEnvEvento.retEvento[0].infEvento != null &&
                                    (oRetEnvEvento.retEvento[0].infEvento.cStat == "135"
                                    || oRetEnvEvento.retEvento[0].infEvento.cStat == "136"
                                    || oRetEnvEvento.retEvento[0].infEvento.cStat == "155"))
                                {
                                    if (oRetEnvEvento.retEvento[0].infEvento.cStat == "135")
                                        situacao = TipoSituacaoEvento.FinalizadoAprovado135;
                                    else if (oRetEnvEvento.retEvento[0].infEvento.cStat == "136")
                                        situacao = TipoSituacaoEvento.FinalizadoAprovado136;
                                    else if (oRetEnvEvento.retEvento[0].infEvento.cStat == "155")
                                        situacao = TipoSituacaoEvento.FinalizadoAprovado155;


                                    //atualizar registro NFe
                                    oNotaFiscal.codigoSituacao = TipoSituacaoNota.Cancelada;// 16;
                                    oNotaFiscal.descricaoSituacao = "Nota Cancelada";
                                    //TODO : REVER
                                    oNotaFiscal.cStat = "101";
                                    //TODO : REVER
                                    oNotaFiscal.xMotivo = "CANCELAMENTO NFE HOMOLOGADO";
                                    oNotaFiscal.nProtCancelamento = oRetEnvEvento.retEvento[0].infEvento.nProt;

                                    oNotaFiscal.Save(manager);

                                    //gerar evento
                                    var oProcEvento = (ITProcEvento)Servicos.XMLFactory(oParam.versao, "TProcEvento");
                                    oProcEvento.evento = oEvento;
                                    oProcEvento.retEvento = oRetEnvEvento.retEvento[0];
                                    oProcEvento.versao = "1.00";
                                    //salvar arquivo na caixa de saida

                                    Servicos.SalvaXML(oParam.pastaSaida + oEvento.infEvento.Id + "_v1.00-procEventoCancNFe.xml", oProcEvento);

                                }
                                else
                                {
                                    situacao = TipoSituacaoEvento.FinalizadoComRejeicaoRegras;
                                }
                            }
                            else
                            {
                                situacao = TipoSituacaoEvento.FinalizadoComRejeicaoLote;
                            }

                            try
                            {
                                MMCustom.MMUtils.ProcessaResultadoPedidoEventoCancelamento(origem, oRetEnvEvento.cStat, oRetEnvEvento.xMotivo);
                            }
                            catch { }

                        }
                        catch (Exception exEventoCancelamento)
                        {
                            try
                            {
                                MMCustom.MMUtils.ErroProcessandoPedidoEventoCancelamento(origem, exEventoCancelamento);
                            }
                            catch { }

                            CriaLog((sbyte)situacao, "Processamento Cancelamento", exEventoCancelamento);
                        }

                        //registrar o evento no banco
                        try
                        {
                            //apagar o arquivo
                            if (File.Exists(oParam.pastaEntrada + origem))
                            {
                                File.Delete(oParam.pastaEntrada + origem);
                            }

                            if (numeroNovoLote != 0 && oNotaFiscal != null)
                            {
                                //registrar 
                                //criar registro do TEvento
                                Evento oTbEvento = new Evento();
                                oTbEvento.XMLPedido = xmlEvento;
                                oTbEvento.XMLResposta = xmlRetorno;
                                oTbEvento.codigoSituacao = situacao;
                                oTbEvento.tpEvento = TEventoInfEventoTpEvento.Cancelamento;

                                oTbEvento.id = numeroNovoLote;
                                oTbEvento.empresa = oNotaFiscal.empresa;
                                oTbEvento.chaveNota = oNotaFiscal.chaveNota;
                                oTbEvento.numeroLote = oNotaFiscal.numeroLote;
                                oTbEvento.Save(manager);

                                //gerar arquivo para danfe.exe
                                if (oEvento != null && oNotaFiscal != null)
                                {
                                    #region imprimir evento
                                    if (oTbEvento.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado135 ||
                                        oTbEvento.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado136 ||
                                        oTbEvento.codigoSituacao == TipoSituacaoEvento.FinalizadoAprovado155)
                                    {
                                        //tratar envio de xml para destinat�rio.
                                        string sufixo = "_v1.00-procEventoCancNFe.xml";
                                        String nomeArquivo = oEvento.infEvento.Id + sufixo;

                                        ITNFe oNFeXML = (ITNFe)
                                            Servicos.CarregaXML_STR(oNotaFiscal.xmlNota, oNotaFiscal.versao, "TNFe");

                                        //salvar TXT com dados complementares
                                        if (File.Exists(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                                            File.Delete(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt"));

                                        //gerar arquivo TXT com o email do destinat�rio
                                        using (StreamWriter oSW = File.CreateText(oParam.pastaImpressao + nomeArquivo.Replace(".xml", ".txt")))
                                        {
                                            //dados destinatarios
                                            oSW.WriteLine(oNFeXML.infNFe.dest.xNome);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xLgr + ", " + oNFeXML.infNFe.dest.enderDest.nro);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xBairro);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.CEP);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.xMun);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.fone);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.enderDest.UF);
                                            oSW.WriteLine(oNFeXML.infNFe.dest.IE);

                                            //dados emitente
                                            oSW.WriteLine(oNFeXML.infNFe.emit.xNome);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xLgr + ", " + oNFeXML.infNFe.emit.enderEmit.nro);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xBairro);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.CEP);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.xMun);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.fone);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.enderEmit.UF);
                                            oSW.WriteLine(oNFeXML.infNFe.emit.IE);

                                            oSW.WriteLine(oNFeXML.infNFe.ide.nNF);
                                            oSW.WriteLine(oNFeXML.infNFe.ide.serie);

                                            oSW.Close();
                                        }
                                        GC.Collect();

                                        oNFeXML = null;

                                        NFeUtils.GeraArquivoProcEventoNFe(oTbEvento, oParam.pastaImpressao + nomeArquivo, oNotaFiscal.versao);
                                    }
                                    #endregion
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            CriaLog(999, "Falha ao registrar evento Cancelamento", ex);
                        }
                    }

                }

                #endregion ------------------------------------------------------------------------

                if (DateTime.Now.Subtract(dataUltimaConsulta).TotalSeconds > tempoEspera || dataUltimaCriacaoEnvelope > dataUltimaConsulta)
                {
                    dataUltimaConsulta = DateTime.Now;

                    #region Fun��es que consultam tabela de servicos

                    #region-------------------------------Envia lote------------------------------------//
                    //if ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % 12 == 0)
                    {
                        //buscar os servicos pendentes
                        ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                        oSrvQry.codigoSituacao = ((sbyte)TipoSituacaoServico.Assinado).ToString();
                        oSrvQry.empresa = oParam.empresa;

                        ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(oSrvQry, manager);
                        foreach (ServicoPendente oServicoPendente in servicos)
                        {
                            EnviaEnvelope(oServicoPendente);
                        }

                    }//if envio de lotes
                    #endregion-------------------------------Envia lote------------------------------------//

                    #region-----------------------------ConsultaEnvelopes-------------------------------//
                    //if ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % 13 == 0)
                    {
                        //buscar os servicos pendentes
                        ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                        oSrvQry.codigoSituacao = ((sbyte)TipoSituacaoServico.Enviado).ToString();
                        oSrvQry.empresa = oParam.empresa;

                        ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(oSrvQry, manager);
                        foreach (ServicoPendente oServicoPendente in servicos)
                        {
                            if (DateTime.Now.Subtract(oServicoPendente.dataSituacao).TotalSeconds > 15) //aguardar pelo menos 15 segundos
                            {
                                ConsultaEnvelope(oServicoPendente);
                            }
                        }

                    }//if consulta envelope
                    #endregion----------------------------ConsultaEnvelopes--------------------------------//

                    #region-------------------------------ImprimeDANFe----------------------------------//
                    //if ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % 15 == 0)
                    {
                        ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                        oSrvQry.codigoSituacao = ((sbyte)TipoSituacaoServico.Processado).ToString();
                        oSrvQry.empresa = oParam.empresa;

                        ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(oSrvQry, manager);
                        foreach (ServicoPendente oServicoPendente in servicos)
                        {
                            FinalizaServicos(oServicoPendente);
                        }


                    }//if imprime nota
                    #endregion-------------------------------ImprimeDANFe----------------------------------//

                    #region-------------------------------ReimpressaoDANFe----------------------------------//
                    MontaLista(ref ListaDePedidosIntegracao, "integracao*.xml"); //arquivo do tipo Integracao
                    if (ListaDePedidosIntegracao.Count > 0)
                    {
                        foreach (String origem in ListaDePedidosIntegracao)
                        {
                            string xmlIntegracao = string.Empty;

                            SchemaXML.TIntegracao oIntegracao;

                            NotaFiscal oNotaFiscal = null;
                            NotaFiscalQry oNotaFiscalQry = null;

                            try
                            {
                                oNotaFiscalQry = new NotaFiscalQry();

                                #region verificar se � possivel ler o arquivo e apagar arquivo de origem
                                try
                                {
                                    using (StreamReader SR = File.OpenText(oParam.pastaEntrada + origem))
                                    {
                                        xmlIntegracao = SR.ReadToEnd();
                                        SR.Close();
                                    }
                                    GC.Collect();

                                    //apaga arquivo sem assinatura : origem
                                    if (File.Exists(oParam.pastaEntrada + origem))
                                        File.Delete(oParam.pastaEntrada + origem);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("N�o foi poss�vel abrir o arquivo : " + oParam.pastaEntrada + origem + " > " + ex.Message);
                                }
                                #endregion

                                #region verificar serializacao
                                try
                                {
                                    oIntegracao = (SchemaXML.TIntegracao)Servicos.CarregaXML_STR(xmlIntegracao, VersaoNFe.Integracao, "TIntegracao");

                                    oNotaFiscalQry.empresa = oParam.empresa;
                                    oNotaFiscalQry.chaveNota = "NFe" + ((SchemaXML.TImpressao)oIntegracao.item).chNFe;

                                    oIntegracao = null;
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("N�o foi possivel Deserializar a nota no Objeto TEvento. - " + ex.Message);
                                }
                                #endregion

                                ArrayList notas = NotaFiscalDAL.Instance.GetInstances(oNotaFiscalQry, manager);
                                if (notas.Count == 0)
                                    throw new Exception("Nota fiscal n�o localizada.");

                                oNotaFiscal = (NotaFiscal)notas[0];

                                if (oNotaFiscal.codigoSituacao != TipoSituacaoNota.Aprovada// 13
                                    && oNotaFiscal.codigoSituacao != TipoSituacaoNota.Impressa// 15
                                    )//nota nao aprovada
                                    throw new Exception("NFe localizada, mas n�o esta aprovada.");

                                NFeUtils.ImprimeDANFe(oNotaFiscal, oParam, manager);
                                CriaLog(4, "Arquivo enviado para Pasta de Impress�o com sucesso!", oNotaFiscal.chaveNota);

                            }
                            catch (Exception exIntegracao)
                            {
                                CriaLog(995, "Processamento de Integra��o", exIntegracao);
                            }
                            finally
                            {
                                //apagar o arquivo
                                if (File.Exists(oParam.pastaEntrada + origem))
                                {
                                    File.Delete(oParam.pastaEntrada + origem);
                                }
                            }
                        }

                    }
                    #endregion------------------------------ReimpressaoDANFe---------------------------------//

                    #endregion
                }

            }
            catch (Exception ex)
            {
                CriaLog(999, "Fun��o automa��o (Geral)", ex);
            }
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="mensagem"></param>
        /// <param name="chave"></param>
        public void CriaLog(int codigo, string mensagem, string chaveNFe = "")
        {
            try
            {
                Log oLog = new Log();

                oLog.codigoSituacao = codigo;
                //depois de alterado o tamanho no banco.
                //ser� varchar max
                //if (situacao.Length < 255)
                oLog.descricaoSituacao = mensagem;
                //else
                //    oLog.descricaoSituacao = situacao.Substring(0, 255);

                oLog.nota = new NotaFiscal();
                oLog.nota.chaveNota = chaveNFe;
                oLog.data = DateTime.Now;
                oLog.empresa = oParam.empresa;
                oLog.Save(manager);
            }
            catch
            {
            }
        }

        public void CriaLog(int codigo, string origem, Exception ex, string chaveNFe = "")
        {
            string situacao = ex.Message;
            if (ex.InnerException != null)
            {
                situacao += " InnerException: " + ex.InnerException.Message;
            }


            if (_enviarErros)
            {
                try
                {
                    //TODO : inicializar uma thread que ir� fazer o envio do erro para nossa base de dados
                    System.Threading.ParameterizedThreadStart opThEnviarErro = new System.Threading.ParameterizedThreadStart(ReportarErro);
                    var thEnviarErro = new System.Threading.Thread(opThEnviarErro);
                    var err = new Erro();
                    err.codigo = codigo;
                    err.Excecao = ex;
                    err.Origem = origem;
                    err.chaveNFe = chaveNFe;

                    thEnviarErro.Start(err);

                }
                catch
                {

                }
            }

            CriaLog(codigo, origem + " : " + situacao, chaveNFe);
        }

        private void ReportarErro(object param)
        {
            try
            {
                //ir� fazer o envio do erro para nossa base de dados
                var err = (Erro)param;
                BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                String baseAddress = "http://nfeserverrdi.cloudapp.net/nfeservice.svc";
                EndpointAddress remoteAddress = new EndpointAddress(baseAddress);
                using (var proxy = new RDI.NFe2.Business.SOA.InfeserviceClient(basicHttpBinding, remoteAddress))
                {
                    var msg = "C: " + err.codigo;
                    msg += " O: " + err.Origem;

                    if (err.Excecao != null)
                    {
                        msg += " E1: " + err.Excecao.Message;

                        if (err.Excecao.InnerException != null)
                        {
                            msg += " E2: " + err.Excecao.InnerException.Message;
                        }
                    }

                    if (!String.IsNullOrEmpty(err.chaveNFe))
                        msg += " N: " + err.chaveNFe;

                    proxy.ReportError(msg);
                }
            }
            catch //(Exception ex)
            {

            }
        }

        class Erro
        {
            public int codigo { get; set; }
            public string Origem { get; set; }
            public Exception Excecao { get; set; }
            public string chaveNFe { get; set; }
        }


        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="NFeStr"></param>
        /// <param name="CodigoDoResultado"></param>
        /// <param name="DescricaoDoResultado"></param>
        private void AssinaNota(string NFeStr, ref TipoSituacaoNota CodigoDoResultado, ref string DescricaoDoResultado)
        {
            string erros;

            try
            {
                X509Certificate2 cert;
                if (oParam.usarCertificadoDisco)
                    cert = Certificado.BuscaCaminho(oParam.caminhoCertificado, oParam.senhaCertificado);
                else
                    cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

                CodigoDoResultado = NFeUtils.AssinaXML(oParam.pastaEntrada + NFeStr, "infNFe", cert, oParam.versao);

                cert = null;

                //so validar nota assinada
                if (CodigoDoResultado == TipoSituacaoNota.Assinada)
                {
                    erros = NFeUtils.ValidacaoXML(oParam.pastaEntrada + "ass" + NFeStr,
                                                  oParam.pastaXSD + "nfe_v" + oParam.versaoDados + ".xsd");

                    if (erros == "NotFound")
                    {
                        CodigoDoResultado = TipoSituacaoNota.ArquivoValidacaoNaoEncontrado;// 10;
                        DescricaoDoResultado = "Arquivo n�o encontrado - Valida��o";
                    }
                    else if (erros != System.String.Empty)      //problema : xml nao validado.
                    {
                        CodigoDoResultado = TipoSituacaoNota.XMLInvalido;// 8;
                        DescricaoDoResultado = erros;
                        //Renomear o arquivo para ERRO+NFE
                        if (File.Exists(oParam.pastaEntrada + "ERRO8_" + NFeStr))
                            File.Delete(oParam.pastaEntrada + "ERRO8_" + NFeStr);
                        File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO8_" + NFeStr);
                        File.Delete(oParam.pastaEntrada + "ass" + NFeStr);
                    }
                    else if (File.Exists(oParam.pastaEntrada + "ass" + NFeStr))//ESTA TUDO OK 
                    {
                        DescricaoDoResultado = "Nota Assinada";

                        File.Delete(oParam.pastaEntrada + NFeStr);
                    }
                }
                else if (CodigoDoResultado == TipoSituacaoNota.ProblemaAoAcessarCertificado)
                {
                    DescricaoDoResultado = "Problema ao acessar certificado";
                    //Avisar para o Usuario Avancado que existe um problema no certiificado
                    if (File.Exists(oParam.pastaEntrada + "ERRO1_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO1_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO1_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.ProblemaNoCertificado)
                {
                    DescricaoDoResultado = "Problemas no certificado";
                    //Avisar para o Usuario Avancado que existe um problema no certiificado
                    if (File.Exists(oParam.pastaEntrada + "ERRO2_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO2_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO2_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.XMLMalFormado)
                {
                    DescricaoDoResultado = "XML mal formado";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO3_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO3_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO3_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.RefURiNaoExiste)
                {
                    DescricaoDoResultado = "A TAG de assinatura � inexistente";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO4_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO4_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO4_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.RefURiNaoUnica)
                {
                    DescricaoDoResultado = "A TAG de assinatura n�o � �nica";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO5_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO5_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO5_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.ErroAoAssinarDocumento)
                {
                    DescricaoDoResultado = "Erro ao assinar o documento";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO6_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO6_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO6_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.ErroAoAssinarDocumento)
                {
                    DescricaoDoResultado = "Erro ao assinar o documento";

                    if (File.Exists(oParam.pastaEntrada + "ERRO7_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO7_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO7_" + NFeStr);
                }
                else if (CodigoDoResultado == TipoSituacaoNota.ArquivoNaoEncontrado)
                {
                    DescricaoDoResultado = "Arquivo n�o encontrado - Assinatura";
                }
            }
            catch (Exception ex)
            {
                CodigoDoResultado = TipoSituacaoNota.ExcecaoGeralAssinatura;// 9;
                DescricaoDoResultado = "Exce��o - " + ex.Message;
                if (File.Exists(oParam.pastaEntrada + "ERRO9_" + NFeStr))
                    File.Delete(oParam.pastaEntrada + "ERRO9_" + NFeStr);
                if (File.Exists(oParam.pastaEntrada + NFeStr))
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO9_" + NFeStr);
            }
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="QtdeNFLote"></param>
        private void CriaEnvelope(int QtdeNFLote)
        {

            try
            {
                int numeroNovoLote, i;
                TipoSituacaoNota CodigoDoResultado = TipoSituacaoNota.SerivcoExcluido;
                string origem, DescricaoDoResultado = "Erro n�o mapeado";

                //inicia lote
                #region Pegar o ultimo lote criado.
                //NotaFiscalQry oNFeQry = new NotaFiscalQry();
                //oNFeQry.empresa = oParam.empresa;
                //numeroNovoLote = NotaFiscalDAL.Instance.GetMax(oNFeQry, manager);

                ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                oSrvQry.empresa = oParam.empresa;
                numeroNovoLote = ServicoPendenteDAL.Instance.GetMax(oSrvQry, manager);

                ITEnviNFe oEnviNFe = (ITEnviNFe)Servicos.XMLFactory(oParam.versao, "TEnviNFe");
                oEnviNFe.idLote = numeroNovoLote.ToString();
                oEnviNFe.versao = oParam.versaoDados;

                //Trabalhar sempre com envelopes assincronos
                if (oParam.versao == VersaoNFe.v310)
                {
                    ((SchemaXML310.TEnviNFe)oEnviNFe).indSinc = SchemaXML310.TEnviNFeIndSinc.Item0;
                }
                else if (oParam.versao == VersaoNFe.v300)
                {
                    ((SchemaXML300.TEnviNFe)oEnviNFe).indSinc = SchemaXML300.TEnviNFeIndSinc.Item0;
                }

                #endregion

                #region assinar, validar e adicionar nota ao lote
                //corre a lista de nfe's disponiveis na pasta de entrada.
                for (i = 0; i < QtdeNFLote; i++)
                {
                    origem = ListaDeNotas[i].ToString();
                    ITNFe oNFe = (ITNFe)Servicos.XMLFactory(oParam.versao, "TNFe");
                    string xmlNotaStr = "";

                    try
                    {
                        //todo
                        //if (origem.Length > 51)
                        //{
                        //    File.Move(origem, "tam_" + origem);
                        //}

                        #region verificar se o arquivo existe
                        if (!File.Exists(oParam.pastaEntrada + origem))
                        {
                            CodigoDoResultado = TipoSituacaoNota.ArquivoNaoEncontrado;// 11;
                            DescricaoDoResultado = "Arquivo n�o foi localizado : " + oParam.pastaEntrada + origem;
                            throw new Exception(DescricaoDoResultado);
                        }
                        #endregion

                        #region verificar se � possivel ler o arquivo

                        try
                        {

                            using (StreamReader SR = File.OpenText(oParam.pastaEntrada + origem))
                            {
                                xmlNotaStr = SR.ReadToEnd();
                                SR.Close();
                            }
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            CodigoDoResultado = TipoSituacaoNota.SerivcoExcluido;// 99;
                            DescricaoDoResultado = "N�o foi poss�vel abrir o arquivo : " + oParam.pastaEntrada + origem + " > " + ex.Message;
                            throw new Exception(DescricaoDoResultado);
                        }

                        #endregion

                        #region verificar serializacao antes de assinar jogar na classe de NFe
                        try
                        {
                            oNFe = (ITNFe)Servicos.CarregaXML_STR(xmlNotaStr, oParam.versao, "TNFe");
                            Servicos.SalvaXML(oParam.pastaEntrada + origem, oNFe);
                            oNFe = null;
                        }
                        catch (Exception ex)
                        {
                            CodigoDoResultado = TipoSituacaoNota.XMLMalFormado;// 3;
                            DescricaoDoResultado = "N�o foi possivel Deserializar a nota no Objeto TNFe. - " + ex.Message;
                            throw new Exception(DescricaoDoResultado);
                        }
                        #endregion

                        AssinaNota(origem, ref CodigoDoResultado, ref DescricaoDoResultado);

                        if (CodigoDoResultado != 0)
                        {
                            throw new Exception(DescricaoDoResultado);
                        }
                        //nota assinada e validada

                        if (!File.Exists(oParam.pastaEntrada + "ass" + origem))
                        {
                            CodigoDoResultado = TipoSituacaoNota.ArquivoNaoEncontrado;// 11;
                            DescricaoDoResultado = "Nota n�o encontrada : " + origem;
                            throw new Exception(DescricaoDoResultado);
                        }

                        #region carregar a nfe assinada
                        oNFe = (ITNFe)Servicos.CarregaXML_HD(oParam.pastaEntrada + "ass" + origem, oParam.versao, "TNFe");


                        //todo validar a chave da NFe
                        //if (oNFe.infNFe.ide.cUF.ToString() != origem.Substring(0, 2) ||
                        //    oNFe.infNFe.ide.dEmi.Substring(2, 2) != origem.Substring(2, 2) ||
                        //    oNFe.infNFe.ide.dEmi.Substring(5, 2) != origem.Substring(4, 2) ||
                        //    oNFe.infNFe.emit.Item != origem.Substring(6, 14) ||
                        //    oNFe.infNFe.ide.mod.ToString() != origem.Substring(20, 2) ||
                        //    oNFe.infNFe.ide.serie.PadLeft(3, '0') != origem.Substring(22, 3) ||
                        //    oNFe.infNFe.ide.nNF.PadLeft(9, '0') != origem.Substring(25, 9) ||
                        //    oNFe.infNFe.ide.tpEmis.ToString() != origem.Substring(34, 1) ||
                        //    oNFe.infNFe.ide.cNF != origem.Substring(35, 8) ||
                        //    oNFe.infNFe.ide.cDV != origem.Substring(44, 1))
                        //{
                        //    CodigoDoResultado = 3;
                        //    DescricaoDoResultado = "Chave de acesso n�o corresponde aos valores informados no XML";
                        //    throw new Exception(DescricaoDoResultado);
                        //}
                        #endregion


                        #region  envelopar nota da nova maneira

                        if (oEnviNFe.NFe == null)
                            oEnviNFe.NFe = (ITNFe[])Servicos.XMLFactory(oParam.versao, "TNFe[]", 0);

                        bool canInsert = true;

                        #region verificar se NFe ja foi inserida no lote

                        foreach (var oNFeInserida in oEnviNFe.NFe)
                        {
                            if (oNFe.infNFe.Id == oNFeInserida.infNFe.Id)
                            {
                                canInsert = false;
                                break;
                            }
                        }
                        #endregion

                        #region Salvar informa��es no banco de dados NFe
                        NotaFiscal oNotaProc = new NotaFiscal();
                        oNotaProc.versao = oParam.versao;
                        oNotaProc.chaveNota = origem.Substring(0, origem.Length - 4);

                        oNotaProc.empresa = oParam.empresa;
                        oNotaProc.numeroLote = numeroNovoLote;
                        oNotaProc.codigoSituacao = CodigoDoResultado;
                        oNotaProc.xmlNota = xmlNotaStr;

                        if (CodigoDoResultado == 0)
                        {
                            oNotaProc.xmlProcesso = "";
                            oNotaProc.descricaoSituacao = DescricaoDoResultado;
                            oNotaProc.xmlNota = Servicos.GetXML(oNFe);
                        }
                        else if (CodigoDoResultado == TipoSituacaoNota.XMLInvalido)//os erros de valida�ao estao dentro de DescricaoDoResultado. 
                        {
                            oNotaProc.xmlProcesso = "<erro>" + DescricaoDoResultado + "</erro>";
                            oNotaProc.descricaoSituacao = "XML inv�lido";
                            DescricaoDoResultado = "XML inv�lido";
                        }
                        else//DescricaoDoResultado cont�m a mensagem correta para o Log
                        {
                            oNotaProc.xmlProcesso = "<erro>" + DescricaoDoResultado + "</erro>";
                            oNotaProc.descricaoSituacao = "XML inv�lido";
                        }

                        oNotaProc.nProt = "";
                        oNotaProc.xMotivo = "";
                        oNotaProc.cStat = "";

                        oNotaProc.xmlPedidoCancelamento = "";
                        oNotaProc.xmlProcessoCancelamento = "";
                        oNotaProc.nProtCancelamento = "";

                        oNotaProc.dataSituacao = DateTime.Now;
                        oNotaProc.Save(manager);



                        //Criar opera��o de Log
                        CriaLog((int)CodigoDoResultado, DescricaoDoResultado, oNotaProc.chaveNota);
                        #endregion

                        if (canInsert)
                        {
                            int tamanhoEnvelope = oEnviNFe.NFe.Length;
                            var listaAux = oEnviNFe.NFe;
                            oEnviNFe.NFe = (ITNFe[])Servicos.XMLFactory(oParam.versao, "TNFe[]", (tamanhoEnvelope + 1));
                            for (int pos = 0; pos < listaAux.Length; pos++)
                            {
                                var oNFe4List = (ITNFe)listaAux[pos];
                                oEnviNFe.NFe.SetValue(oNFe4List, pos);
                            }
                            oEnviNFe.NFe.SetValue(oNFe, listaAux.Length);
                        }

                        #endregion

                        #region integracao
                        try
                        {
                            if (oNotaProc.codigoSituacao != 0) //diferente de nota assinada
                            {
                                MMCustom.MMUtils.ProcessaResultadoNFe(origem,
                                    oNotaProc.codigoSituacao.ToString(),
                                    oNotaProc.descricaoSituacao,
                                    oNotaProc.cStat,
                                    oNotaProc.xMotivo,
                                    oNotaProc.nProt);
                            }
                        }
                        catch
                        { }
                        #endregion


                    }//fim do try principal
                    catch (Exception ex)
                    {
                        CriaLog(999, "CriaEnvelope", ex, origem.Replace(".xml", ""));

                        if (File.Exists(oParam.pastaEntrada + "ERRO" + CodigoDoResultado.ToString() + "_" + origem))
                            File.Delete(oParam.pastaEntrada + "ERRO" + CodigoDoResultado.ToString() + "_" + origem);

                        if (File.Exists(oParam.pastaEntrada + origem))
                            File.Move(oParam.pastaEntrada + origem, oParam.pastaEntrada + "ERRO" + CodigoDoResultado.ToString() + "_" + origem);

                    }





                }//fim do for
                #endregion

                #region criar servico pendente referente as notas que estao no lote
                //Carrega lote se criado
                CriaLog(999, "Lote criado : " + numeroNovoLote.ToString());

                //adicionar o lote nos servicos pendentes
                ServicoPendente oServicoPendente = new ServicoPendente();

                string msgLog = "Servi�o criado com sucesso.";

                oServicoPendente.codigoSituacao = TipoSituacaoServico.Assinado;

                if (oEnviNFe.NFe != null && oEnviNFe.NFe.Length > 0)
                {
                    //criar pasta se n�o existir 
                    if (!Directory.Exists(oParam.pastaSaida))
                        Directory.CreateDirectory(oParam.pastaSaida);

                    //salvar o lote
                    if (File.Exists(oParam.pastaSaida + oEnviNFe.idLote + "-env-lot.xml"))
                        File.Delete(oParam.pastaSaida + oEnviNFe.idLote + "-env-lot.xml");

                    Servicos.SalvaXML(oParam.pastaSaida + oEnviNFe.idLote + "-env-lot.xml", oEnviNFe);
                }
                else
                {
                    oServicoPendente.codigoSituacao = TipoSituacaoServico.Invalido;
                    msgLog = "Servi�o foi criado sem nenhuma nota v�lida.";
                }

                oServicoPendente.dataSituacao = DateTime.Now;
                oServicoPendente.versao = oParam.versao;
                oServicoPendente.empresa = oParam.empresa;
                oServicoPendente.numeroLote = numeroNovoLote;
                oServicoPendente.UF = oParam.UF;
                oServicoPendente.tipoAmbiente = oParam.tipoAmbiente;
                oServicoPendente.tipoEmissao = oParam.tipoEmissao;

                oServicoPendente.numeroRecibo = "";
                oServicoPendente.xmlRecibo = "";
                oServicoPendente.xmlRetConsulta = "";
                oServicoPendente.erroEnvio = false;

                oServicoPendente.Save(manager);

                CriaLog(1, msgLog);

                dataUltimaCriacaoEnvelope = DateTime.Now;
                #endregion

            }
            catch (Exception ex)
            {
                CriaLog(999, "CriaEnvelope(Geral)", ex);
            }
        }

        /// <summary>
        /// Vers�o 2.0 - ok
        /// 
        /// </summary>
        /// <param name="oServicoPendente">Servico ainda n�o enviado. situacao = 1</param>
        private void EnviaEnvelope(ServicoPendente oServicoPendente)
        {
            ITEnviNFe oEnviNFe;
            ITRetEnviNFe oRetEnviNFe = null;
            try
            {

                String nomeArquivo = oParam.pastaSaida + oServicoPendente.numeroLote.ToString() + "-env-lot.xml";
                //verificar se existe
                if (!File.Exists(nomeArquivo))
                    throw new Exception("N�o foi poss�vel localizar o arquivo : " + nomeArquivo);

                //carregar envelope
                oEnviNFe = (ITEnviNFe)Servicos.CarregaXML_HD(nomeArquivo, oParam.versao, "TEnviNFe");


                //pronto para enviar
                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.ClientProxyFactory(oParam,
                    //enviar envelope utilizando o servico correto
                    oServicoPendente.versao == VersaoNFe.v310 ? TServico.Autorizacao : TServico.Recepcao);

                try
                {
                    //chamar o servico
                    oRetEnviNFe = Servicos.EnviarEnvelope(oServico, oEnviNFe, oParam, oServicoPendente.versao);

                }
                catch (Exception ex)
                {
                    oServicoPendente.erroEnvio = true;

                    connectionOk = ConsultaStatus();

                    CriaLog(998, "EnviaEnvelope", ex);
                }

                if (oRetEnviNFe != null && oRetEnviNFe.infRec != null)
                {
                    //criar pasta se n�o existir 
                    if (!Directory.Exists(oParam.pastaRecibo))
                        Directory.CreateDirectory(oParam.pastaRecibo);

                    //salvar o recibo do envio
                    Servicos.SalvaXML(oParam.pastaRecibo + oServicoPendente.numeroLote.ToString() + "-rec.xml", oRetEnviNFe);

                    #region atualizar Servico Pendente

                    if (oRetEnviNFe.cStat != "103")
                        throw new Exception(oRetEnviNFe.xMotivo);

                    oServicoPendente.numeroRecibo = oRetEnviNFe.infRec.nRec;

                    oServicoPendente.xmlRecibo = Servicos.GetXML(oRetEnviNFe);

                    //utilizar a hora do servidor.
                    oServicoPendente.dataSituacao = DateTime.Now;//oRetEnviNFe.dhRecbto;

                    oServicoPendente.codigoSituacao = TipoSituacaoServico.Enviado;


                    //setar todas as notas desse servico como enviadas.

                    NotaFiscalQry oNFeQry = new NotaFiscalQry();
                    oNFeQry.empresa = oServicoPendente.empresa;
                    oNFeQry.numeroLote = oServicoPendente.numeroLote.ToString();

                    //somente as que foram assinadas e inseridas no lote.
                    oNFeQry.codigoSituacao = TipoSituacaoNota.Assinada;

                    ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFeQry, manager);
                    foreach (NotaFiscal oNFeProc in notasProcessadas)
                    {
                        oNFeProc.codigoSituacao = TipoSituacaoNota.Enviada;// 12; //Enviada
                        oNFeProc.descricaoSituacao = "Nota enviada";
                        oNFeProc.dataSituacao = oServicoPendente.dataSituacao;
                        oNFeProc.Save(manager);

                        CriaLog(12, "Nota enviada", oNFeProc.chaveNota);
                    }
                    #endregion
                }
                else
                {
                    if (!oServicoPendente.erroEnvio) // a comunicacao foi bem sucedida, mas nao foi possivel abrir o nRec
                    {
                        oServicoPendente.erroEnvio = true;
                        //todo : tratar
                    }
                    oServicoPendente.codigoSituacao = TipoSituacaoServico.ProblemaNoEnvio;
                }

                oServicoPendente.Save(manager);

                //integracao
                if (oServicoPendente.codigoSituacao == TipoSituacaoServico.ProblemaNoEnvio)
                {
                    try
                    {
                        NotaFiscalQry oNFeQry = new NotaFiscalQry();
                        oNFeQry.empresa = oServicoPendente.empresa;
                        oNFeQry.numeroLote = oServicoPendente.numeroLote.ToString();
                        //somente as que foram assinadas e inseridas no lote.
                        oNFeQry.codigoSituacao = TipoSituacaoNota.Assinada;
                        ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFeQry, manager);
                        foreach (NotaFiscal oNFeProc in notasProcessadas)
                        {
                            MMCustom.MMUtils.ProcessaResultadoNFe(oNFeProc.chaveNota,
                                    oNFeProc.codigoSituacao.ToString(),
                                    oNFeProc.descricaoSituacao,
                                    oNFeProc.cStat,
                                    oNFeProc.xMotivo,
                                    oNFeProc.nProt);
                        }
                    }
                    catch { }
                }

                if (oRetEnviNFe != null)
                    CriaLog(Int32.Parse(oRetEnviNFe.cStat), oRetEnviNFe.xMotivo);
            }
            catch (Exception ex)
            {
                CriaLog(999, "EnviaEnvelope", ex);
            }
            finally
            {
                oEnviNFe = null;
                oRetEnviNFe = null;
            }
        }

        /// <summary>
        /// Vers�o 2.0 - ok
        /// </summary>
        /// <param name="oServicoPendente">situacao = 2 : enviado</param>
        public void ConsultaEnvelope(ServicoPendente oServicoPendente)
        {
            ITRetEnviNFe oRetEnviNFe;
            ITConsReciNFe oConsReciNFe;
            ITRetConsReciNFe oRetConsReciNFe = null;

            try
            {
                oServicoPendente.dataSituacao = DateTime.Now;
                oServicoPendente.Save(manager);

                oRetEnviNFe = (ITRetEnviNFe)Servicos.CarregaXML_STR(oServicoPendente.xmlRecibo, oServicoPendente.versao, "TRetEnviNFe");

                if (oRetEnviNFe.infRec.nRec != oServicoPendente.numeroRecibo)
                {
                    oServicoPendente.codigoSituacao = TipoSituacaoServico.ProblemaNoEnvio;
                }
                else
                {
                    //cria o objeto de consulta de recibo
                    oConsReciNFe = (ITConsReciNFe)Servicos.XMLFactory(oParam.versao, "TConsReciNFe");
                    oConsReciNFe.versao = oParam.versaoDados;
                    oConsReciNFe.tpAmb = oRetEnviNFe.tpAmb;

                    oConsReciNFe.nRec = oRetEnviNFe.infRec.nRec;

                    //executar o servico
                    System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.ClientProxyFactory(oParam,
                        oServicoPendente.versao == VersaoNFe.v310 ? TServico.RetAutorizacao : TServico.RetRecepcao);

                    try
                    {
                        oRetConsReciNFe = Servicos.ConsultarProcessamentoEnvelope(oServico, oConsReciNFe, oParam, oServicoPendente.versao);
                    }
                    catch (Exception ex)
                    {
                        connectionOk = ConsultaStatus();

                        throw ex;
                    }

                    //salvar o arquivo de retorno da consulta
                    Servicos.SalvaXML(oParam.pastaRecibo + oServicoPendente.numeroRecibo + "-pro-rec.xml", oRetConsReciNFe);

                    //testar retorno
                    #region trata Retorno do processamento

                    //atualiza a tabela de notas
                    NotaFiscalQry oNFQry = new NotaFiscalQry();
                    oNFQry.empresa = oServicoPendente.empresa;
                    oNFQry.numeroLote = oServicoPendente.numeroLote.ToString();

                    //buscar somente as notas que pertencem ao lote como enviada
                    oNFQry.codigoSituacao = TipoSituacaoNota.Enviada;// "12";//enviada

                    ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFQry, manager);

                    //testa Codigo de Mensagem de resultado

                    if (oRetConsReciNFe.cStat == "105")
                    {
                        CriaLog(105, "Lote em processamento");
                    }
                    else if (oRetConsReciNFe.cStat == "225" || oRetConsReciNFe.cStat == "223" ||
                        oRetConsReciNFe.cStat == "280" || oRetConsReciNFe.cStat == "281" ||
                        oRetConsReciNFe.cStat == "283" || oRetConsReciNFe.cStat == "286" ||
                        oRetConsReciNFe.cStat == "284" || oRetConsReciNFe.cStat == "285" ||
                        oRetConsReciNFe.cStat == "282" || oRetConsReciNFe.cStat == "214" ||
                        oRetConsReciNFe.cStat == "243" || oRetConsReciNFe.cStat == "242" ||
                        oRetConsReciNFe.cStat == "299" || oRetConsReciNFe.cStat == "408" ||
                        oRetConsReciNFe.cStat == "238" || oRetConsReciNFe.cStat == "239" ||
                        oRetConsReciNFe.cStat == "215" || oRetConsReciNFe.cStat == "404" ||
                        oRetConsReciNFe.cStat == "402" || oRetConsReciNFe.cStat == "252" ||
                        oRetConsReciNFe.cStat == "248" || oRetConsReciNFe.cStat == "106" ||
                        (oRetConsReciNFe.cStat == "104" && oRetConsReciNFe.protNFe[0].infProt.cStat == "999"))
                    {
                        //aplicativo dever� rejeitar o servico todo
                        CriaLog(Int32.Parse(oRetConsReciNFe.cStat), "Lote " + oServicoPendente.numeroLote.ToString() + " : " + oRetConsReciNFe.xMotivo);


                        foreach (NotaFiscal oNFeProc in notasProcessadas)
                        {
                            oNFeProc.codigoSituacao = TipoSituacaoNota.Rejeitada;// 14; //nota rejeitada
                            oNFeProc.descricaoSituacao = "Nota Rejeitada";
                            oNFeProc.dataSituacao = DateTime.Now;

                            oNFeProc.xmlProcesso = Servicos.GetXML(oRetConsReciNFe);
                            oNFeProc.cStat = oRetConsReciNFe.cStat;
                            oNFeProc.xMotivo = oRetConsReciNFe.xMotivo;

                            oNFeProc.Save(manager);

                            //integracao
                            try
                            {
                                MMCustom.MMUtils.ProcessaResultadoNFe(oNFeProc.chaveNota,
                                        oNFeProc.codigoSituacao.ToString(),
                                        oNFeProc.descricaoSituacao,
                                        oNFeProc.cStat,
                                        oNFeProc.xMotivo,
                                        oNFeProc.nProt);
                            }
                            catch { }

                            CriaLog(14, "Nota rejeitada pelo processamento do lote", oNFeProc.chaveNota);
                        }

                        //atualiza a tabela de servi�os pendentes daquele lote.
                        oServicoPendente.codigoSituacao = TipoSituacaoServico.Rejeitado;
                    }
                    else if (oRetConsReciNFe.cStat == "104")//lote ja foi processado
                    {
                        //aplicativo dever� atualiza o servico 
                        CriaLog(Int32.Parse(oRetConsReciNFe.cStat), "Lote " + oServicoPendente.numeroRecibo.ToString() + " : " + oRetConsReciNFe.xMotivo);

                        #region percorre as notas
                        foreach (NotaFiscal oNotaProc in notasProcessadas)
                        {
                            Boolean find = false;
                            foreach (var protocolo in oRetConsReciNFe.protNFe)
                            {
                                if (protocolo.infProt.chNFe == oNotaProc.chaveNota.Replace("NFe", ""))
                                {
                                    find = true;
                                    #region achou protocolo da nota

                                    oNotaProc.dataSituacao = DateTime.Now;

                                    oNotaProc.xmlProcesso = Servicos.GetXML(protocolo);
                                    oNotaProc.cStat = protocolo.infProt.cStat;
                                    oNotaProc.xMotivo = protocolo.infProt.xMotivo;

                                    if (protocolo.infProt.cStat == "100" || protocolo.infProt.cStat == "150")
                                    {
                                        //autorizacao por nota
                                        oNotaProc.codigoSituacao = TipoSituacaoNota.Aprovada;// 13;//nota Aprovada
                                        oNotaProc.descricaoSituacao = "Nota Aprovada";
                                        if (protocolo.infProt.nProt != null)
                                        {
                                            oNotaProc.nProt = protocolo.infProt.nProt;
                                        }
                                        else
                                        {
                                            oNotaProc.nProt = ""; //todo : tratar 
                                            CriaLog(999, "N�o foi possivel obter nProt do retorno da consulta. ", oNotaProc.chaveNota.ToString());
                                        }
                                    }
                                    else if (protocolo.infProt.cStat == "110")
                                    {
                                        oNotaProc.codigoSituacao = TipoSituacaoNota.Denegada;
                                        oNotaProc.descricaoSituacao = "Uso Denegado";
                                    }
                                    else
                                    {
                                        //rejeicao por nota
                                        oNotaProc.codigoSituacao = TipoSituacaoNota.Rejeitada;// 14;//nota rejeitada
                                        oNotaProc.descricaoSituacao = "Nota Rejeitada";
                                    }
                                    oNotaProc.Save(manager);

                                    //integracao
                                    try
                                    {
                                        MMCustom.MMUtils.ProcessaResultadoNFe(oNotaProc.chaveNota,
                                                oNotaProc.codigoSituacao.ToString(),
                                                oNotaProc.descricaoSituacao,
                                                oNotaProc.cStat,
                                                oNotaProc.xMotivo,
                                                oNotaProc.nProt);
                                    }
                                    catch { }

                                    //Atualiza LOG
                                    CriaLog(Convert.ToInt32(protocolo.infProt.cStat),
                                                            protocolo.infProt.xMotivo,
                                                    "NFe" + protocolo.infProt.chNFe);
                                    #endregion
                                    break;
                                }
                            }//fim do foreach protocolo

                            //tratar se NFe nao foi localizada

                            if (!find)
                            {
                                //rejeicao por nota
                                oNotaProc.dataSituacao = DateTime.Now;
                                oNotaProc.codigoSituacao = TipoSituacaoNota.RejeitadaPeloProcessamentoLote;// 17;//nota rejeitada pelo processamento do lote
                                oNotaProc.descricaoSituacao = "Nota Rejeitada pelo processamento do lote";
                                oNotaProc.Save(manager);
                            }

                        }//fim do foreach nota
                        #endregion

                        //atualiza a tabela de servi�os pendentes daquele lote.
                        oServicoPendente.codigoSituacao = TipoSituacaoServico.Processado;
                    }
                    #endregion
                }

                oServicoPendente.dataSituacao = DateTime.Now;
                oServicoPendente.xmlRetConsulta = Servicos.GetXML(oRetConsReciNFe);
                oServicoPendente.Save(manager);


            }
            catch (Exception ex)
            {
                CriaLog(999, "ConsultaEnvelope", ex);
            }
            finally
            {
                oRetConsReciNFe = null;
                oConsReciNFe = null;
            }
        }

        /// <summary>
        /// Versao 2.0 - ok
        /// </summary>
        /// <returns>true - Sefaz respondeu ou false - falha na conexao</returns>
        public Boolean ConsultaStatus()
        {
            ITRetConsStatServ oRetConsStatServ;
            ITConsStatServ oConsStatServ;

            bool retorno;

            try
            {
                if (!Directory.Exists(oParam.pastaRecibo))
                    Directory.CreateDirectory(oParam.pastaRecibo);

                #region Cria objeto de consulta
                oConsStatServ = (ITConsStatServ)Servicos.XMLFactory(oParam.versao, "TConsStatServ");
                oConsStatServ.versao = oParam.versaoDados;
                oConsStatServ.tpAmb = oParam.tipoAmbiente;
                oConsStatServ.cUF = oParam.UF;
                #endregion

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico =
                    NFeUtils.ClientProxyFactory(oParam, TServico.Status);

                Servicos.SalvaXML(oParam.pastaRecibo + oParam.UF.ToString() + "consulta-ped-sta.xml",
                        oConsStatServ);

                oRetConsStatServ = Servicos.ConsultarStatusServidor(oServico, oConsStatServ, oParam, oParam.versao);

                if (!Directory.Exists(oParam.pastaRecibo))
                    Directory.CreateDirectory(oParam.pastaRecibo);

                Servicos.SalvaXML(oParam.pastaRecibo + oParam.UF.ToString() + "consulta-sta.xml",
                    oRetConsStatServ);


                //teste de opera��o
                retorno = (oRetConsStatServ.cStat == "107");
                CriaLog(Int32.Parse(oRetConsStatServ.cStat), "SEFAZ-" +
                    NFeUtils.ObterDescricao(oParam.UF) + " " + oRetConsStatServ.xMotivo);

            }
            catch (Exception ex)
            {
                //mapear codigos do log
                CriaLog(999, "ConsultaStatus SEFAZ-" + NFeUtils.ObterDescricao(oParam.UF) + " n�o respondeu no timeout configurado. ",
                    ex);
                retorno = false;
            }
            finally
            {
                //Limpa os objetos
                oConsStatServ = null;
                oRetConsStatServ = null;
            }

            //integracao
            try
            {
                MMCustom.MMUtils.ConsultaStatusSefaz(retorno);
            }
            catch { }

            return retorno;
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="oServicoPendente">processado  = 3</param>
        public void FinalizaServicos(ServicoPendente oServicoPendente)
        {
            try
            {
                //buscar no banco as notas aprovadas desse ServicoPendente
                NotaFiscalQry oNFeQry = new NotaFiscalQry();
                oNFeQry.empresa = oServicoPendente.empresa;
                oNFeQry.numeroLote = oServicoPendente.numeroLote.ToString();
                oNFeQry.codigoSituacao = TipoSituacaoNota.Aprovada;// "13";//aprovada

                ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFeQry, manager);

                foreach (NotaFiscal oNotaProc in notasProcessadas)
                {
                    NFeUtils.ImprimeDANFe(oNotaProc, oParam, manager);
                    CriaLog(4, "Arquivo enviado para Pasta de Impress�o com sucesso!", oNotaProc.chaveNota);
                }
                oServicoPendente.codigoSituacao = TipoSituacaoServico.Finalizado;
                oServicoPendente.dataSituacao = DateTime.Now;
                oServicoPendente.Save(manager);
            }
            catch (Exception ex)
            {
                CriaLog(999, "FinalizaServicos", ex);
            }
            finally
            {

            }
        }

        /// <summary>
        /// Registro de evento
        /// </summary>
        /// <param name="ChaveNFe"></param>
        /// <returns></returns>
        public void RecepcaoEvento(ITEvento oEventoNFeAss, int idLote, ref String xmlRetEnvEvento, VersaoNFe versao)
        {
            ITEnvEvento oEnvEvento;
            ITRetEnvEvento oRetEnvEvento;

            try
            {
                //criar um envelope do evento
                oEnvEvento = (ITEnvEvento)Servicos.XMLFactory(versao, "TEnvEvento");
                oEnvEvento.evento = (ITEvento[])Servicos.XMLFactory(versao, "TEvento[]", 1);
                oEnvEvento.evento[0] = oEventoNFeAss;

                oEnvEvento.idLote = idLote.ToString();
                oEnvEvento.versao = "1.00";

                //cria servico
                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.ClientProxyFactory(oParam, TServico.RecepcaoEvento);
                try
                {
                    //executa servico
                    oRetEnvEvento = Servicos.EnviarEnvelopeEvento(oServico, oEnvEvento, oParam, oParam.versao);
                    xmlRetEnvEvento = Servicos.GetXML(oRetEnvEvento);

                }
                catch (Exception ex)
                {
                    connectionOk = ConsultaStatus();

                    throw ex;
                }
            }
            catch (Exception ex)
            {
                CriaLog(999, "RecepcaoEvento", ex);
            }
            finally
            {
                oRetEnvEvento = null;
                oEnvEvento = null;
            }
        }

        /// <summary>
        /// Executa servico do webservice de consulta protocolo, testando antes se webservice esta funcionando.
        /// </summary>
        /// <param name="ChaveNFe">chave da nfe a ser consultada sem o NFe.</param>
        /// <returns>ok - true(oParam.pastaRecibo + ChaveNFe + "-sit.xml") | erro - false </returns>
        /// 
        public Boolean ConsultaProcNFe(String ChaveNFe)
        {
            ITConsSitNFe oConsSitNFe;
            ITRetConsSitNFe oRetConsSitNFe;

            //if (ConsultaStatus())
            //retirado para atender as regras de boas praticas da SEFAZ
            //{
            //Comunica��o OK
            try
            {

                oConsSitNFe = (ITConsSitNFe)Servicos.XMLFactory(oParam.versao, "TConsSitNFe");
                oConsSitNFe.chNFe = ChaveNFe;
                oConsSitNFe.tpAmb = oParam.tipoAmbiente;
                if (oParam.versao == VersaoNFe.v200)
                    oConsSitNFe.versao = TVerConsSitNFe.Item201;
                else if (oParam.versao == VersaoNFe.v300)
                    oConsSitNFe.versao = TVerConsSitNFe.Item300;
                else if (oParam.versao == VersaoNFe.v310)
                    oConsSitNFe.versao = TVerConsSitNFe.Item310;

                if (!Directory.Exists(oParam.pastaRecibo))
                    Directory.CreateDirectory(oParam.pastaRecibo);

                if (File.Exists(oParam.pastaRecibo + ChaveNFe + "-ped-sit.xml"))
                    File.Delete(oParam.pastaRecibo + ChaveNFe + "-ped-sit.xml");

                RDI.NFe2.Business.Servicos.SalvaXML(oParam.pastaRecibo + ChaveNFe + "-ped-sit.xml", oConsSitNFe);

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.ClientProxyFactory(oParam, TServico.Consulta);

                try
                {
                    // Executa servico
                    oRetConsSitNFe = Servicos.ConsultarSituacaoNFe(oServico, oConsSitNFe, oParam, oParam.versao);

                    Servicos.SalvaXML(oParam.pastaRecibo + ChaveNFe + "-sit.xml", oRetConsSitNFe);

                    return true;
                }
                catch (Exception ex)
                {
                    connectionOk = ConsultaStatus();
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                CriaLog(999, "ConsultaProcNFe", ex, ChaveNFe);
                return false;
            }
            finally
            {
                oRetConsSitNFe = null;
                oConsSitNFe = null;
            }
            //}
            //else
            //{
            //    return false;
            //}

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oInutNFe"></param>
        /// <param name="cStat"></param>
        /// <param name="xMotivo"></param>
        public void InutilizaNumeracao(ITInutNFe oInutNFe, ref String cStat, ref String xMotivo, VersaoNFe versao)
        {
            ITRetInutNFe oRetInutNFe;

            try
            {

                String nomeArquivoPedido = oParam.pastaRecibo + oInutNFe.infInut.Id + "-pi.xml";
                String nomeArquivoPedidoAss = oParam.pastaRecibo + oInutNFe.infInut.Id + "-ped-inu.xml";

                if (File.Exists(nomeArquivoPedido))
                    File.Delete(nomeArquivoPedido);

                //salvar o arquivo
                NFe2.Business.Servicos.SalvaXML(nomeArquivoPedido, oInutNFe);

                //assinar pedido
                X509Certificate2 cert;
                if (oParam.usarCertificadoDisco)
                    cert = Certificado.BuscaCaminho(oParam.caminhoCertificado, oParam.senhaCertificado);
                else
                    cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

                var CodigoDoResultado = NFeUtils.AssinaXML(nomeArquivoPedido, "infInut", cert, versao);
                cert = null;

                //apaga arquivo sem assinatura : -pi.xml
                if (File.Exists(nomeArquivoPedido))
                    File.Delete(nomeArquivoPedido);

                //avaliar retorno da assinatura
                if (CodigoDoResultado == TipoSituacaoNota.Assinada)
                {
                    String erros = NFeUtils.ValidacaoXML(nomeArquivoPedidoAss,
                                                  oParam.pastaXSD + "inutNFe_v" + oParam.versaoDados + ".xsd");

                    if (erros != System.String.Empty)      //todo : problema : xml nao validado.
                    {
                        throw new Exception("N�o foi poss�vel validar o arquivo de Pedido de Inutiliza��o.");
                    }
                    else if (erros == "NotFound")//TODO : implementar teste em validacaoXML.
                    {
                        throw new Exception("N�o foi poss�vel encontrar o arquivo de Pedido de Inutiliza��o.");
                    }
                    else //ESTA TUDO OK 
                    {
                        //carrega o pedido assinado
                        oInutNFe = (ITInutNFe)Servicos.CarregaXML_HD(nomeArquivoPedidoAss, oParam.versao, "TInutNFe");
                        //cria servico
                        System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.ClientProxyFactory(oParam, TServico.Inutilizacao);
                        try
                        {
                            //executa servico
                            oRetInutNFe = Servicos.InutilizarNFe(oServico, oInutNFe, oParam, oParam.versao);
                            //setar variaveis de retorno
                            cStat = oRetInutNFe.infInut.cStat;
                            xMotivo = oRetInutNFe.infInut.xMotivo;
                            //salva resultado no HD
                            Servicos.SalvaXML(nomeArquivoPedidoAss.Replace("-ped", ""), oRetInutNFe);
                        }
                        catch (Exception ex)
                        {
                            connectionOk = ConsultaStatus();

                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CriaLog(999, "InutilizaNumeracao", ex);
            }
            finally
            {
                oRetInutNFe = null;
            }
        }

        public bool AtualizarNFePeloID(NotaFiscal oNotaFiscal, out string mensagemErro)
        {
            try
            {
                if (ConsultaProcNFe(oNotaFiscal.chaveNota.Replace("NFe", "")))
                {
                    ITRetConsSitNFe oRetConsSitNFe = (ITRetConsSitNFe)Servicos.CarregaXML_HD(oParam.pastaRecibo + oNotaFiscal.chaveNota.Replace("NFe", "") + "-sit.xml", oNotaFiscal.versao, "TRetConsSitNFe");

                    //100-uso autorizado, 150-uso autorizado fora de prazo
                    //101-cancelado ou 151-cancelado fora de prazo.
                    //155-cancelado por evento fora do prazo
                    if (oRetConsSitNFe.cStat == "100" || oRetConsSitNFe.cStat == "150"
                        || oRetConsSitNFe.cStat == "101" || oRetConsSitNFe.cStat == "151"
                        || oRetConsSitNFe.cStat == "155")
                    {
                        #region recuperar protocolo
                        if (oRetConsSitNFe.protNFe == null || oRetConsSitNFe.protNFe.infProt == null)
                        {
                            //nao foi possivel obter a situa��o da NFE
                            mensagemErro = "Erro no XML. Nota foi aprovada mas protocolo de autoriza��o n�o esta aces�vel";
                            return false;
                        }
                        #endregion

                        ITNFe oNFeXML = (ITNFe)Servicos.CarregaXML_STR(oNotaFiscal.xmlNota, oNotaFiscal.versao, "TNFe");

                        if (oNFeXML.Signature == null || oNFeXML.Signature.SignedInfo == null ||
                            oNFeXML.Signature.SignedInfo.Reference == null)
                        {
                            mensagemErro = "N�o foi poss�vel carregar o DigestValue da NFe requisitada.";
                            return false;
                        }

                        if (Convert.ToBase64String(oRetConsSitNFe.protNFe.infProt.digVal) !=
                            Convert.ToBase64String(oNFeXML.Signature.SignedInfo.Reference.DigestValue))
                        {
                            mensagemErro = "DigestValue da NFe requisitada n�o corresponde ao DigestValue da NFe aprovada.";
                            return false;
                        }
                        //documento conferido
                        if (oRetConsSitNFe.protNFe.infProt.nProt == null)
                        {
                            mensagemErro = "N�o foi poss�vel recuperar o nProt da aprova��o da NFe.";
                            return false;
                        }

                        oNotaFiscal.dataSituacao = DateTime.Now;
                        oNotaFiscal.cStat = oRetConsSitNFe.cStat;
                        oNotaFiscal.xMotivo = oRetConsSitNFe.xMotivo;

                        //dados da Autoriza��o
                        oNotaFiscal.nProt = oRetConsSitNFe.protNFe.infProt.nProt;
                        oNotaFiscal.xmlProcesso = Servicos.GetXML(oRetConsSitNFe.protNFe);

                        //dados do cancelamento
                        if ((oRetConsSitNFe.retCancNFe != null && oRetConsSitNFe.retCancNFe.infCanc != null
                            && !String.IsNullOrEmpty(oRetConsSitNFe.retCancNFe.infCanc.nProt)))
                        {
                            oNotaFiscal.nProtCancelamento = oRetConsSitNFe.retCancNFe.infCanc.nProt;
                            oNotaFiscal.xmlProcessoCancelamento = Servicos.GetXML(oRetConsSitNFe.retCancNFe).Replace("TRetCancNFe_v200107", "retCancNFe");
                        }

                        //dados dos eventos
                        if (oRetConsSitNFe.procEventoNFe != null)
                        {
                            foreach (var item in oRetConsSitNFe.procEventoNFe)
                            {
                                //atualizar o XML Reposta do Evento
                                ITRetEnvEvento XmlRespostaEvento = (ITRetEnvEvento)Servicos.XMLFactory(oNotaFiscal.versao, "TRetEnvEvento");
                                XmlRespostaEvento.tpAmb = oParam.tipoAmbiente;
                                XmlRespostaEvento.retEvento = (ITretEvento[])Servicos.XMLFactory(oNotaFiscal.versao, "TretEvento", 1);
                                XmlRespostaEvento.retEvento[0] = item.retEvento;

                                bool eventoEncontrado = false;
                                #region verificar se evento j� existe no banco
                                foreach (Evento oEvento in oNotaFiscal.CarregarEventos(manager).Where(ev => ev.tpEvento == item.evento.infEvento.tpEvento))
                                {
                                    if (!String.IsNullOrEmpty(oEvento.XMLPedido))
                                    {
                                        ITEvento XmlEvento =
                                            (ITEvento)
                                            Servicos.CarregaXML_STR(oEvento.XMLPedido, oNotaFiscal.versao, "TEvento");

                                        //comparar pela assinatura
                                        if (Convert.ToBase64String(XmlEvento.Signature.SignedInfo.Reference.DigestValue) ==
                                        Convert.ToBase64String(item.evento.Signature.SignedInfo.Reference.DigestValue))
                                        {
                                            if (String.IsNullOrEmpty(oEvento.XMLResposta))
                                            {
                                                oEvento.XMLResposta = Servicos.GetXML(XmlRespostaEvento);
                                            }

                                            switch (item.retEvento.infEvento.cStat)
                                            {
                                                case "135": oEvento.codigoSituacao = TipoSituacaoEvento.FinalizadoAprovado135; break;
                                                case "136": oEvento.codigoSituacao = TipoSituacaoEvento.FinalizadoAprovado136; break;
                                                case "155": oEvento.codigoSituacao = TipoSituacaoEvento.FinalizadoAprovado155; break;
                                            }

                                            //salvar evento
                                            oEvento.Save(manager);

                                            //se for evento de cancelamento
                                            if (oEvento.tpEvento == TEventoInfEventoTpEvento.Cancelamento)
                                            {
                                                //atualizar nProt de cancelamento
                                                oNotaFiscal.nProtCancelamento = item.retEvento.infEvento.nProt;
                                            }
                                            eventoEncontrado = true;
                                            break;
                                        }
                                    }
                                #endregion
                                }
                                if (!eventoEncontrado)
                                {
                                    #region criar novo evento
                                    Evento oNovoEvento = new Evento();
                                    oNovoEvento.XMLPedido = Servicos.GetXML(item.evento);
                                    oNovoEvento.XMLResposta = Servicos.GetXML(XmlRespostaEvento);
                                    switch (item.retEvento.infEvento.cStat)
                                    {
                                        case "135": oNovoEvento.codigoSituacao = TipoSituacaoEvento.FinalizadoAprovado135; break;
                                        case "136": oNovoEvento.codigoSituacao = TipoSituacaoEvento.FinalizadoAprovado136; break;
                                        case "155": oNovoEvento.codigoSituacao = TipoSituacaoEvento.FinalizadoAprovado155; break;
                                    }
                                    oNovoEvento.tpEvento = item.evento.infEvento.tpEvento;
                                    #region Pegar o ultimo lote criado.
                                    EventoQry oTbEventoQry = new EventoQry();
                                    oTbEventoQry.empresa = oParam.empresa;
                                    int numeroNovoLote = EventoDAL.Instance.GetMax(oTbEventoQry, manager);
                                    #endregion
                                    oNovoEvento.id = numeroNovoLote;
                                    oNovoEvento.empresa = oNotaFiscal.empresa;
                                    oNovoEvento.chaveNota = oNotaFiscal.chaveNota;
                                    oNovoEvento.numeroLote = oNotaFiscal.numeroLote;
                                    oNovoEvento.Save(manager);
                                    #endregion

                                    XmlRespostaEvento = null;
                                }
                            }
                        }

                        #region situa��o atual da NFe
                        if (oRetConsSitNFe.cStat == "100" || oRetConsSitNFe.cStat == "150")
                        {
                            oNotaFiscal.codigoSituacao = TipoSituacaoNota.Aprovada;// 13;//nota Aprovada
                            oNotaFiscal.descricaoSituacao = "Nota Aprovada";
                        }
                        else if (oRetConsSitNFe.cStat == "101" || oRetConsSitNFe.cStat == "151"
                        || oRetConsSitNFe.cStat == "155")
                        {
                            oNotaFiscal.codigoSituacao = TipoSituacaoNota.Cancelada;// 16;//nota cancelada
                            oNotaFiscal.descricaoSituacao = "Nota Cancelada";
                        }
                        else
                        {
                            mensagemErro = "Situa��o n�o mapeada. - " + oRetConsSitNFe.cStat;
                            return false;
                        }
                        #endregion

                        oNotaFiscal.Save(manager);

                        oNFeXML = null;
                    }
                    else
                    {
                        //nota nao foi aprovada
                        mensagemErro = oRetConsSitNFe.xMotivo;
                        return false;
                    }

                    oRetConsSitNFe = null;

                    mensagemErro = "Dados da NFe atualizados.";
                    return true;
                }
                else
                {
                    //nao foi possivel obter a situacao da NFE
                    mensagemErro = "N�o foi poss�vel obter a situa��o da NFe";
                    return false;
                }
            }
            catch (Exception ex)
            {
                CriaLog(999, "Atualizar situa��o pela chave", ex);
                mensagemErro = (ex.Message);
                return false;
            }
        }
    }
}

