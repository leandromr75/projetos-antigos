using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Collections;
using System.ComponentModel;
using RDI.NFe2.SchemaXML;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
using System.Net;
using System.Net.Cache;
using System.Runtime.Serialization;
using System.Text;
using RDI.NFe2.ORMAP;


namespace RDI.NFe2.Business
{
    public static class Servicos
    {
        public const string NFeNAMESPACE = "http://www.portalfiscal.inf.br/nfe";



        public static string VersaoBusiness { get { return "v3.10"; } }

        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        private static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public static object XMLFactory(VersaoNFe version, string stType, int size = -1)
        {
            Type type = Factory.GetXMLType(version, stType);
            if (size == -1)
                return Activator.CreateInstance(type);
            else
                return Activator.CreateInstance(type, size);

        }

        public static object CarregaXML_HD(string filename, VersaoNFe versao, string stTipo)
        {
            String _xml = String.Empty;
            using (StreamReader SR = File.OpenText(filename))
            {
                _xml = SR.ReadToEnd();
                SR.Close();
                SR.Dispose();
            }
            GC.Collect();
            return CarregaXML_STR(_xml, versao, stTipo);
        }
        public static object CarregaXML_STR(string XML, VersaoNFe versao, string stTipo)
        {
            XmlSerializer xs = new XmlSerializer(Factory.GetXMLType(versao, stTipo));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(XML));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        }

