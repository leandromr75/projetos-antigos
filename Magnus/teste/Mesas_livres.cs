using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace teste
{
    public partial class Mesas_livres : Form
    {
        public Mesas_livres()
        {
            InitializeComponent();
            dataGridView1.DataSource = Dal.Mesas_livres("Mesas_livres");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dal.Abrir_mesas("Abrir_mesa", int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString()));
            
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
