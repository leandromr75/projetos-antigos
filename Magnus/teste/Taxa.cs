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
    public partial class Taxa : Form
    {
        public Taxa()
        {
            InitializeComponent();
            

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = Dal.Recupera_taxa_entrega();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Insert_taxa_entrega";

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
            if (textBox1.Text != null)
            {
                cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(textBox1.Text));
            }
            else
            {
                MessageBox.Show("Informe Novo Valor Da Taxa De Entrega");
            }
                //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            cmd.Dispose();
            con.Dispose();

            //atribui o datatable ao datagridview para exibir o resultado
           
           dataGridView1.DataSource = Dal.Recupera_taxa_entrega();
        }
    }
}
