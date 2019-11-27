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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Listar_Associados();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           richTextBox1.Text = "Nome : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() + "\n"
                             + "CPF/CNPJ : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() + "\n"
                             + "Endereço : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString() + "\n"
                             + "Cidade : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString() + "        UF : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[6].FormattedValue.ToString() + "\n"
                             + "Bairro : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString() + "\n" 
                             + "CEP : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[7].FormattedValue.ToString() + "\n"
                             + "Telefone : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[8].FormattedValue.ToString() + "\n"
                             + "Email : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[9].FormattedValue.ToString();

           dataGridView2.DataSource = Dal.Listar_Recibos(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
           
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Dal.Listar_Recibos(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Dal.Listar_Recibos_Pagos(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Dal.Listar_Recibos_Em_Aberto(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RelatorioEmAberto relat = new RelatorioEmAberto();
            relat.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Relatorio relat1 = new Relatorio();
            relat1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Cadastro cad = new Cadastro();
            cad.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Baixa baix = new Baixa();
            baix.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                dataGridView1.DataSource = Dal.Localiza_Letra(Convert.ToChar( textBox1.Text ));
            }
            else
            {
                MessageBox.Show("Digite Letra para pesquisa");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Listar_Associados();
            textBox1.Text = "";
            richTextBox1.Text = "";
            dataGridView2.DataSource = Dal.Listar_Recibos_Em_Aberto("");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ListarDadosAssoc List = new ListarDadosAssoc();
            List.Show();
        }

       

        
        
    }
}
