using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Drawing.Printing;

namespace teste
{
    public partial class Form_principal : Form
    {

        public Form_principal()
        {
            InitializeComponent();
        }
        decimal valor;
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void CodigoBind()
        {
            var getData = (from TaxaDeEntrega in  db.TaxaDeEntregas
                           where TaxaDeEntrega.Id == 1
                           select TaxaDeEntrega.Valor).Single();
            valor = getData;
            return;

        }
        private void button20_Click(object sender, EventArgs e)
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

        private void button19_Click(object sender, EventArgs e)
        {
            
           if (String.IsNullOrEmpty(textBox1.Text) == true)
           {
                MessageBox.Show("Favor Selecionar uma Mesa ou Entrega");
           }

           if (String.IsNullOrEmpty(textBox1.Text) == false)
           { 
            
            
            string message = "Você deseja fechar a conta da(o) " + textBox1.Text + " " + textBox2.Text + " ?";
            string caption = "Magnus Açaí e Cia";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {

                


                if (comboBox1.Text == "Dinheiro" && textBox1.Text == "Mesa")
                {
                    
                        string message1 = "Será cobrado a Taxa de Serviço de 10% ?";
                        string caption1 = "Magnus Açaí e Cia";
                        MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                        DialogResult result1;

                        // Displays the MessageBox.

                        result1 = MessageBox.Show(this, message1, caption1, buttons1,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result1 == DialogResult.Yes)
                        {

                            double sum = 0;
                            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                            {
                                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                            }
                            double r = sum * 0.10;
                            //string Formato2 = String.Format("{0:C2}", r);

                            //textBox5.Text = Formato2;

                            

                             
                            Dal.Insere_taxa_servico(Convert.ToDecimal( r), textBox1.Text, textBox2.Text, comboBox1.Text,1);
                            dataGridView2.DataSource = Dal.Finalizar_dinheiro("Finalizar_dinheiro", int.Parse(textBox2.Text));
                            dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));

                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                        if (result1 == DialogResult.No)
                        {
                            dataGridView2.DataSource = Dal.Finalizar_dinheiro("Finalizar_dinheiro", int.Parse(textBox2.Text));
                            dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                            MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            //dataGridView2.DataSource = Dal.Produtos_list("Produtos_list");
                        }
                        

                }
                else if (comboBox1.Text == "Dinheiro" && textBox1.Text == "Pedido")
                {
                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                    //define a instrução SQL para somar Quantidade e agrupar resultados

                    string strSQL = "Finalizar_dinheiro_pedido";

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


                    cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                    //cria um dataadapter
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    //cria um objeto datatable
                    DataTable clientes = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(clientes);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dataGridView2.DataSource = clientes;


                    con.Dispose();
                    con.Close();
                    cmd.Dispose();
                    dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                    MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
                else if (comboBox1.Text == "Cartão de Débito" && textBox1.Text == "Mesa")
                {


                        string message1 = "Será cobrado a Taxa de Serviço de 10% ?";
                        string caption1 = "Magnus Açaí e Cia";
                        MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                        DialogResult result1;

                        // Displays the MessageBox.

                        result1 = MessageBox.Show(this, message1, caption1, buttons1,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result1 == DialogResult.Yes)
                        {

                            double sum = 0;
                            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                            {
                                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                            }
                            double r = sum * 0.10;
                            
                            Dal.Insere_taxa_servico(Convert.ToDecimal(r), textBox1.Text, textBox2.Text, comboBox1.Text, 1);

                            
                            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                            //define a instrução SQL para somar Quantidade e agrupar resultados

                            string strSQL = "Finalizar_debito";

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


                            cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                            //cria um dataadapter
                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                            //cria um objeto datatable
                            DataTable clientes = new DataTable();

                            //preenche o datatable via dataadapter
                            da.Fill(clientes);

                            //atribui o datatable ao datagridview para exibir o resultado
                            dataGridView2.DataSource = clientes;


                            con.Dispose();
                            con.Close();
                            cmd.Dispose();
                            dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                            MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");

                            textBox1.Text = "";
                            textBox2.Text = "";

                        }


                        if (result1 == DialogResult.No)
                        {
                            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                            //define a instrução SQL para somar Quantidade e agrupar resultados

                            string strSQL = "Finalizar_debito";

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


                            cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                            //cria um dataadapter
                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                            //cria um objeto datatable
                            DataTable clientes = new DataTable();

                            //preenche o datatable via dataadapter
                            da.Fill(clientes);

                            //atribui o datatable ao datagridview para exibir o resultado
                            dataGridView2.DataSource = clientes;


                            con.Dispose();
                            con.Close();
                            cmd.Dispose();
                            dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                            MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                }
                else if (comboBox1.Text == "Cartão de Débito" && textBox1.Text == "Pedido")
                {
                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                    //define a instrução SQL para somar Quantidade e agrupar resultados

                    string strSQL = "Finalizar_debito_pedido";

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


                    cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                    //cria um dataadapter
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    //cria um objeto datatable
                    DataTable clientes = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(clientes);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dataGridView2.DataSource = clientes;


                    con.Dispose();
                    con.Close();
                    cmd.Dispose();
                    dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                    MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if (comboBox1.Text == "Cartão de Crédito" && textBox1.Text == "Mesa")
                {

                    string message1 = "Será cobrado a Taxa de Serviço de 10% ?";
                    string caption1 = "Magnus Açaí e Cia";
                    MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                    DialogResult result1;

                    // Displays the MessageBox.

                    result1 = MessageBox.Show(this, message1, caption1, buttons1,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result1 == DialogResult.Yes)
                    {

                        double sum = 0;
                        for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                        {
                            sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                        }
                        double r = sum * 0.10;

                        Dal.Insere_taxa_servico(Convert.ToDecimal(r), textBox1.Text, textBox2.Text, comboBox1.Text, 1);
                        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                        //define a instrução SQL para somar Quantidade e agrupar resultados

                        string strSQL = "Finalizar_credito";

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


                        cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                        //cria um dataadapter
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                        //cria um objeto datatable
                        DataTable clientes = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(clientes);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dataGridView2.DataSource = clientes;


                        con.Dispose();
                        con.Close();
                        cmd.Dispose();
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                        MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");

                        textBox1.Text = "";
                        textBox2.Text = "";

                    }






                    if (result1 == DialogResult.No)
                    {
                        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                        //define a instrução SQL para somar Quantidade e agrupar resultados

                        string strSQL = "Finalizar_credito";

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


                        cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                        //cria um dataadapter
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                        //cria um objeto datatable
                        DataTable clientes = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(clientes);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dataGridView2.DataSource = clientes;


                        con.Dispose();
                        con.Close();
                        cmd.Dispose();
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                        MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                else if (comboBox1.Text == "Cartão de Crédito" && textBox1.Text == "Pedido")
                {
                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                    //define a instrução SQL para somar Quantidade e agrupar resultados

                    string strSQL = "Finalizar_credito_pedido";

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


                    cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                    //cria um dataadapter
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    //cria um objeto datatable
                    DataTable clientes = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(clientes);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dataGridView2.DataSource = clientes;


                    con.Dispose();
                    con.Close();
                    cmd.Dispose();
                    dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                    MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if (comboBox1.Text == "Cheque" && textBox1.Text == "Mesa")
                {
                    string message1 = "Será cobrado a Taxa de Serviço de 10% ?";
                    string caption1 = "Magnus Açaí e Cia";
                    MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                    DialogResult result1;

                    // Displays the MessageBox.

                    result1 = MessageBox.Show(this, message1, caption1, buttons1,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result1 == DialogResult.Yes)
                    {

                        double sum = 0;
                        for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                        {
                            sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                        }
                        double r = sum * 0.10;

                        Dal.Insere_taxa_servico(Convert.ToDecimal(r), textBox1.Text, textBox2.Text, comboBox1.Text, 1);

                        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                        //define a instrução SQL para somar Quantidade e agrupar resultados

                        string strSQL = "Finalizar_cheque";

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


                        cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                        //cria um dataadapter
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                        //cria um objeto datatable
                        DataTable clientes = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(clientes);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dataGridView2.DataSource = clientes;


                        con.Dispose();
                        con.Close();
                        cmd.Dispose();
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                        MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                        textBox1.Text = "";
                        textBox2.Text = "";

                    }

                    if (result1 == DialogResult.No)
                    {
                        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                        //define a instrução SQL para somar Quantidade e agrupar resultados

                        string strSQL = "Finalizar_cheque";

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


                        cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                        //cria um dataadapter
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                        //cria um objeto datatable
                        DataTable clientes = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(clientes);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dataGridView2.DataSource = clientes;


                        con.Dispose();
                        con.Close();
                        cmd.Dispose();
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                        MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                else if (comboBox1.Text == "Cheque" && textBox1.Text == "Pedido")
                {
                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                    //define a instrução SQL para somar Quantidade e agrupar resultados

                    string strSQL = "Finalizar_cheque_pedido";

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


                    cmd.Parameters.AddWithValue("@Controle", Int32.Parse(textBox2.Text));

                    //cria um dataadapter
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    //cria um objeto datatable
                    DataTable clientes = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(clientes);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dataGridView2.DataSource = clientes;


                    con.Dispose();
                    con.Close();
                    cmd.Dispose();
                    dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                    MessageBox.Show(textBox1.Text + " " + textBox2.Text + " Finalizado(a)");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                
                //dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                
                //dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                dataGridView3.DataSource = Dal.Mesas_ocupadas("Mesas_Ocupadas");
                dataGridView5.DataSource = Dal.Entregas_abertas("Entregas_abertas");
                

                
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
            }
            }  
                      
        }

        private void Form_principal_Load(object sender, EventArgs e)
        {

            dataGridView3.DataSource = Dal.Mesas_ocupadas("Mesas_ocupadas");
            dataGridView1.DataSource = Dal.Produtos_list("Produtos_list");
            dataGridView5.DataSource = Dal.Entregas_abertas("Entregas_abertas");
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Porções");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Beirutes");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Acompanhamentos");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Sucos Naturais");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Cone Pizza");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Milk Shake de Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Bebidas");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;



            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Sanduíches");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;


            con.Dispose();
            con.Close();
            cmd.Dispose();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Lista_produtos";

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
            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;

            con.Dispose();
            con.Close();
            cmd.Dispose();

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {         
            //dataGridView2.DataBindings.Clear();
            textBox1.Text = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            textBox2.Text = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();


            dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos",int.Parse(textBox2.Text));
            
            textBox4.Text = "";
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            }
            double r = sum * 1.10;
            string Formato2 = String.Format("{0:C2}", sum);

            textBox5.Text = Formato2;
            
            if (textBox1.Text == "Mesa")
            {
                string Formato = String.Format("{0:C2}", r);
                textBox3.Text = Formato;
                label6.Text = "Com Taxa de Serviço";
            }
            
            
            
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView5.Rows[dataGridView5.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            textBox2.Text = dataGridView5.Rows[dataGridView5.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            textBox4.Text = "[ " + dataGridView5.Rows[dataGridView5.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() + " ]" + "|" + "[ " + dataGridView5.Rows[dataGridView5.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString() + " ]";


            dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
            
            
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            }
            //double r = sum * 1.10;
            string Formato2 = String.Format("{0:C2}", sum);

            textBox5.Text = Formato2;

            if (textBox1.Text == "Pedido")
            {
                //string Formato = String.Format("{0:C2}", r);
                textBox3.Text = "";
                label6.Text = "";
                
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {

            
            
            string promptValue = Prompt.ShowDialog("Quantidade", "Magnus Açaí e Cia");

            Int32 qtde;

            if (int.TryParse(promptValue.Trim(), out qtde) == false)
            {
                MessageBox.Show("Quantidade incorreta");
                return;
            }
            int c = 0;
            c = int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString());
            
            if ( c - qtde < 0 )
            {
                MessageBox.Show("Estoque Insuficiente / Esgotado");
            }
            

            


            string _produto = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

            decimal _valor = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
            _valor = _valor * qtde;

            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Favor Selecionar uma Mesa ou Entrega");
            }

            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                


                string message = "Você deseja Incluir o Item Selecionado à " + textBox1.Text + " " + textBox2.Text + " ?";
                string caption = "Magnus Açaí e Cia";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    DateTime d = DateTime.Now;
                    string s = d.ToString("dd/MM/yyyy");

                    string _tipo = textBox1.Text;

                    string _controle = textBox2.Text;

                    string _status = "Aguardando";
                    //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                    //define a instrução SQL para somar Quantidade e agrupar resultados

                    string strSQL = "Inserir_movimento_teste";

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
                    cmd.Parameters.AddWithValue("@Produto", _produto);
                    cmd.Parameters.AddWithValue("@Quantidade", qtde);
                    cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(_valor));
                    cmd.Parameters.AddWithValue("@Data", s);
                    cmd.Parameters.AddWithValue("@Tipo", Convert.ToString(_tipo));
                    cmd.Parameters.AddWithValue("@Controle", int.Parse(_controle));
                    cmd.Parameters.AddWithValue("@Status", _status);
                    cmd.Parameters.AddWithValue("@Contador", 1);
                    cmd.Parameters.AddWithValue("@Pagamento", "N");
                    cmd.Parameters.AddWithValue("@Confirma_pagamento", "N");
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString()));






                    //cria um dataadapter
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    //cria um objeto datatable
                    DataTable clientes = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(clientes);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dataGridView2.DataSource = clientes;
                    

                    con.Dispose();
                    con.Close();
                    cmd.Dispose();
                    dbConnection.Dispose();
                    dbConnection.Close();


                    if (textBox1.Text == "Mesa")
                    {
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));    
                    }
                    else if (textBox1.Text == "Pedido")
                    {
                        dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));    
                    }
                    textBox4.Text = "";
                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }
                    double r = sum * 1.10;
                    string Formato2 = String.Format("{0:C2}", sum);

                    textBox5.Text = Formato2;

                    if (textBox1.Text == "Mesa")
                    {
                        string Formato = String.Format("{0:C2}", r);
                        textBox3.Text = Formato;
                        label6.Text = "Com Taxa de Serviço";
                    }
                    dataGridView1.DataSource = Dal.Produtos_list("Produtos_list");
                    //this.produtosTableAdapter1.Fill(this.magnusDataSet3.Produtos);
                 
                   }


                
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
           if (String.IsNullOrEmpty(textBox1.Text) == true)
           {
                MessageBox.Show("Favor Selecionar uma Mesa ou Entrega");
           }