        public static void SalvaXML(string filename, Object oXML)
        {
            SalvaXML(filename, oXML, NFeNAMESPACE);
        }
        public static void SalvaXML(string filename, Object oXML, String stNamespace)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", stNamespace);
            XmlSerializer xs = new XmlSerializer(oXML.GetType());
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new System.Text.UTF8Encoding(false));
            xs.Serialize(xmlTextWriter, oXML, xsn);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            Byte[] characters = memoryStream.ToArray();
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            StreamWriter oSW = File.CreateText(filename);
            oSW.Write(encoding.GetString(characters));
            oSW.Close();
        }

        public static String GetXML(Object oXML)
        {
            return GetXML(oXML, NFeNAMESPACE);
        }
        public static String GetXML(Object oXML, String stNamespace)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", stNamespace);
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(oXML.GetType());
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new System.Text.UTF8Encoding(false));
            xs.Serialize(xmlTextWriter, oXML, xsn);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            Byte[] characters = memoryStream.ToArray();
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(characters);
        }


        public static ITRetEnvEvento EnviarEnvelopeEvento(
             System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
             ITEnvEvento oEnvEvento, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetEnvEvento)CarregaXML_STR(ExecutaServico(oServico, oEnvEvento, oParam),
                versao, "TRetEnvEvento");
        }

        public static ITRetEnviNFe EnviarEnvelope(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            ITEnviNFe oEnviNFe, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetEnviNFe)CarregaXML_STR(ExecutaServico(oServico, oEnviNFe, oParam),
                versao, "TRetEnviNFe");
        }

        public static ITRetConsReciNFe ConsultarProcessamentoEnvelope(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            ITConsReciNFe oConsReciNFe, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetConsReciNFe)CarregaXML_STR(ExecutaServico(oServico, oConsReciNFe, oParam),
                versao, "TRetConsReciNFe");
        }

        public static ITRetConsStatServ ConsultarStatusServidor(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            ITConsStatServ oConsStatServ, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetConsStatServ)CarregaXML_STR(ExecutaServico(oServico, oConsStatServ, oParam),
                versao, "TRetConsStatServ");
        }

        public static ITRetInutNFe InutilizarNFe(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            ITInutNFe oInutNFe, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetInutNFe)CarregaXML_STR(ExecutaServico(oServico, oInutNFe, oParam),
                versao, "TRetInutNFe");
        }

        public static ITRetConsSitNFe ConsultarSituacaoNFe(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            ITConsSitNFe oConsSitNFe, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetConsSitNFe)CarregaXML_STR(ExecutaServico(oServico, oConsSitNFe, oParam),
                versao, "TRetConsSitNFe");
        }

        public static ITRetConsCad ConsultarCadastro(SoapHttpClientProtocol oServico, ITConsCad oEnviNFe3, Parametro oParam, VersaoNFe versao)
        {
            return (ITRetConsCad)CarregaXML_STR(ExecutaServico(oServico, oEnviNFe3, oParam),
                versao, "TRetConsCad");
        }


        public static void InicializaServico(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            Parametro oParam)
        {
            X509Certificate2 certificadox509;
            if (oParam.usarCertificadoDisco)
            {
                certificadox509 = Certificado.BuscaCaminho(oParam.caminhoCertificado, oParam.senhaCertificado);
            }
            else
            {
                certificadox509 = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);
            }
            oServico.ClientCertificates.Clear();
            oServico.ClientCertificates.Add(certificadox509);
            if (oParam.prx)
            {
                oServico.Proxy = new WebProxy(oParam.prxUrl, true);
                oServico.Proxy.Credentials = new NetworkCredential(oParam.prxUsr, oParam.prxPsw, oParam.prxDmn);
            }
            else
            {
                oServico.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            oServico.Timeout = (int)oParam.timeout;
            oServico.InitializeLifetimeService();

            // forçar aceitação de todos os certificados dos servidores da SEFAZ
            // independentemente de ter a cadeia de certificação instalada
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }


        private static String ExecutaServico(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            Object DADOS, Parametro oParam)
        {
            try
            {
                string dados = GetXML(DADOS);
                #region particularidades
                if (oParam.UF == TCodUfIBGE.Parana && (DADOS.GetType() == typeof(SchemaXML200.TEnviNFe)
                                                    || DADOS.GetType() == typeof(SchemaXML300.TEnviNFe)))
                {
                    dados = dados.Replace("<NFe>", "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\">");
                }
                #endregion
                XmlNode node = null;

                XmlDocument doc = new XmlDocument();
                XmlReader reader = XmlReader.Create(new StringReader(dados));
                reader.MoveToContent();

                node = doc.ReadNode(reader);

                InicializaServico(oServico, oParam);


                if (DADOS.GetType().GetInterface("ITConsCad") != null)
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("consultaCadastro2",
                                                        System.Reflection.BindingFlags.InvokeMethod,
                                                        null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType().GetInterface("ITEnvEvento") != null)
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeRecepcaoEvento",
                                                        System.Reflection.BindingFlags.InvokeMethod,
                                                        null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType().GetInterface("ITEnviNFe") != null)
                {
                    if (((ITEnviNFe)DADOS).versao == "2.00")
                    {
                        //versao 2.00

                        #region particularidades
                        if (oParam.UF == TCodUfIBGE.Parana)
                        {
                            if (oParam.tipoAmbiente == TAmb.Homologacao)
                            {
                                oServico.Url = @"https://homologacao.nfe2.fazenda.pr.gov.br/nfe/NFeRecepcao2";
                            }
                            else
                            {
                                oServico.Url = @"https://nfe2.fazenda.pr.gov.br/nfe/NFeRecepcao2";
                            }
                        }
                        #endregion

                        XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeRecepcaoLote2",
                                                            System.Reflection.BindingFlags.InvokeMethod,
                                                            null, oServico, new object[] { node });

                        return GetXML(ret);
                    }
                    else
                    {
                        //versao 3.00
                        //TODO : verificar uso de webservice sincrono
                        //var test = (SchemaXML300.TEnviNFe)DADOS;
                        //test.indSinc = SchemaXML300.TEnviNFeIndSinc.Item0;//Não indica sincrono
                        //test.indSinc = SchemaXML300.TEnviNFeIndSinc.Item1; //indica sincrono, mas depende da SEFAZ autorizadora implementar servico.

                        //***.**.Autorizacao.NfeAutorizacao proxy = new ***.**.Autorizacao.NfeAutorizacao();
                        //var ret = proxy.nfeAutorizacaoLote(node);
                        //sincrono poderá ter o Nó : TProtNFe
                        //assincrono terá o Nó : TRetEnviNFeInfRec

                        var metodo = "nfeAutorizacaoLote";

                        XmlNode ret = (XmlNode)oServico.GetType().InvokeMember(metodo,
                                                        System.Reflection.BindingFlags.InvokeMethod,
                                                        null, oServico, new object[] { node });
                        return GetXML(ret);
                    }
                }
                else if (DADOS.GetType().GetInterface("ITConsReciNFe") != null)
                {
                    if (((ITConsReciNFe)DADOS).versao == "2.00")
                    {
                        //versao 2.00

                        #region particularidades
                        if (oParam.UF == TCodUfIBGE.Parana)
                        {
                            if (oParam.tipoAmbiente == TAmb.Homologacao)
                            {
                                oServico.Url = @"https://homologacao.nfe2.fazenda.pr.gov.br/nfe/NFeRetRecepcao2";
                            }
                            else
                            {
                                oServico.Url = @"https://nfe2.fazenda.pr.gov.br/nfe/NFeRetRecepcao2";
                            }
                        }
                        #endregion

                        XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeRetRecepcao2",
                                        System.Reflection.BindingFlags.InvokeMethod,
                                        null, oServico, new object[] { node });

                        return GetXML(ret);
                    }
                    else
                    {

                        var metodo = "nfeRetAutorizacaoLote";

                        //versao 3.00 ou 3.10
                        XmlNode ret = (XmlNode)oServico.GetType().InvokeMember(metodo,
                                        System.Reflection.BindingFlags.InvokeMethod,
                                        null, oServico, new object[] { node });

                        return GetXML(ret);
                    }
                }
                else if (DADOS.GetType().GetInterface("ITConsStatServ") != null)
                {
                    var metodo = "nfeStatusServicoNF2";
                    #region particularidades
                    if (oParam.UF == TCodUfIBGE.Parana)
                    {
                        if (oParam.tipoAmbiente == TAmb.Homologacao)
                        {
                            oServico.Url = @"https://homologacao.nfe2.fazenda.pr.gov.br/nfe/NFeStatusServico2";
                        }
                        else
                        {
                            oServico.Url = @"https://nfe2.fazenda.pr.gov.br/nfe/NFeStatusServico2";
                        }
                    }

                    if (oParam.UF == TCodUfIBGE.Bahia && oParam.versao == VersaoNFe.v310)
                    {
                        metodo = "nfeStatusServicoNF";
                    }
                    #endregion

                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember(metodo,
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType().GetInterface("ITInutNFe") != null)
                {
                    var metodo = "nfeInutilizacaoNF2";
                    #region particularidades
                    if (oParam.UF == TCodUfIBGE.Parana)
                    {
                        if (oParam.tipoAmbiente == TAmb.Homologacao)
                        {
                            oServico.Url = @"https://homologacao.nfe2.fazenda.pr.gov.br/nfe/NFeInutilizacao2";
                        }
                        else
                        {
                            oServico.Url = @"https://nfe2.fazenda.pr.gov.br/nfe/NFeInutilizacao2";
                        }
                    }

                    if (oParam.UF == TCodUfIBGE.Bahia && oParam.versao == VersaoNFe.v310)
                    {
                        metodo = "nfeInutilizacaoNF";
                    }

                    #endregion

                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember(metodo,
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType().GetInterface("ITConsSitNFe") != null)
                {
                    #region particularidades
                    if (oParam.UF == TCodUfIBGE.Parana)
                    {
                        if (oParam.tipoAmbiente == TAmb.Homologacao)
                        {
                            oServico.Url = @"https://homologacao.nfe2.fazenda.pr.gov.br/nfe/NFeConsulta2";
                        }
                        else
                        {
                            oServico.Url = @"https://nfe2.fazenda.pr.gov.br/nfe/NFeConsulta2";
                        }
                    }
                    #endregion  

                    string metodo = "nfeConsultaNF2";
                    if (oParam.UF == TCodUfIBGE.Bahia && oParam.versao == VersaoNFe.v310)
                        metodo = "nfeConsultaNF";

                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember(metodo,
                                                        System.Reflection.BindingFlags.InvokeMethod,
                                                        null, oServico, new object[] { node });
                    return GetXML(ret);
                }
                else
                {
                    throw new Exception("Tipo de objeto de envio não mapeado. Consulte o administrador do Sistema.");
                }
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
                if (ex.InnerException != null)
                    msg = ex.InnerException.Message;

                throw new Exception("Erro ao executar Serviço : typeof(" + DADOS.GetType().ToString() + ")" + msg);
            }

        }

    }



}
