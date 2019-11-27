using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using RDI.NFe2.SchemaXML;

public interface IUtilitario
{
    String GetUltimaValidacao();

    void SetUtilitario_v1(String nomeCertificado, Boolean ContaComputador, Boolean Producao, Boolean TpEmisNormal, String UF);
    void SetUtilitario_v2(String nomeCertificado, Boolean ContaComputador, Boolean Producao, Boolean TpEmisNormal, String UF, int versao);
    void SetUtilitario_v3(String nomeCertificado, Boolean ContaComputador, Boolean Producao, Boolean TpEmisNormal, String UF, Boolean NFCe, int versao);
    
        
    /// <summary>
    /// abre um dialogo para que o certificado possa ser selecionado pelo usuario
    /// </summary>
    /// <param name="ContaComputador">true - busca certificado em LocalMachine; false - busca certificado em CurrentUser</param>
    /// <returns>se encontrado - subject do certificado; senao -  String.Empty</returns>
    string BuscaCertificados(String valor);


    /// <summary>
    /// Assina um arquivo XML de acordo com a uri recebida como parametro.
    /// </summary>
    /// <param name="nomeCertificado">Subject do Certificado que será utilizado na assinatura do arquivo XML</param>
    /// <param name="caminhoArquivoOrigem">Origem do arquivo XML</param>
    /// <param name="uri">Uri que será assinada</param>
    /// <param name="caminhoArquivoDestino">Destino do arquivo XML</param>
    /// <param name="ContaComputador">true - busca certificado em LocalMachine; false - busca certificado em CurrentUser</param>
    /// <returns> 0 - assinado com sucesso
    ///  1 - Erro: Problema ao acessar o certificado digital - %exceção%
    ///extinto  2 - Problemas no certificado digital
    ///  3 - XML mal formado + exceção
    ///  4 - A tag de assinatura %RefUri% inexiste
    ///  5 - A tag de assinatura %RefUri% não é unica
    ///extinto  6 - Erro Ao assinar o documento - ID deve ser string %RefUri(Atributo)%
    ///  7 - Erro: Ao assinar o documento - %exceção%
    /// 11 - arquivo de origem nao existe</returns>
    int AssinaXMLHD(String caminhoArquivoOrigem, String uri,
                        String caminhoArquivoDestino);

    String AssinaXMLST(String ArquivoOrigem, String uri);

    String ValidaXML(String caminhoXML, String caminhoXSD);

    void DefineNomeCertificado(String NomeCertificado);

    void DefineContaComputador(Boolean ContaComputador);

    void DefineProxy(String usuario, String senha, String dominio, String url);

    void SetProxy(Boolean habilita);
    

    //carregando do HD
    Boolean RecepcaoNFe2HD(String caminhoArquivoEnviNFe2, String caminhoArquivoRetEnviNFe2);

    Boolean RetRecepcaoNFe2HD(String caminhoArquivoConsReciNFe2, String caminhoArquivoRetConsReciNFe2);

    


    Boolean InutilizaNFe2HD(String caminhoArquivoInutNFe2, String caminhoArquivoRetInutNFe2);

    Boolean StatusWebServiceHD(String caminhoArquivoRetConsStatServ);

    //passando xml via string
    String RecepcaoNFe2ST(String ArquivoEnviNFe2);

    String RetRecepcaoNFe2ST(String ArquivoConsReciNFe2);

    


    String InutilizaNFe2ST(String ArquivoInutNFe2);



    Boolean StatusWebServiceST();


    //carregando do HD
    Boolean RecepcaoEventoHD(String caminhoArquivoEnvEvento, String caminhoArquivoRetEnvEvento);

    Boolean ConsultaSituacao201NFeHD(String caminhoArquivoConsSitNFe, String caminhoArquivoRetConsSitNFe);

    //passando xml via string
    String RecepcaoEventoST(String ArquivoEnvEvento);

    String ConsultaSituacao201NFeST(String ArquivoConsSitNFe);
}