           if (String.IsNullOrEmpty(textBox1.Text) == false)
           {


               if (MessageBox.Show("Deseja excluir o Produto " + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() + " selecionado?",
                   "Aviso", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)
                   == DialogResult.Yes)
               {



                   textBox4.Text = "";

                   string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975";
                   SqlConnection conn = new SqlConnection(connStr);
                   conn.Open();

                   SqlCommand dCmd = new SqlCommand("Excluir_Pedidos_por_mesa", conn);
                   dCmd.CommandType = CommandType.StoredProcedure;
                   try
                   {

                       dCmd.Parameters.AddWithValue("@Id", int.Parse(dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                       dCmd.Parameters.AddWithValue("@Quantidade", int.Parse(dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString()));
                       dCmd.Parameters.AddWithValue("@Produto", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());

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


                   if (textBox1.Text == "Mesa")
                   {
                       dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                   }
                   if (textBox1.Text == "Pedido")
                   {
                       dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                   }
                   double sum = 0;
                   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                   {
                       sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                   }
                   double r = sum * 1.10;
                   string Formato2 = String.Format("{0:C2}", sum);

                   textBox5.Text = Formato2;

                   if (textBox1.Text == "Mesa")
                   {
                       string Formato = String.Format("{0:C2}", r);
                       textBox3.Text = Formato;
                       label6.Text = "Com Taxa de Serviço";
                   }
                   dataGridView1.DataSource = Dal.Produtos_list("Produtos_list");

               }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Favor Selecionar uma Mesa ou Entrega");
            }

            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {


                if (MessageBox.Show("Item " + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() + " foi entregue?",
                "Aviso", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)
                == DialogResult.Yes)
                {


                    string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975";
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();

                    SqlCommand dCmd = new SqlCommand("Produto_entregue", conn);
                    dCmd.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        dCmd.Parameters.AddWithValue("@Id", int.Parse(dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

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
                    if (textBox1.Text == "Mesa")
                    {
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                    }
                    else if (textBox1.Text == "Pedido")
                    {
                        dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                    }
                }
                }


        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            

            
                teste.Mesas_livres frm = new Mesas_livres();
                frm.Show();
                    
                
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            teste.Entregas_cadastro frm2 = new Entregas_cadastro();
            frm2.Show();
            
        
        }

        private void button16_Click(object sender, EventArgs e)
        {


            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = Dal.Mesas_ocupadas("Mesas_Ocupadas");
            dataGridView5.DataSource = Dal.Entregas_abertas("Entregas_abertas");
        }

        

        private void button22_Click(object sender, EventArgs e)
        {
            
           if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Favor Selecionar uma Mesa ou Entrega");
            }

           if (String.IsNullOrEmpty(textBox1.Text) == false)
           {
               if (textBox1.Text == "Pedido")
               {
                   CodigoBind();
                   Dal.Insere_taxa_entrega(valor, textBox1.Text, textBox2.Text, 2);
                   dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                   double sum = 0;
                   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                   {
                       sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                   }
                   //double r = sum * 1.10;
                   string Formato2 = String.Format("{0:C2}", sum);
                   textBox5.Text = Formato2;
               }
               else
                   MessageBox.Show("Esta Taxa pode ser aplicada somente para Entregas");
           }
            
            
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Quantidade", "Magnus Açaí e Cia");

            Int32 qtde;

            if (int.TryParse(promptValue.Trim(), out qtde) == false)
            {
                MessageBox.Show("Quantidade incorreta");
                return;
            }
            int c = 0;
            c = int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString());

            if (c - qtde < 0)
            {
                MessageBox.Show("Estoque Insuficiente / Esgotado");
            }





            string _produto = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

            decimal _valor = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
            _valor = _valor * qtde;

            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Favor Selecionar uma Mesa ou Entrega");
            }

            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {



                string message = "Você deseja Incluir o Item Selecionado à " + textBox1.Text + " " + textBox2.Text + " ?";
                string caption = "Magnus Açaí e Cia";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    DateTime d = DateTime.Now;
                    string s = d.ToString("dd/MM/yyyy");

                    string _tipo = textBox1.Text;

                    string _controle = textBox2.Text;

                    string _status = "Aguardando";
                    //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                    //define a instrução SQL para somar Quantidade e agrupar resultados

                    string strSQL = "Inserir_movimento_teste";

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
                    cmd.Parameters.AddWithValue("@Produto", _produto);
                    cmd.Parameters.AddWithValue("@Quantidade", qtde);
                    cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(_valor));
                    cmd.Parameters.AddWithValue("@Data", s);
                    cmd.Parameters.AddWithValue("@Tipo", Convert.ToString(_tipo));
                    cmd.Parameters.AddWithValue("@Controle", int.Parse(_controle));
                    cmd.Parameters.AddWithValue("@Status", _status);
                    cmd.Parameters.AddWithValue("@Contador", 1);
                    cmd.Parameters.AddWithValue("@Pagamento", "N");
                    cmd.Parameters.AddWithValue("@Confirma_pagamento", "N");
                    cmd.Parameters.AddWithValue("@Id", int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString()));






                    //cria um dataadapter
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    //cria um objeto datatable
                    DataTable clientes = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(clientes);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dataGridView2.DataSource = clientes;


                    con.Dispose();
                    con.Close();
                    cmd.Dispose();
                    dbConnection.Dispose();
                    dbConnection.Close();


                    if (textBox1.Text == "Mesa")
                    {
                        dataGridView2.DataSource = Dal.Listar_pedidos("Listar_pedidos", int.Parse(textBox2.Text));
                    }
                    else if (textBox1.Text == "Pedido")
                    {
                        dataGridView2.DataSource = Dal.Listar_pedidos2("Listar_pedidos2", int.Parse(textBox2.Text));
                    }
                    textBox4.Text = "";
                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }
                    double r = sum * 1.10;
                    string Formato2 = String.Format("{0:C2}", sum);

                    textBox5.Text = Formato2;

                    if (textBox1.Text == "Mesa")
                    {
                        string Formato = String.Format("{0:C2}", r);
                        textBox3.Text = Formato;
                        label6.Text = "Com Taxa de Serviço";
                    }
                    dataGridView1.DataSource = Dal.Produtos_list("Produtos_list");
                    //this.produtosTableAdapter1.Fill(this.magnusDataSet3.Produtos);
                }
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tela_auxiliar ti = new Tela_auxiliar();
            ti.Show();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "seleciona_produto";
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

            /*cmd.Parameters.Add("@prod_Id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            cmd.Parameters.AddWithValue("@Familia", "Minis Cones Doce");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;


            con.Dispose();
            con.Close();
            cmd.Dispose();
        
            }

        private void button21_Click(object sender, EventArgs e)
        {
            /*Impressao imp = new Impressao();
            imp.Show();*/
            
            PrintPreviewDialog printDialog1 = new PrintPreviewDialog();
            printDialog1.Document = printDocument1;
              

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
          
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);

            this.dataGridView2.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));

            e.Graphics.DrawImage(bm, 0, 0);
        
        
        
        
        }



       
    }
            
 }
 
