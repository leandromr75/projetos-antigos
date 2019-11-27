using System;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml.Serialization;
using RDI.NFe2.SchemaXML;
using RDI.NFe2.ORMAP;
using RDI.Lince;
using System.Threading;

namespace RDI.NFe2.Business
{
    public static class NFeUtils
    {

        public static void ThreadMasterExecution(Object oThreadIdetificada)
        {
            ThreadIdetificada oTh = (ThreadIdetificada)oThreadIdetificada;
            String ConAux = (String)oTh.args[0];
            String empresa = (String)oTh.args[1];
            bool enviarErro = false;

            if (oTh.args.Length > 2)
                enviarErro = (bool)oTh.args[2];

            ClientEnvironment manager = null;
            FuncaoAutomacao oFuncao = null;
            try
            {
                oTh.executando = true;
                oTh.DoOnStart(null, new StatusEventArgs() { empresa = empresa });

                manager = Conexao.CreateManager(ConAux);
                oFuncao = new FuncaoAutomacao(empresa, manager, enviarErro);

                oFuncao.CriaLog(998, "Serviço de monitoramento inicializado com sucesso.");


                DateTime dataUltimaExecucao = DateTime.Now;
                Int32 totalMilliSecondsTime = 1000;

                while (!oTh.finalizar)
                {

                    TimeSpan elapsed = DateTime.Now.Subtract(dataUltimaExecucao);
                    if (elapsed.TotalMilliseconds < totalMilliSecondsTime)
                    {
                        Double delay = totalMilliSecondsTime - elapsed.TotalMilliseconds;

                        try
                        {
                            Thread.Sleep((int)delay);
                        }
                        catch { }
                    }
                    else
                    {

                        dataUltimaExecucao = DateTime.Now;

                        NFeUtils.GeraHeartBeat(true, empresa);

                        oFuncao.DoOnLoop(false, "");
                    }

                }

                oTh.executando = false;
                oTh.DoOnStop(null, new StatusEventArgs() { empresa = empresa });
                oFuncao.CriaLog(997, "Serviço de monitoramento paralizado com sucesso.");
            }
            catch (Exception ex)
            {
                ExceptionEventArgs ev = new ExceptionEventArgs();
                ev.error = ex;
                oTh.DoOnError(null, ev);
            }
            finally
            {
                oFuncao = null;
                oTh.executando = false;
                oTh.finalizado = true;
                Conexao.DisposeManager(manager);
            }
        }


        public static void ImprimeDANFe(NotaFiscal oNotaProc, Parametro oParam, ClientEnvironment manager)
        {
            String nomeArquivo = oNotaProc.nProt + "_v2.00-procNFe.xml";
            NFeUtils.GeraArquivoProcNFe(oNotaProc, oParam.pastaSaida + nomeArquivo, oParam.versaoDados);

            if (!File.Exists(oParam.pastaSaida + nomeArquivo))
                throw new Exception("Não foi possivel localizar arquivo de processo : " + oParam.pastaSaida + nomeArquivo);

            File.Copy(oParam.pastaSaida + nomeArquivo, oParam.pastaImpressao + nomeArquivo, true);

            oNotaProc.codigoSituacao = TipoSituacaoNota.Impressa;// 15;//impressa
            oNotaProc.descricaoSituacao = "Nota Impressa";
            oNotaProc.dataSituacao = DateTime.Now;

            oNotaProc.Save(manager);
        }

