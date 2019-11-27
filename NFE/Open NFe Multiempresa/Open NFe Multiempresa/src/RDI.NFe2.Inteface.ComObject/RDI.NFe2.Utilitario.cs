using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using RDI.NFe2.ORMAP;
using RDI.NFe2.SchemaXML;

namespace RDI.NFe2.Business
{
    [ClassInterface(ClassInterfaceType.None)]
    public class Utilitario : IUtilitario
    {
        #region Auxiliares
        public Utilitario()
        {
        }

        public String UltimaValidacao = string.Empty;

        public void SetUtilitario_v1(String nomeCertificado, Boolean ContaComputador, Boolean Producao, Boolean TpEmisNormal, String UF)
        {
            SetUtilitario_v3(nomeCertificado, ContaComputador, Producao, TpEmisNormal, UF, false, 1);
        }

        public void SetUtilitario_v2(String nomeCertificado, Boolean ContaComputador, Boolean Producao, Boolean TpEmisNormal, String UF, int versao)
        {
            SetUtilitario_v3(nomeCertificado, ContaComputador, Producao, TpEmisNormal, UF, false, versao);
        }

        public void SetUtilitario_v3(String nomeCertificado, Boolean ContaComputador, Boolean Producao, Boolean TpEmisNormal, String UF, Boolean NFCe, int versao)
        {
            //Cria Parametro
            _Parametro = new Parametro();

            _Parametro.versao = (VersaoNFe)versao;

            _Parametro.NFCe = NFCe;

            _Parametro.prx = false;
            _Parametro.timeout = Delay.Lento;
            _Parametro.usaWService = false;
            _Parametro.tamMaximoLoteKB = 500;
            _Parametro.tempoParaLote = 10;
            _Parametro.qtdeNotasPorLotes = 10;

            _Parametro.prx = false;
            _Parametro.usarCertificadoDisco = (nomeCertificado == null ? false : nomeCertificado.Contains("|"));
            _Parametro.certificado = nomeCertificado;
            _Parametro.usaWService = ContaComputador;

            if (Producao)
                _Parametro.tipoAmbiente = TAmb.Producao;
            else
                _Parametro.tipoAmbiente = TAmb.Homologacao;


            if (TpEmisNormal)
                _Parametro.tipoEmissao = TNFeInfNFeIdeTpEmis.Normal;
            else
                _Parametro.tipoEmissao = TNFeInfNFeIdeTpEmis.ContingenciaSVCAN; //ou SVCRS. o sistema irá verificar qual é o webservice que atende a UF

            _Parametro.UF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), UF);

            var res = GeraUltimaValidacao();

