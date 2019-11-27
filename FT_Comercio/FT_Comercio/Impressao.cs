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
    public partial class Impressao : Form
    {
        public Impressao()
        {
            InitializeComponent();
        }

        private void Impressao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'FTDataSet2.Listar_Relat' table. You can move, or remove it, as needed.
            this.Listar_RelatTableAdapter.Fill(this.FTDataSet2.Listar_Relat);
            // TODO: This line of code loads data into the 'FTDataSet1.Relat' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'FTDataSet.Pedidos' table. You can move, or remove it, as needed.
            this.PedidosTableAdapter.Fill(this.FTDataSet.Pedidos);

            this.reportViewer1.RefreshReport();
            
        }

        private void Impressao_FormClosed(object sender, FormClosedEventArgs e)
        {
                       
            Dal.Relat();
            

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