        /// <summary>
        /// gera arquivo de divulgacao da nfe
        /// NfeProc
        /// NfeProc-NFe
        /// NfeProc-ProtNFe
        /// </summary>
        /// <param name="oNotaAprovada"></param>
        /// <param name="nomeArquivo"></param>
        /// <param name="versaoDados"></param>
        public static void GeraArquivoProcNFe(NotaFiscal oNotaAprovada, string nomeArquivo, string versaoDados)
        {
            if (String.IsNullOrEmpty(oNotaAprovada.xmlNota) ||
                String.IsNullOrEmpty(oNotaAprovada.xmlProcesso))
            {
                throw new Exception("XML Nota ou XML Aprovação não existe");
            }

            ITNfeProc oNFeProc = (ITNfeProc)Servicos.XMLFactory(oNotaAprovada.versao, "TNfeProc");
            oNFeProc.versao = versaoDados;
            oNFeProc.NFe = (ITNFe)Servicos.CarregaXML_STR(oNotaAprovada.xmlNota, oNotaAprovada.versao, "TNFe");
            oNFeProc.protNFe = (ITProtNFe)Servicos.CarregaXML_STR(oNotaAprovada.xmlProcesso, oNotaAprovada.versao, "TProtNFe");

            if (File.Exists(nomeArquivo))
                File.Delete(nomeArquivo);

            Servicos.SalvaXML(nomeArquivo, oNFeProc);
        }

        /// <summary>
        /// gera arquivo de divulgacao do cancelamento da nfe
        /// ProcCancNFe
        /// ProcCancNFe-cancNFe
        /// ProcCancNFe-retCancNFe
        /// </summary>
        /// <param name="oNotaCancelada"></param>
        /// <param name="nomeArquivo"></param>
        /// <param name="versaoDados"></param>
        public static void GeraArquivoProcCancNFe(NotaFiscal oNotaCancelada, string nomeArquivo, string versaoDados)
        {
            if (String.IsNullOrEmpty(oNotaCancelada.xmlPedidoCancelamento) ||
                String.IsNullOrEmpty(oNotaCancelada.xmlProcessoCancelamento))
            {
                throw new Exception("XML Pedido ou XML Aprovação do Cancelamento não existe");
            }

            ITProcCancNFe oCancProc = (ITProcCancNFe)Servicos.XMLFactory(oNotaCancelada.versao, "TProcCancNFe");
            oCancProc.versao = versaoDados;
            oCancProc.cancNFe = (ITCancNFe)Servicos.CarregaXML_STR(oNotaCancelada.xmlPedidoCancelamento, oNotaCancelada.versao, "TCancNFe");
            oCancProc.retCancNFe = (ITRetCancNFe)Servicos.CarregaXML_STR(oNotaCancelada.xmlProcessoCancelamento, oNotaCancelada.versao, "TRetCancNFe");

            if (File.Exists(nomeArquivo))
                File.Delete(nomeArquivo);

            Servicos.SalvaXML(nomeArquivo, oCancProc);
        }

        /// <summary>
        /// gera arquivo de divulgacao do registro de evento da nfe
        /// ProcEvento
        /// ProcEvento-evento
        /// ProcEvento-retEvento
        /// </summary>
        /// <param name="oEvento"></param>
        /// <param name="nomeArquivo"></param>
        /// <param name="versaoDados"></param>
        public static void GeraArquivoProcEventoNFe(Evento oEvento, string nomeArquivo, VersaoNFe versao)
        {
            if (String.IsNullOrEmpty(oEvento.XMLPedido) ||
               String.IsNullOrEmpty(oEvento.XMLResposta))
            {
                throw new Exception("XML Pedido ou XML Aprovação do Evento não existe");
            }

            var versaoDados = string.Empty;


            //gerar evento
            ITProcEvento oProcEvento = (ITProcEvento)Servicos.XMLFactory(versao, "TProcEvento");
            oProcEvento.versao = "1.00";
            oProcEvento.evento = (ITEvento)Servicos.CarregaXML_STR(oEvento.XMLPedido, versao, "TEvento");
            oProcEvento.retEvento = ((ITRetEnvEvento)Servicos.CarregaXML_STR(oEvento.XMLResposta, versao, "TRetEnvEvento")).retEvento[0];

            if (File.Exists(nomeArquivo))
                File.Delete(nomeArquivo);

            Servicos.SalvaXML(nomeArquivo, oProcEvento);

        }

