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
    public partial class Pesquisa : Form
    {
        public Pesquisa()
        {
            InitializeComponent();
        }

        private void Pesquisa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Pesquisa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                Dal.Preparar_Re_Listar_Relat(Convert.ToInt32( dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString()));
                Pesq p = new Pesq();
                p.Show();
            }
            
        }
    }
}
