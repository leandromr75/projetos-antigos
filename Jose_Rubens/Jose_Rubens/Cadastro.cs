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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Listar_Associados();
            dataGridView2.DataSource = Dal.Ultima_Insercao();
            textBox13.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
                        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[6].FormattedValue.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[7].FormattedValue.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[8].FormattedValue.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[9].FormattedValue.ToString();

            textBox10.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();

            //jogar cpf-cnpj na área de transferência
            Clipboard.Clear();
            string transf = textBox2.Text.ToString();
            Clipboard.SetText(transf);

            if (checkBox1.Checked == true)
            {
                Dal.Ultima_Insercao_Atualiza(textBox10.Text);


                dataGridView2.DataSource = Dal.Ultima_Insercao();
 
            }
           
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox11.Text = Convert.ToString(monthCalendar1.SelectionStart.Date.ToShortDateString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false &&
                String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox8.Text) == false && String.IsNullOrEmpty(textBox7.Text) == false &&
                String.IsNullOrEmpty(textBox6.Text) == false )
            {
                Dal.Inserir_Associado(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, textBox8.Text,
                    textBox7.Text, textBox6.Text, textBox5.Text, textBox9.Text);
                

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox5.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                MessageBox.Show("Dados incluídos com sucesso!!");
                dataGridView1.DataSource = Dal.Listar_Associados();

                
            }
            else
                MessageBox.Show("Campo obrigatório não preenchido");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string message = "Você deseja Alterar Dados?";
            string caption = "Associação";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false &&
                    String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox8.Text) == false && String.IsNullOrEmpty(textBox7.Text) == false &&
                    String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    Dal.Alterar_Associado(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()), textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, textBox8.Text,
                        textBox7.Text, textBox6.Text, textBox5.Text, textBox9.Text);


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox9.Text = "";
                    textBox5.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    MessageBox.Show("Dados alterados com sucesso!!");
                    dataGridView1.DataSource = Dal.Listar_Associados();


                }
                else
                    MessageBox.Show("Campo obrigatório não preenchido");
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Você deseja Excluír Associado?";
            string caption = "Associação";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false &&
                    String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox8.Text) == false && String.IsNullOrEmpty(textBox7.Text) == false &&
                    String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    Dal.Exclui_Associado(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox9.Text = "";
                    textBox5.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    MessageBox.Show("Dados Excluídos com sucesso!!");
                    dataGridView1.DataSource = Dal.Listar_Associados();
                }
                else
                {
                    MessageBox.Show("Selecionar Um Associado para Exclusão!!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Você deseja Atualizar Número de Recibo?";
            string caption = "Associação";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(textBox13.Text) == false)
                {
                    Dal.Ultima_Insercao_Atualiza_Numero(textBox13.Text);
                    MessageBox.Show("Número de Recibo Alterado com Sucesso!!");
                    dataGridView2.DataSource = Dal.Ultima_Insercao();
                    textBox13.Text = dataGridView2.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Campo do Número de recibo vazio!");
                }
                


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox10.Text) == false && String.IsNullOrEmpty(textBox11.Text) == false && String.IsNullOrEmpty(textBox13.Text) == false && String.IsNullOrEmpty(textBox12.Text) == false)
            {
                Dal.Inclui_Recibo(textBox10.Text,textBox11.Text,textBox13.Text,textBox12.Text);
                Dal.Ultima_Insercao_Atualiza(textBox10.Text);
                MessageBox.Show("Dados inseridos com sucesso!!");
                textBox10.Text = "";
                dataGridView2.DataSource = Dal.Ultima_Insercao();
                
            }
            else
            {
                MessageBox.Show("Campos Obrigatórios não Preenchidos!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Baixa baix = new Baixa();
            baix.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox5.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        
    }
}