        public static void GeraHeartBeat(bool emExecucao, string empresa)
        {
            RDI.NFe2.SchemaXML.TIntegracao oIntegracao = new RDI.NFe2.SchemaXML.TIntegracao();
            oIntegracao = new RDI.NFe2.SchemaXML.TIntegracao();
            oIntegracao.versao = TIntegracaoVersao.Item100;
            oIntegracao.item = new RDI.NFe2.SchemaXML.THeartBeat();
            ((RDI.NFe2.SchemaXML.THeartBeat)oIntegracao.item).horario = DateTime.Now;

            if (emExecucao)
            {
                ((RDI.NFe2.SchemaXML.THeartBeat)oIntegracao.item).emExecucao = RDI.NFe2.SchemaXML.TSimNao.Sim;
                ((RDI.NFe2.SchemaXML.THeartBeat)oIntegracao.item).horarioExecucao = DateTime.Now;
                ((RDI.NFe2.SchemaXML.THeartBeat)oIntegracao.item).horarioExecucaoSpecified = true;
            }
            else
            {
                ((RDI.NFe2.SchemaXML.THeartBeat)oIntegracao.item).emExecucao = RDI.NFe2.SchemaXML.TSimNao.Nao;
            }

            Servicos.SalvaXML("heartbeat_" + empresa + ".xml", oIntegracao, "http://www.rochadigital.com/opennfe");
        }


        public static void RemoveHeartBeat()
        {
            try
            {
                if (File.Exists("heartbeat.xml"))
                    File.Delete("heartbeat.xml");
            }
            catch { }
        }


        public static TCodUfIBGE DefineUF(String UF)
        {
            try
            {
                return (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), UF);
            }
            catch
            {
                throw new Exception("UF inválida");
            }
        }

        public static Enum DefineEnum(String value, Type EnumType)
        {
            foreach (FieldInfo field in EnumType.GetFields())
            {
                foreach (XmlEnumAttribute atr in field.GetCustomAttributes(typeof(XmlEnumAttribute), false))
                    if (atr.Name == value)
                        return (Enum)field.GetValue(atr);
            }
            throw new Exception("Item inexistente na listagem do tipo enumerado.");
        }


        //Função para cálculo de dígito verificador base 11 com resultado alfanumérico
        private static String DvBase11(String Numero)
        {
            try
            {

                Int32 Dv, Multiplicador;
                Multiplicador = 2;
                Dv = 0;
                for (Int32 I = Numero.Length - 1; I >= 0; I--)
                {
                    Dv += (Int32.Parse(Numero[I].ToString()) * Multiplicador);
                    Multiplicador++;
                    if (Multiplicador > 9)
                        Multiplicador = 2;
                }
                Dv = Dv % 11;
                if (Dv > 1)
                    return (11 - Dv).ToString();
                else
                    return "0";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na geração da chave de acesso." + ex.Message);
            }


        }

        public static TipoSituacaoNota AssinaXML(String arqxml, String SUri, X509Certificate2 cert, VersaoNFe versao)
        {
            string _stringXml;
            string newArqXml;
            var stType = string.Empty;

            if (SUri == "infNFe")
            {
                stType = "TNFe";
                newArqXml = arqxml.Substring(0, arqxml.Length - 51) + "ass" + arqxml.Substring(arqxml.Length - 51, 51);
            }
            else if (SUri == "infCanc")
            {
                stType = "TCancNFe";
                newArqXml = arqxml.Substring(0, arqxml.Length - 7) + "-ped-can.xml";
            }
            else if (SUri == "infInut")
            {
                stType = "TInutNFe";
                newArqXml = arqxml.Substring(0, arqxml.Length - 7) + "-ped-inu.xml";
            }
            else if (SUri == "infEvento")
            {
                stType = "TEvento";
                newArqXml = arqxml.Substring(0, arqxml.Length - 7) + "-ass-env.xml";
            }
            else
            {
                return TipoSituacaoNota.RefURiNaoExiste;// 4; //erro refURi
            }


            //Verifica se arquivo da nota Existe;
            if (File.Exists(arqxml))
            {
                _stringXml = Servicos.GetXML(Servicos.CarregaXML_HD(arqxml, versao, stType));

                // realiza assinatura
                AssinaturaDigital AD = new AssinaturaDigital();
                TipoSituacaoNota resultado = AD.Assinar(_stringXml, SUri, cert);

                //limpar certificado
                cert.Reset();

                //assinatura bem sucedida
                if (resultado == TipoSituacaoNota.Assinada)
                {
                    if (File.Exists(newArqXml))
                        File.Delete(newArqXml);

                    Servicos.SalvaXML(newArqXml, (Servicos.CarregaXML_STR(AD.XMLStringAssinado, versao, stType)));


                }

                return resultado; //Retorna o resultado da assinatura
            }
            else
                return TipoSituacaoNota.ArquivoNaoEncontrado;// 11;//Arquivo nao encontrado
        }

