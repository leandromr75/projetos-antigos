using System;
using System.Collections.Generic;
using System.Text;
using RDI.Lince;
using RDI.NFe2.SchemaXML200;
using RDI.NFe2.SchemaXML;


namespace RDI.NFe2.ORMAP
{
    public interface IServicoPendente 
    {
        Boolean erroEnvio
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
        String empresa
        {
            get;
            set;
        }
        Int32 numeroLote
        {
            get;
            set;
        }
        TipoSituacaoServico codigoSituacao
        {
            get;
            set;
        }
        DateTime dataSituacao
        {
            get;
            set;
        }
        String numeroRecibo
        {
            get;
            set;
        }
        String xmlRecibo
        {
            get;
            set;
        }
        String xmlRetConsulta
        {
            get;
            set;
        }
    }

    public interface IServicoPendenteDAL
    {
        IServicoPendenteDAL Instance
        {
            get;
        }
    }

    public interface IServicoPendenteQry
    {
        Boolean FilterByDate
        {
            get;
            set;
        }

        DateTime dataInicial
        {
            get;
            set;
        }
        DateTime dataFinal
        {
            get;
            set;
        }
        String empresa
        {
            get;
            set;
        }
        String numeroLote
        {
            get;
            set;
        }
        String codigoSituacao
        {
            get;
            set;
        }
        String numeroRecibo
        {
            get;
            set;
        }
    }
}
