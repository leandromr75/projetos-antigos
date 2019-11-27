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
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'RancheirosDataSet2.Relatorio' table. You can move, or remove it, as needed.
            this.RelatorioTableAdapter.Fill(this.RancheirosDataSet2.Relatorio);
            // TODO: This line of code loads data into the 'RancheirosDataSet1.Relatorio_emAberto' table. You can move, or remove it, as needed.
            this.Relatorio_emAbertoTableAdapter.Fill(this.RancheirosDataSet1.Relatorio_emAberto);

            this.reportViewer1.RefreshReport();
        }
    }
}
