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
    public partial class Movimento : Form
    {
        public Movimento()
        {
            InitializeComponent();
            //dataGridView1.DataSource = Dal.Lista_familia();
            dataGridView1.DataSource = Dal.Mostrar_movimento();
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            //double r = sum * 1.10;
            string Formato2 = String.Format("{0:C2}", sum);

            textBox1.Text = Formato2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Filtrar_movimento";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", monthCalendar1.SelectionStart.Date.ToShortDateString());

            cmd.Parameters.AddWithValue("@Pagamento", comboBox1.Text);

            //define o tipo do comando 

            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            dataGridView1.DataSource = clientes;


            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            //double r = sum * 1.10;
            string Formato2 = String.Format("{0:C2}", sum);

            textBox1.Text = Formato2;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Mostrar_movimento();
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            //double r = sum * 1.10;
            string Formato2 = String.Format("{0:C2}", sum);

            textBox1.Text = Formato2;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string message = "Você deseja excluir todo o histórico de vendas?";
            string caption = "Magnus Açaí e Cia";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {


                string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                //define a instrução SQL para somar Quantidade e agrupar resultados

                string strSQL = "Deletar_movimento";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                //abre a conexao
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                //define o tipo do comando 

                //cria um dataadapter
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                //cria um objeto datatable
                DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(clientes);
                con.Dispose();
                con.Close();
                cmd.Dispose();
                dbConnection.Dispose();
                dbConnection.Close();
                //atribui o datatable ao datagridview para exibir o resultado
                //dataGridView1.DataSource = clientes;
                dataGridView1.DataSource = clientes;
            }
        }
    }
}
