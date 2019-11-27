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
    public partial class RelatorioEmAberto : Form
    {
        public RelatorioEmAberto()
        {
            InitializeComponent();
        }

        private void RelatorioEmAberto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'RancheirosDataSet1.Relatorio_emAberto' table. You can move, or remove it, as needed.
            this.Relatorio_emAbertoTableAdapter.Fill(this.RancheirosDataSet1.Relatorio_emAberto);
            // TODO: This line of code loads data into the 'RancheirosDataSet.Pagamentos' table. You can move, or remove it, as needed.
            this.PagamentosTableAdapter.Fill(this.RancheirosDataSet.Pagamentos);

            this.reportViewer1.RefreshReport();
        }
    }
}
