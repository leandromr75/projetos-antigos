using System;
using System.Collections.Generic;
using System.Text;
using RDI.Lince;

namespace RDI.NFe2.ORMAP
{
    public interface ILog 
    {
        Decimal numero
        {
            get;
            set;
        }

        String empresa
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

        DateTime data
        {
            get;
            set;
        }

        INotaFiscal nota
        {
            get;
            set;
        }
        
        String chaveNota
        {
            get;
        }
    }

    public interface ILogDAL
    {
        ILogDAL Instance
        {
            get;
        }
    }

    public interface ILogQRY 
    {
        Boolean FilterByDate
        {
            get ;
            set ;
        }

        String chaveNota
        {
            get ;
            set ;
        }
        String empresa
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
    }
}