        private static string GetAmbWebService(Parametro oParam, TServico tipoServico)
        {
            String ambiente = string.Empty;

            if (oParam.NFCe)
            {
                //oParam.NFCe [HNC|PNC].[AtendidoPor].***
                if (oParam.tipoAmbiente == TAmb.Homologacao)
                    ambiente = "HNC.";
                else if (oParam.tipoAmbiente == TAmb.Producao)
                    ambiente = "PNC.";
                else
                    throw new Exception("Tipo de Ambiente não definido.");
            }
            else
            {

                if ((tipoServico == TServico.Autorizacao || tipoServico == TServico.RetAutorizacao) && oParam.versao != VersaoNFe.v310)
                    throw new ArgumentException("V200 não possui Webservice de " + tipoServico.ToString());


                // HNF|PNF :  são utilizados pelos novos servicos de todas as UFs e por todos os servicos de SP e PR
                // os demais servicos utilizam [HWS|PWS]
                if ((tipoServico != TServico.Cadastro) && //Cadastro deverá usar versão 2.00
                    ( tipoServico == TServico.Autorizacao || tipoServico == TServico.RetAutorizacao
                    //particularidades
                    || (oParam.UF == TCodUfIBGE.SaoPaulo && oParam.versao == VersaoNFe.v310)
                    || (oParam.UF == TCodUfIBGE.Parana && oParam.versao == VersaoNFe.v310)
                    || (oParam.UF == TCodUfIBGE.Bahia && oParam.versao == VersaoNFe.v310 && tipoServico != TServico.RecepcaoEvento)))
                {
                    //[HNF|PNF].
                    if (oParam.tipoAmbiente == TAmb.Homologacao)
                        ambiente = "HNF.";
                    else if (oParam.tipoAmbiente == TAmb.Producao)
                        ambiente = "PNF.";
                    else
                        throw new Exception("Tipo de Ambiente não definido.");
                }
                else
                {
                    //[HWS|PWS].
                    if (oParam.tipoAmbiente == TAmb.Homologacao)
                        ambiente = "HWS.";
                    else if (oParam.tipoAmbiente == TAmb.Producao)
                        ambiente = "PWS.";
                    else
                        throw new Exception("Tipo de Ambiente não definido.");
                }
            }

            //Verificar de acordo com a UF e determinar qual webservice atende.
            if (oParam.tipoEmissao == TNFeInfNFeIdeTpEmis.ContingenciaSVCAN ||
                oParam.tipoEmissao == TNFeInfNFeIdeTpEmis.ContingenciaSVCRS)
            {
                //[SVC_AtendidoPor]oParam.UF.GetType().GetField(oParam.UF.ToString()).GetCustomAttributes(typeof(
                foreach (SVC_AtendidoPor atr in
                    oParam.UF.GetType().GetField(oParam.UF.ToString()).GetCustomAttributes(typeof(SVC_AtendidoPor), false))
                {
                    if (String.IsNullOrEmpty(atr.value))
                        throw new Exception("UF não esta sendo atendida por nenhum WebService do SVC.");

                    ambiente += atr.value;
                }
            }
            else if (oParam.tipoEmissao == TNFeInfNFeIdeTpEmis.ContigenciaSCAN)
            {
                ambiente += "SCAN";
            }
            else
            {
                //[AtendidoPor]oParam.UF.GetType().GetField(oParam.UF.ToString()).GetCustomAttributes(typeof(
                foreach (AtendidoPor atr in oParam.UF.GetType().GetField(oParam.UF.ToString()).GetCustomAttributes(typeof(AtendidoPor), false))
                {
                    if (String.IsNullOrEmpty(atr.value))
                        throw new Exception("UF não esta sendo atendida por nenhum WebService.");

                    ambiente += atr.value;
                }
            }
            return ambiente;

        }

