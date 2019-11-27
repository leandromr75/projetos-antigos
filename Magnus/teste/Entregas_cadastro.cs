using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace teste
{
    public partial class Entregas_cadastro : Form
    {
        public Entregas_cadastro()
        {
            InitializeComponent();
            textBox1.Focus();
            textBox1.Select();
            dataGridView1.DataSource = Dal.Listar_telefones("Listar_telefones");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dal.Abrir_entregas("Abrir_entregas", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

            dataGridView1.DataSource = Dal.Produtos_list("Produtos_list");
            //this.produtosTableAdapter1.Fill(this.magnusDataSet3.Produtos);

            this.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null)
            {
                //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
                string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                //define a instrução SQL para somar Quantidade e agrupar resultados

                string strSQL = "Inserir_telefone";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                //abre a conexao
                con.Open();

                //define o tipo do comando 
                cmd.CommandType = CommandType.StoredProcedure;
                int qtde;
                cmd.Parameters.AddWithValue("@DDD", textBox2.Text);
                if (int.TryParse(textBox3.Text.Trim(), out qtde) == true)
                {
                    cmd.Parameters.AddWithValue("@Telefone", qtde);
                }
                else
                {
                    MessageBox.Show("Formato Telefone Incorreto! Utlizar somente números");
                    textBox3.Text = "";
                    return;
                }


                cmd.Parameters.AddWithValue("@Nome", textBox4.Text);
                cmd.Parameters.AddWithValue("@Endereço", textBox5.Text);
                //cria um dataadapter
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                //cria um objeto datatable
                DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(clientes);
                con.Close();
                cmd.Dispose();
                con.Dispose();
                dataGridView1.DataSource = clientes;
                label7.Text = "Registro Incluído com Sucesso!";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dataGridView1.DataSource = Dal.Listar_telefones("Listar_telefones");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label7.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null)
            {
                //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
                string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                //define a instrução SQL para somar Quantidade e agrupar resultados

                string strSQL = "Alterar_telefone";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                //abre a conexao
                con.Open();

                //define o tipo do comando 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32( dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                int qtde;
                cmd.Parameters.AddWithValue("@DDD", textBox2.Text);
                if (int.TryParse(textBox3.Text.Trim(), out qtde) == true)
                {
                    cmd.Parameters.AddWithValue("@Telefone", qtde);
                }
                else
                {
                    MessageBox.Show("Formato Telefone Incorreto! Utlizar somente números");
                    textBox3.Text = "";
                    return;
                }


                cmd.Parameters.AddWithValue("@Nome", textBox4.Text);
                cmd.Parameters.AddWithValue("@Endereço", textBox5.Text);
                //cria um dataadapter
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                //cria um objeto datatable
                DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(clientes);
                con.Close();
                cmd.Dispose();
                con.Dispose();
                dataGridView1.DataSource = clientes;
                label7.Text = "Registro Alterado com Sucesso!";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dataGridView1.DataSource = Dal.Listar_telefones("Listar_telefones");
            }
        }

        private void Entregas_cadastro_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Excluir_telefone";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();

            //define o tipo do comando 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                                   
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            cmd.Dispose();
            con.Dispose();
            dataGridView1.DataSource = clientes;
            label7.Text = "Registro Excluído com Sucesso!";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dataGridView1.DataSource = Dal.Listar_telefones("Listar_telefones");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Procura_telefone";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();

            //define o tipo do comando 
            cmd.CommandType = CommandType.StoredProcedure;
            int qtde;
            
            if (int.TryParse(textBox1.Text.Trim(), out qtde) == true)
            {
                cmd.Parameters.AddWithValue("@Telefone", qtde);
            }
            else
            {
                MessageBox.Show("Formato Telefone Incorreto! Utlizar somente números");
                textBox3.Text = "";
                return;
            }
            
                                   
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            cmd.Dispose();
            con.Dispose();
            dataGridView1.DataSource = clientes;
            //label7.Text = "Registro Excluído com Sucesso!";
            textBox1.Text = "";

            try
            {
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Telefone não cadastrado");
                dataGridView1.DataSource = Dal.Listar_telefones("Listar_telefones");    
            }
            
        }
    }
}
