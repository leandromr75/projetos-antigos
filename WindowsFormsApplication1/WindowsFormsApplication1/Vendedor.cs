using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class Vendedor
    {
        static string vendedor;

        public static string NomeVendedor
        {
            get
            {
                return vendedor;
            }
            set
            {
                vendedor = value;
            }
        }
    }
}