        private static Assembly GetMyAssembly()
        {
            //todo : melhorar implementacao
            return typeof(FuncaoAutomacao).Assembly;
        }

        public static System.Web.Services.Protocols.SoapHttpClientProtocol ClientProxyFactory(
            Parametro oParam,
            TServico TipoServico)
        {

            String ClassName = "";
            try
            {

                string nomeClasse = string.Empty;
                //buscar nome do metodo pelo tServico
                foreach (ClasseServico atr in TipoServico.GetType().GetField(TipoServico.ToString()).GetCustomAttributes(typeof(ClasseServico), false))
                {
                    if (String.IsNullOrEmpty(atr.value))
                        throw new Exception("Serviço não esta associado com nenhuma classe cliente.");
                    nomeClasse = atr.value;
                }

                //particularidades
                if (oParam.UF == TCodUfIBGE.Bahia && TipoServico == TServico.Status && oParam.versao == VersaoNFe.v310)
                    nomeClasse = "NfeStatusServico";

                if (oParam.UF == TCodUfIBGE.Bahia && TipoServico == TServico.Consulta && oParam.versao == VersaoNFe.v310)
                    nomeClasse = "NfeConsulta";

                if (oParam.UF == TCodUfIBGE.Bahia && TipoServico == TServico.Inutilizacao && oParam.versao == VersaoNFe.v310)
                    nomeClasse = "NfeInutilizacao";


                ClassName =
                    "RDI.NFe2.Business."
                    + GetAmbWebService(oParam, TipoServico) + "."
                    + TipoServico.ToString() + ".";

                String headerClassName = ClassName + "nfeCabecMsg";
                ClassName += nomeClasse;

                Type classType = GetMyAssembly().GetType(ClassName);

                if (classType == null)
                    throw new Exception("Não foi possível definir o tipo do cliente de webservice. #ClientProxyFactory");

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico =
                    (System.Web.Services.Protocols.SoapHttpClientProtocol)System.Activator.CreateInstance(classType);

                #region Instancia cabecalho

                Type headerClassType = GetMyAssembly().GetType(headerClassName);

                System.Web.Services.Protocols.SoapHeader oCabecalho =
                    (System.Web.Services.Protocols.SoapHeader)System.Activator.CreateInstance(headerClassType);

                oCabecalho.GetType().GetProperty("cUF").SetValue(oCabecalho,
                    ((System.Xml.Serialization.XmlEnumAttribute)oParam.UF.GetType().GetField(
                        oParam.UF.ToString()).GetCustomAttributes(
                            typeof(System.Xml.Serialization.XmlEnumAttribute), false)[0]).Name,
                                                                 null);
                string versao = oParam.versaoDados;

                //particularidade para ConsSitNFe usando v200
                if (TipoServico == TServico.Consulta && oParam.versao == VersaoNFe.v200)
                    versao = "2.01";

                //Particularidade para RecepcaoEvento
                if (TipoServico == TServico.RecepcaoEvento)
                    versao = oParam.versaoDadosEventos;

                //particularidade para consultaCadastro
                if (TipoServico == TServico.Cadastro)
                    versao = "2.00";

                oCabecalho.GetType().GetProperty("versaoDados").SetValue(oCabecalho, versao, null);
                oServico.GetType().GetProperty("nfeCabecMsgValue").SetValue(oServico, oCabecalho, null);
                #endregion

                return oServico;
            }
            catch (Exception ex)
            {
                throw new Exception("ClientProxyFactory : não foi possível criar o cliente (" + ClassName + ") para acesso aos webservices da SEFAZ.", ex);
            }
        }

