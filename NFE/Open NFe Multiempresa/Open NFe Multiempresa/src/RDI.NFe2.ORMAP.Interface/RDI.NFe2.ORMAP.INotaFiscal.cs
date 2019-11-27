using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using RDI.Lince;


namespace RDI.NFe2.ORMAP
{
    public interface INotaFiscal 
    {
        String cStat
        {
            get;
            set;
        }
        String xMotivo
        {
            get;
            set;
        }
        String empresa
        {
            get;
            set;
        }
        String chaveNota
        {
            get;
            set;
        }
        Int32 numeroLote
        {
            get;
            set;
        }
        Int32 codigoSituacao
        {
            get;
            set;
        }
        String descricaoSituacao
        {
            get;
            set;
        }
        DateTime dataSituacao
        {
            get;
            set;
        }
        String xmlNota
        {
            get;
            set;
        }
        String xmlProcesso
        {
            get;
            set;
        }
        String nProt
        {
            get;
            set;
        }

        String xmlPedidoCancelamento
        {
            get;
            set;
        }
        String xmlProcessoCancelamento
        {
            get;
            set;
        }
        String nProtCancelamento
        {
            get;
            set;
        }
    }

    public interface INotaFiscalDAL 
    {
        INotaFiscalDAL Instance
        {
            get;         
        }
        Int32 GetMax(QueryObject queryobject, ClientEnvironment clientEnvironment);
     }

    public interface INotaFiscalQry
    {
        Boolean FilterByDate
        {
            get;
            set;
        }
        String chaveNota
        {
            get ;
            set ;
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
    }
}
