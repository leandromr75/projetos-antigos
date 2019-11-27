using System;
using System.Collections.Generic;
using System.Text;
using RDI.Lince;
using System.Net;
using RDI.NFe2.SchemaXML200;
using RDI.NFe2.SchemaXML;

namespace RDI.NFe2.ORMAP
{
    public interface IParametro 
    {
        String versaoDados
        {
            get;
        }
        String prxUrl
        {
            get;
            set;
        }
        String prxUsr
        {
            get;
            set;
        }
        String prxPsw
        {
            get;
            set;
        }
        String prxDmn
        {
            get;
            set;
        }
        TCodUfIBGE UF
        {
            get;
            set;
        }
        TAmb tipoAmbiente
        {
            get;
            set;
        }
        TNFeInfNFeIdeTpEmis tipoEmissao
        {
            get;
            set;
        }
        Boolean prx
        {
            get;
            set;
        }
        String pastaEntrada
        {
            get;
            set;
        }
        String pastaSaida
        {
            get;
            set;
        }
        String pastaRecibo
        {
            get;
            set;
        }
        String pastaImpressao
        {
            get;
            set;
        }
        String pastaXSD
        {
            get;
            set;
        }
        Int32 qtdeNotasPorLotes
        {
            get;
            set;
        }
        Int32 tempoParaLote
        {
            get;
            set;
        }
        Int32 tamMaximoLoteKB
        {
            get;
            set;
        }
        Delay timeout
        {
            get;
            set;
        }
        String empresa
        {
            get;
            set;
        }
        String certificado
        {
            get;
            set;
        }
        Boolean usaWService
        {
            get;
            set;
        }
    }

    public interface IParametroDAL 
    {
        IParametroDAL Instance
        {
            get;
        }
    }

    public interface IParametroQRY
    {
        String empresa
        {
            get;
            set;
        }
    }
}
