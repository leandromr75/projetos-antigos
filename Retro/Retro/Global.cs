using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Retro
{
    class Global
    {
        private static string ativo = ""; //sim,não
        public static string Pode
        {
            get { return ativo; }
            set { ativo = value; }
        }
    }
}
