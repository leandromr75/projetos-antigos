using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;



namespace teste
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'magnusDataSet1.Familias' table. You can move, or remove it, as needed.
            //this.familiasTableAdapter.Fill(this.magnusDataSet1.Familias);
            // TODO: This line of code loads data into the 'magnusDataSet.Produtos' table. You can move, or remove it, as needed.
            //is.produtosTableAdapter.Fill(this.magnusDataSet.Produtos);

            dataGridView1.DataSource = Dal.Produtos_cadastro();
            dataGridView2.DataSource = Dal.Lista_familia();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            
            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("Inserir", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
                        

            try
            {
                
                dCmd.Parameters.AddWithValue("@Produto", textBox1.Text);
                dCmd.Parameters.AddWithValue("@Familia", textBox2.Text);
                
                if (String.IsNullOrEmpty(textBox3.Text) == false)
                {
                    dCmd.Parameters.AddWithValue("@Custo", Convert.ToDecimal(textBox3.Text));
                }
                else 
                {
                    string str3 = "0.0";
                    dCmd.Parameters.AddWithValue("@Custo", str3);
                }
                
                dCmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(textBox4.Text));
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    dCmd.Parameters.AddWithValue("@Quantidade", Convert.ToInt32(textBox5.Text));
                }
                else
                {
                    int qtde = 0;
                    dCmd.Parameters.AddWithValue("@Quantidade", qtde);

                }
                if (String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    dCmd.Parameters.AddWithValue("@Validade", textBox6.Text);    
                }
                else
                {
                    string str5 = "N/A";
                    dCmd.Parameters.AddWithValue("@Validade", str5);

                }
                
                
                dCmd.ExecuteNonQuery();
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;

                label10.Text = "Produto cadastrado com sucesso!!";
                dataGridView1.DataSource = Dal.Produtos_cadastro();


            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            // TODO: This line of code loads data into the 'magnusDataSet.Produtos' table. You can move, or remove it, as needed.
            //this.produtosTableAdapter.Fill(this.magnusDataSet.Produtos);
            dataGridView1.DataSource = Dal.Produtos_cadastro();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox7.Text) == false)
            {
                dataGridView2.DataSource = Dal.Inserir_familia(textBox7.Text);


                // TODO: This line of code loads data into the 'magnusDataSet1.Familias' table. You can move, or remove it, as needed.
                //this.familiasTableAdapter.Fill(this.magnusDataSet1.Familias);
                label9.Text = "Família criada com sucesso!";
                dataGridView2.DataSource = Dal.Lista_familia();
                textBox7.Text = "";

            }
            //label9.Text = "Fornecer Um Nome para nova Família de produto";

            else { return; } 
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A família deve ser escolhida pela tabela abaixo!", "Magnus Açaí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Focus();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A Validade deve ser escolhida pelo calendário abaixo!", "Magnus Açaí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox5.Focus();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Este campo permite criar uma nova Família de Produtos, que será acrescentada à tabela de famílias", "Magnus Açaí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label9.Text = "Este campo permite criar uma nova" +"\n" + "Família de Produtos à" + "\n" + "tabela ao lado";
        }



        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            textBox2.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox6.Text = Convert.ToString(monthCalendar1.SelectionStart.Date.ToShortDateString());
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("A família deve ser escolhida pela tabela abaixo!", "Magnus Açaí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Focus();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("A Validade deve ser escolhida pelo calendário abaixo!", "Magnus Açaí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox5.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Você deseja sair do aplicativo?";
            string caption = "Magnus Açaí";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {


                // Closes the parent form.
                Application.Exit();


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            
            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("Deletar_familia", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            try
            {

                dCmd.Parameters.AddWithValue("@Familia", str );

                dCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
                
            }
            dataGridView2.DataSource = Dal.Lista_familia();
            
            // TODO: This line of code loads data into the 'magnusDataSet1.Familias' table. You can move, or remove it, as needed.
               // this.familiasTableAdapter.Fill(this.magnusDataSet1.Familias);
                       
            label9.Text = "Família excluída com sucesso!";
        }

        private void button7_Click(object sender, EventArgs e)
        {
                      
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            label9.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str2 = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("Deleta_produto", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            try
            {

                dCmd.Parameters.AddWithValue("@Id", str2);

                dCmd.ExecuteNonQuery();
                label10.Text = "Produto Excluído com sucesso!!";
                dataGridView1.DataSource = Dal.Produtos_cadastro();
            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
                
            }
            

            
            // TODO: This line of code loads data into the 'magnusDataSet.Produtos' table. You can move, or remove it, as needed.
           // this.produtosTableAdapter.Fill(this.magnusDataSet.Produtos);
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[6].FormattedValue.ToString();

            label10.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("Alterar_produto", conn);
            dCmd.CommandType = CommandType.StoredProcedure;


            try
            {
                dCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                dCmd.Parameters.AddWithValue("@Produto", textBox1.Text);
                dCmd.Parameters.AddWithValue("@Familia", textBox2.Text);

                if (String.IsNullOrEmpty(textBox3.Text) == false)
                {
                    dCmd.Parameters.AddWithValue("@Custo", Convert.ToDecimal(textBox3.Text));
                }
                else
                {
                    string str3 = "0.0";
                    dCmd.Parameters.AddWithValue("@Custo", str3);
                }

                dCmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(textBox4.Text));
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    dCmd.Parameters.AddWithValue("@Quantidade", Convert.ToInt32(textBox5.Text));
                }
                else
                {
                    int qtde = 0;
                    dCmd.Parameters.AddWithValue("@Quantidade", qtde);

                }
                if (String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    dCmd.Parameters.AddWithValue("@Validade", textBox6.Text);
                }
                else
                {
                    string str5 = "N/A";
                    dCmd.Parameters.AddWithValue("@Validade", str5);

                }


                dCmd.ExecuteNonQuery();
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;

                label10.Text = "Dados alterados com sucesso!!";
                dataGridView1.DataSource = Dal.Produtos_cadastro();
            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            // TODO: This line of code loads data into the 'magnusDataSet.Produtos' table. You can move, or remove it, as needed.
           // this.produtosTableAdapter.Fill(this.magnusDataSet.Produtos);
           

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label9.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label10.Text = "";
        }
    }
}