            if (string.IsNullOrEmpty(res))
            {
                UltimaValidacao += (" " + res);
            }

        }

        private Parametro _Parametro;

        public String GetUltimaValidacao()
        {
            return Servicos.VersaoBusiness + " - " + UltimaValidacao;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeCertificado"></param>
        /// <param name="ContaComputador"></param>
        /// <param name="Producao"></param>
        /// <param name="TpEmisNormal"></param>
        /// <param name="UF">Ex: "31"</param>


        private string GeraUltimaValidacao()
        {
            try
            {
                UltimaValidacao = "Dll carregada com sucesso.";

                if (!String.IsNullOrEmpty(_Parametro.certificado))
                    UltimaValidacao += " Usando Certificado :" + _Parametro.certificado;
                else
                    UltimaValidacao += " Nenhum certificado selecionado";

                if (_Parametro.usaWService)
                    UltimaValidacao += " em ContaComputador.";
                else
                    UltimaValidacao += " em ContaUsuario.";

                UltimaValidacao += " Operando em " + NFeUtils.ObterDescricao(_Parametro.tipoAmbiente);

                UltimaValidacao += " Emitindo em " + NFeUtils.ObterDescricao(_Parametro.tipoEmissao);

                UltimaValidacao += " UF : " + NFeUtils.ObterDescricao(_Parametro.UF);

                UltimaValidacao += " NFCe : " + (_Parametro.NFCe ? "sim" : "nao");

                return string.Empty;
            }
            catch
                (Exception ex)
            {
                return "Erro em GeraUltimaValidacao() - " + ex.Message;
            }
        }

        public void DefineNomeCertificado(String NomeCertificado) { _Parametro.certificado = NomeCertificado; GeraUltimaValidacao(); }

        public void DefineContaComputador(Boolean ContaComputador) { _Parametro.usaWService = ContaComputador; GeraUltimaValidacao(); }

        public void DefineProxy(String usuario, String senha, String dominio, String url)
        {
            _Parametro.prxUsr = usuario;
            _Parametro.prxPsw = senha;
            _Parametro.prxUrl = url;
            _Parametro.prxDmn = dominio;
        }

        public void SetProxy(Boolean habilita)
        {
            _Parametro.prx = habilita;
        }

        public string BuscaCertificados(String valor)
        {
            if (_Parametro == null)
            {
                throw new Exception("Parametro esta nulo.");
            }

            try
            {
                X509Certificate2 oCertificado = Certificado.BuscaNome("", _Parametro.usaWService);

                if (oCertificado == null)
                {
                    throw new Exception("oCertificado esta nulo.");
                }

                return oCertificado.Subject;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return String.Empty;
            }

        }

        public int AssinaXMLHD(String caminhoArquivoOrigem, String SUri,
                            String caminhoArquivoDestino)
        {

            X509Certificate2 oCertificado = null;
            //busca o certificado digital
            try
            {
                if (_Parametro.usarCertificadoDisco)
                    oCertificado = Certificado.BuscaCaminho(_Parametro.caminhoCertificado, _Parametro.senhaCertificado);
                else
                    oCertificado = Certificado.BuscaNome(_Parametro.certificado, _Parametro.usaWService);
            }
            catch
            {
                return 1;
            }

            string _stringXml;
            string stType = string.Empty;
            VersaoNFe versao = VersaoNFe.v310;

            if (SUri == "infNFe")
            {
                stType = "TNFe";
            }
            else if (SUri == "infCanc")
            {
                if (_Parametro.NFCe)
                    throw new Exception("URI " + SUri + " não mapeada para NFCe");
                else
                    stType = "TCancNFe";
            }
            else if (SUri == "infInut")
            {
                stType = "TInutNFe";
            }
            else if (SUri == "infEvento")
            {
                stType = "TEvento";
            }
            else
            {
                return 4; //erro refURi
            }


            //Verifica se arquivo da nota Existe;
            if (File.Exists(caminhoArquivoOrigem))
            {
                #region carregar arquivo a ser assinado
                _stringXml = Servicos.GetXML(Servicos.CarregaXML_HD(caminhoArquivoOrigem, versao, stType));

                #endregion

                // realiza assinatura
                AssinaturaDigital AD = new AssinaturaDigital();
                TipoSituacaoNota resultado = AD.Assinar(_stringXml, SUri, oCertificado);

                //limpar certificado
                oCertificado.Reset();

                //assinatura bem sucedida
                if (resultado == TipoSituacaoNota.Assinada)
                {
                    if (File.Exists(caminhoArquivoDestino))
                        File.Delete(caminhoArquivoDestino);

                    Servicos.SalvaXML(caminhoArquivoDestino, (Servicos.CarregaXML_STR(AD.XMLStringAssinado, versao, stType)));
                }
                else
                {
                    UltimaValidacao = AD.mensagemResultado;
                }

                return (int)resultado; //Retorna o resultado da assinatura
            }
            else
                return 11;//Arquivo nao encontrado
        }

        public String AssinaXMLST(String ArquivoOrigem, String uri)
        {
            X509Certificate2 oCertificado = null;

            //busca o certificado digital
            try
            {
                if (_Parametro.usarCertificadoDisco)
                    oCertificado = Certificado.BuscaCaminho(_Parametro.caminhoCertificado, _Parametro.senhaCertificado);
                else
                    oCertificado = Certificado.BuscaNome(_Parametro.certificado, _Parametro.usaWService);
            }
            catch
            {
                return (1).ToString();
            }

            // realiza assinatura
            AssinaturaDigital oAssinador = new AssinaturaDigital();
            TipoSituacaoNota ret = oAssinador.Assinar(ArquivoOrigem, uri, oCertificado);
            //limpar o objeto do certificado
            oCertificado.Reset();

            //se assinatura realizada com sucesso, salva retorno
            if (ret == TipoSituacaoNota.Assinada)
            {
                return oAssinador.XMLStringAssinado;
            }
            else
            {
                UltimaValidacao = oAssinador.mensagemResultado;
            }

            oAssinador = null;

            return ret.ToString(); //Retorna o resultado da assinatura
        }
        #endregion

        #region NFe


        public Boolean RecepcaoNFe2HD(String caminhoArquivoEnviNFe2, String caminhoArquivoRetEnviNFe2)
        {
            ITEnviNFe oEnviNFe2;
            ITRetEnviNFe oRetEnviNFe2 = null;
            try
            {
                if (!File.Exists(caminhoArquivoEnviNFe2))
                    throw new Exception("Arquivo EnviNFe2 não existe ou não esta acessível.");

                try
                {
                    oEnviNFe2 = (ITEnviNFe)Servicos.CarregaXML_HD(caminhoArquivoEnviNFe2, _Parametro.versao, "TEnviNFe");
                }
                catch (Exception ex)
                {
                    string msgErro = "Não foi possível carregar o Arquivo EnviNFe2 - " + ex.Message;
                    if (ex.InnerException != null)
                        msgErro += " - Detalhe : " + ex.InnerException.Message;

                    throw new Exception(msgErro);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, _Parametro.versao == VersaoNFe.v310 ? TServico.Autorizacao : TServico.Recepcao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetEnviNFe2 = Servicos.EnviarEnvelope(oServico, oEnviNFe2, _Parametro, _Parametro.versao);

                Servicos.SalvaXML(caminhoArquivoRetEnviNFe2, oRetEnviNFe2);

                return true;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }

        public Boolean RetRecepcaoNFe2HD(String caminhoArquivoConsReciNFe2, String caminhoArquivoRetConsReciNFe2)
        {
            ITConsReciNFe oConsReciNFe2;
            ITRetConsReciNFe oRetConsReciNFe2 = null;
            try
            {
                if (!File.Exists(caminhoArquivoConsReciNFe2))
                    throw new Exception("Arquivo ConsReciNFe2 não existe ou não esta acessível.");

                try
                {
                    oConsReciNFe2 = (ITConsReciNFe)Servicos.CarregaXML_HD(caminhoArquivoConsReciNFe2, _Parametro.versao, "TConsReciNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo ConsReciNFe2 - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, _Parametro.versao == VersaoNFe.v310 ? TServico.RetAutorizacao : TServico.RetRecepcao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetConsReciNFe2 = Servicos.ConsultarProcessamentoEnvelope(oServico, oConsReciNFe2, _Parametro, _Parametro.versao);

                Servicos.SalvaXML(caminhoArquivoRetConsReciNFe2, oRetConsReciNFe2);

                return true;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }

        public Boolean InutilizaNFe2HD(String caminhoArquivoInutNFe2, String caminhoArquivoRetInutNFe2)
        {
            ITInutNFe oInutNFe2;
            ITRetInutNFe oRetInutNFe2 = null;
            try
            {
                if (!File.Exists(caminhoArquivoInutNFe2))
                    throw new Exception("Arquivo InutNFe2 não existe ou não esta acessível.");

                try
                {
                    oInutNFe2 = (ITInutNFe)Servicos.CarregaXML_HD(caminhoArquivoInutNFe2, _Parametro.versao, "TInutNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo InutNFe2 - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.Inutilizacao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetInutNFe2 = Servicos.InutilizarNFe(oServico, oInutNFe2, _Parametro, _Parametro.versao);

                Servicos.SalvaXML(caminhoArquivoRetInutNFe2, oRetInutNFe2);

                return true;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }

        public Boolean StatusWebServiceHD(String caminhoArquivoRetConsStatServ)
        {
            ITConsStatServ oConsStatServ;
            ITRetConsStatServ oRetConsStatServ = null;

            try
            {
                String hhmmss = DateTime.Now.ToString("yyMMddhhmmss");
                String caminhoArquivoConsStatServ = "oConsStatServ" + hhmmss + ".xml";

                oConsStatServ = (ITConsStatServ)Servicos.XMLFactory(_Parametro.versao, "TConsStatServ");
                oConsStatServ.cUF = _Parametro.UF;
                oConsStatServ.tpAmb = _Parametro.tipoAmbiente;
                oConsStatServ.versao = _Parametro.versaoDados;

                Servicos.SalvaXML(caminhoArquivoConsStatServ, oConsStatServ);

                if (!File.Exists(caminhoArquivoConsStatServ))
                    throw new Exception("Arquivo ConsStatServ não existe ou não esta acessível.");

                try
                {
                    oConsStatServ = (ITConsStatServ)Servicos.CarregaXML_HD(caminhoArquivoConsStatServ, _Parametro.versao, "TConsStatServ");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo ConsStatServ - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.Status);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetConsStatServ = Servicos.ConsultarStatusServidor(oServico, oConsStatServ, _Parametro, _Parametro.versao);

                Servicos.SalvaXML(caminhoArquivoRetConsStatServ, oRetConsStatServ);

                return true;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }


        public String RecepcaoNFe2ST(String ArquivoEnviNFe2)
        {
            ITEnviNFe oEnviNFe2;
            ITRetEnviNFe oRetEnviNFe2 = null;
            try
            {
                try
                {
                    oEnviNFe2 = (ITEnviNFe)Servicos.CarregaXML_STR(ArquivoEnviNFe2, _Parametro.versao, "TEnviNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo EnviNFe2 - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, _Parametro.versao == VersaoNFe.v310 ? TServico.Autorizacao : TServico.Recepcao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetEnviNFe2 = Servicos.EnviarEnvelope(oServico, oEnviNFe2, _Parametro, _Parametro.versao);

                return Servicos.GetXML(oRetEnviNFe2);
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return string.Empty;
            }
        }

        public String RetRecepcaoNFe2ST(String ArquivoConsReciNFe2)
        {
            ITConsReciNFe oConsReciNFe2;
            ITRetConsReciNFe oRetConsReciNFe2 = null;
            try
            {
                try
                {
                    oConsReciNFe2 = (ITConsReciNFe)Servicos.CarregaXML_STR(ArquivoConsReciNFe2, _Parametro.versao, "TConsReciNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo ConsReciNFe2 - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, _Parametro.versao == VersaoNFe.v310 ? TServico.RetAutorizacao : TServico.RetRecepcao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetConsReciNFe2 = Servicos.ConsultarProcessamentoEnvelope(oServico, oConsReciNFe2, _Parametro, _Parametro.versao);

                return Servicos.GetXML(oRetConsReciNFe2);
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return string.Empty;
            }
        }

        public String InutilizaNFe2ST(String ArquivoInutNFe2)
        {
            ITInutNFe oInutNFe2;
            ITRetInutNFe oRetInutNFe2 = null;
            try
            {

                try
                {
                    oInutNFe2 = (ITInutNFe)Servicos.CarregaXML_STR(ArquivoInutNFe2, _Parametro.versao, "TInutNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo InutNFe2 - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.Inutilizacao);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetInutNFe2 = Servicos.InutilizarNFe(oServico, oInutNFe2, _Parametro, _Parametro.versao);

                return Servicos.GetXML(oRetInutNFe2);

            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return string.Empty;
            }
        }

        public Boolean StatusWebServiceST()
        {
            ITConsStatServ oConsStatServ;
            ITRetConsStatServ oRetConsStatServ = null;

            try
            {
                String hhmmss = DateTime.Now.ToString("yyMMddhhmmss");
                String caminhoArquivoConsStatServ = "oConsStatServ" + hhmmss + ".xml";

                oConsStatServ = (ITConsStatServ)Servicos.XMLFactory(_Parametro.versao, "TConsStatServ");

                oConsStatServ.tpAmb = _Parametro.tipoAmbiente;
                oConsStatServ.cUF = _Parametro.UF;
                oConsStatServ.versao = _Parametro.versaoDados;

                Servicos.SalvaXML(caminhoArquivoConsStatServ, oConsStatServ);

                if (!File.Exists(caminhoArquivoConsStatServ))
                    throw new Exception("Arquivo ConsStatServ não existe ou não esta acessível.");

                try
                {
                    oConsStatServ = (ITConsStatServ)Servicos.CarregaXML_HD(caminhoArquivoConsStatServ, _Parametro.versao, "TConsStatServ");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo ConsStatServ - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.Status);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetConsStatServ = Servicos.ConsultarStatusServidor(oServico, oConsStatServ, _Parametro, _Parametro.versao);

                return (oRetConsStatServ.cStat == "107");
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }

        public String ValidaXML(String caminhoXML, String caminhoXSD)
        {
            return NFeUtils.ValidacaoXML(caminhoXML, caminhoXSD);
        }



        public Boolean RecepcaoEventoHD(String caminhoArquivoEnvEvento, String caminhoArquivoRetEnvEvento)
        {
            ITEnvEvento oEnviCCe;
            ITRetEnvEvento oRetEnviCCe;
            try
            {
                if (!File.Exists(caminhoArquivoEnvEvento))
                    throw new Exception("Arquivo EnvEvento não existe ou não esta acessível.");

                try
                {
                    oEnviCCe = (ITEnvEvento)Servicos.CarregaXML_HD(caminhoArquivoEnvEvento, _Parametro.versao, "TEnvEvento");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo EnvEvento - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.RecepcaoEvento);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetEnviCCe = Servicos.EnviarEnvelopeEvento(oServico, oEnviCCe, _Parametro, _Parametro.versao);

                Servicos.SalvaXML(caminhoArquivoRetEnvEvento, oRetEnviCCe);

                return true;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }

        public Boolean ConsultaSituacao201NFeHD(String caminhoArquivoConsSitCCe, String caminhoArquivoRetConsSitCCe)
        {
            ITConsSitNFe oConsSitCCe;
            ITRetConsSitNFe oRetConsSitCCe;
            try
            {
                if (!File.Exists(caminhoArquivoConsSitCCe))
                    throw new Exception("Arquivo ConsSitCCe não existe ou não esta acessível.");

                try
                {
                    oConsSitCCe = (ITConsSitNFe)Servicos.CarregaXML_HD(caminhoArquivoConsSitCCe, _Parametro.versao, "TConsSitNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo ConsSitCCe - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.Consulta);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetConsSitCCe = Servicos.ConsultarSituacaoNFe(oServico, oConsSitCCe, _Parametro, _Parametro.versao);

                Servicos.SalvaXML(caminhoArquivoRetConsSitCCe, oRetConsSitCCe);

                return true;
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return false;
            }
        }

        public String RecepcaoEventoST(String ArquivoEnvEvento)
        {
            ITEnvEvento oEnviCCe;
            ITRetEnvEvento oRetEnviCCe;
            try
            {
                try
                {
                    oEnviCCe = (ITEnvEvento)Servicos.CarregaXML_STR(ArquivoEnvEvento, _Parametro.versao, "TEnvEvento");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo EnvEvento - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.RecepcaoEvento);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetEnviCCe = Servicos.EnviarEnvelopeEvento(oServico, oEnviCCe, _Parametro, _Parametro.versao);

                return Servicos.GetXML(oRetEnviCCe);
            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return string.Empty;
            }
        }

        public String ConsultaSituacao201NFeST(String ArquivoConsSitNFe)
        {
            ITConsSitNFe oConsSitCCe;
            ITRetConsSitNFe oRetConsSitCCe;
            try
            {
                try
                {
                    oConsSitCCe = (ITConsSitNFe)Servicos.CarregaXML_STR(ArquivoConsSitNFe, _Parametro.versao, "TConsSitNFe");
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível carregar o Arquivo ConsSitNFe - " + ex.Message);
                }

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = null;
                try
                {
                    oServico = NFeUtils.ClientProxyFactory(_Parametro, TServico.Consulta);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar o serviço de comunicação com o webservice - " + ex.Message);
                }

                oRetConsSitCCe = Servicos.ConsultarSituacaoNFe(oServico, oConsSitCCe, _Parametro, _Parametro.versao);

                return Servicos.GetXML(oRetConsSitCCe);

            }
            catch (Exception ex)
            {
                UltimaValidacao = ex.Message;
                return string.Empty;
            }
        }
        #endregion
    } //fim - classe

}//fim - namespace