        public static string ValidacaoXML(String xml, String xsd)
        {
            ValidaXML oValidador = new ValidaXML();
            return oValidador.Validar(xml, xsd);
        }

        public static string RetiraAcentos(String retornoMsg)
        {
            retornoMsg = retornoMsg.Replace("ç", "c").Replace("Ç", "C").Replace("Ò", "O").Replace("ò", "o");
            retornoMsg = retornoMsg.Replace("ã", "a").Replace("Ã", "A").Replace("ö", "o").Replace("Ö", "O");
            retornoMsg = retornoMsg.Replace("é", "e").Replace("É", "E").Replace("à", "a").Replace("À", "A");
            retornoMsg = retornoMsg.Replace("í", "i").Replace("Í", "I").Replace("ì", "i").Replace("Ì", "i");
            retornoMsg = retornoMsg.Replace("õ", "o").Replace("Õ", "O").Replace("ó", "o").Replace("Ó", "O");
            retornoMsg = retornoMsg.Replace("ú", "u").Replace("Ú", "U").Replace("ù", "u").Replace("Ù", "U");
            retornoMsg = retornoMsg.Replace("ü", "u").Replace("Ü", "U").Replace("ä", "a").Replace("Ä", "A");
            retornoMsg = retornoMsg.Replace("á", "a").Replace("Á", "A").Replace("è", "e").Replace("È", "E");
            return retornoMsg;
        }

        public static String ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }

        public static IList Listar(Type tipo)
        {
            var lista = new List<KeyValuePair<int, string>>();
            if (tipo != null)
            {
                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                {
                    lista.Add(new KeyValuePair<int, String>(Convert.ToInt32(valor), ObterDescricao(valor)));
                }
            }

            lista.Sort(CompareKeyPair);
            return lista;
        }

        static int CompareKeyPair(KeyValuePair<int, string> a, KeyValuePair<int, string> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        private static void AddNode(System.Xml.XmlNode inXmlNode, System.Windows.Forms.TreeNode inTreeNode)
        {
            System.Xml.XmlNode xNode;
            System.Windows.Forms.TreeNode tNode;
            System.Xml.XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new System.Windows.Forms.TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        public static void PopulaTreeView(System.Xml.XmlDocument xmlDoc, System.Windows.Forms.TreeView TreeXML)
        {
            PopulaTreeView(xmlDoc, TreeXML, false);
        }

        public static void PopulaTreeView(System.Xml.XmlDocument xmlDoc, System.Windows.Forms.TreeView TreeXML, bool Expande)
        {
            try
            {

                // SECTION 2. Initialize the TreeView control.
                TreeXML.Nodes.Clear();
                TreeXML.Nodes.Add(new System.Windows.Forms.TreeNode(xmlDoc.DocumentElement.Name));
                System.Windows.Forms.TreeNode tNode = new System.Windows.Forms.TreeNode();
                tNode = TreeXML.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(xmlDoc.DocumentElement, tNode);
                if (Expande)
                    TreeXML.ExpandAll();
            }
            catch (System.Xml.XmlException xmlEx)
            {
                System.Windows.Forms.MessageBox.Show(xmlEx.Message);
            }
        }

        public static void AddToFile(string contents, Boolean canLog, String FileName)
        {
            if (canLog)
            {
                String pathPFileName = AppDomain.CurrentDomain.BaseDirectory + FileName;

                while (IsFileOpen(pathPFileName))
                { }

                FileStream fs = null;

                if (File.Exists(FileName))
                {
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FileName, FileMode.Open, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FileName, FileMode.Open, FileAccess.Write);
                }

                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now + " : " + contents);
                sw.Flush();
                sw.Close();
            }
        }

        private static bool IsFileOpen(string filePath)
        {
            bool fileOpened = false;
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenWrite(filePath);
                fs.Close();
            }
            catch
            {
                fileOpened = true;
            }

            return fileOpened;
        }
    }
}
