using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FT_Comercio
{
    public partial class Pesq : Form
    {
        public Pesq()
        {
            InitializeComponent();
        }

        private void Pesq_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'FTDataSet2.Listar_Relat' table. You can move, or remove it, as needed.
            this.Listar_RelatTableAdapter.Fill(this.FTDataSet2.Listar_Relat);

            this.reportViewer1.RefreshReport();
        }

        private void Pesq_FormClosed(object sender, FormClosedEventArgs e)
        {
            //altera coluna Estado de "Aguardando" p/ "OK"
            Dal.Relat();
        }
    }
}
