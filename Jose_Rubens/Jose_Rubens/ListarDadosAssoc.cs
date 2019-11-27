using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jose_Rubens
{
    public partial class ListarDadosAssoc : Form
    {
        public ListarDadosAssoc()
        {
            InitializeComponent();
        }

        private void ListarDadosAssoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'RancheirosDataSet3.Listar_Associados' table. You can move, or remove it, as needed.
            this.Listar_AssociadosTableAdapter.Fill(this.RancheirosDataSet3.Listar_Associados);

            this.reportViewer1.RefreshReport();
        }
    }
}
