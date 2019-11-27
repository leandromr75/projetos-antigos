using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using RDI.Lince;


namespace RDI.NFe2.ORMAP
{
    public interface INotaInutilizada 
    {
        String empresa
        {
            get;
            set;
        }
        String numeroNota
        {
            get;
            set;
        }
        String serieNota
        {
            get;
            set;
        }
        DateTime data
        {
            get;
            set;
        }
        String XMLPedido
        {
            get;
            set;
        }
        String XMLResposta
        {
            get;
            set;
        }        
    }

    public interface INotaInutilizadaDAL 
    {
        INotaInutilizadaDAL Instance
        {
            get;
        }
    }

    public interface INotaInutilizadaQry
    {
        Boolean FilterByDate
        {
            get;
            set;
        }
        String numeroNota
        {
            get;
            set;
        }
        String serieNota
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
