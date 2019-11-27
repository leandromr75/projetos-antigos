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
    public partial class Baixa : Form
    {
        public Baixa()
        {
            InitializeComponent();
        }

        private void Baixa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Listar_Recibos_Baixa();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Listar_Recibos_Baixa_Todos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Listar_Recibos_Baixa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Você deseja Dar Baixa no Recibo de " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() + " ?";
            string caption = "Associação";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                Dal.Recibos_Baixa(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                dataGridView1.DataSource = Dal.Listar_Recibos_Baixa();
                MessageBox.Show("Foi dado baixa no Recibo selecionado!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Você deseja Excluír Recibo de " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() + " ?";
            string caption = "Associação";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {

                Dal.Exclui_Recibos(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                dataGridView1.DataSource = Dal.Listar_Recibos_Baixa();
                MessageBox.Show("Recibo Excluído com Sucesso!");
            }

            
        }
    }
}
