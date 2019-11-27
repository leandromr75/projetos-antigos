using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace teste
{
    class Dal
    {
        

        public static DataTable Items_pendentes2()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Items_pendentes2";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Familia", familia);

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
            return clientes;
        }

        public static DataTable Items_pendentes()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Items_pendentes";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Familia", familia);

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
            return clientes;
        }
        public static DataTable Mostrar_movimento()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Mostrar_movimento";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Familia", familia);

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
            return clientes;
        }


        public static DataTable Lista_familia()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Lista_familia";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Familia", familia);

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
            return clientes;
        }

        public static DataTable Inserir_familia(string familia)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Inserir_familia";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Familia", familia);

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
            return clientes;
        }
        
        
        public static DataTable Produtos_cadastro()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Produtos_cadastro";
            
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
            return clientes;

            
        }

        public static DataTable Insere_taxa_servico(decimal valor, string tipo, string controle,string pagamento, int contador)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Insere_taxa_servico";

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

            DateTime d = DateTime.Now;
            string s = d.ToString("dd/MM/yyyy");

            //define o tipo do comando 
            if (contador == 1)
            {

               // cmd.Parameters.AddWithValue("@Produto", "Taxa de Serviço");
                //cmd.Parameters.AddWithValue("@Quantidade", 1);
                cmd.Parameters.AddWithValue("@Valor",Convert.ToDecimal( valor));
                cmd.Parameters.AddWithValue("@Data", s);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Controle", Convert.ToInt32(controle));
               // cmd.Parameters.AddWithValue("@Status", "Entregue");
                //cmd.Parameters.AddWithValue("@Contador", 1);
                cmd.Parameters.AddWithValue("@Pagamento",pagamento );
                //cmd.Parameters.AddWithValue("@Confirma_pagamento", "N");
            }
            if (contador == 2)
            {
                //cmd.Parameters.AddWithValue("@Produto", "Taxa de Entrega");
                //cmd.Parameters.AddWithValue("@Quantidade", 1);
                cmd.Parameters.AddWithValue("@Valor", valor);
                cmd.Parameters.AddWithValue("@Data", s);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Controle", Convert.ToInt32(controle));
                //cmd.Parameters.AddWithValue("@Status", "Aguardando");
                //cmd.Parameters.AddWithValue("@Contador", 1);
                //cmd.Parameters.AddWithValue("@Pagamento", "N");
                //cmd.Parameters.AddWithValue("@Confirma_pagamento", "N");
            }
            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            return clientes;
        }
        public static DataTable Insere_taxa_entrega(decimal valor, string tipo, string controle, int contador)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Insere_taxa_entrega";

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

            DateTime d = DateTime.Now;
            string s = d.ToString("dd/MM/yyyy");

            //define o tipo do comando 
            if (contador == 1)
            {
                
            cmd.Parameters.AddWithValue("@Produto", "Taxa de Serviço");
            cmd.Parameters.AddWithValue("@Quantidade", 1);
            cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal( valor));
            cmd.Parameters.AddWithValue("@Data", s);
            cmd.Parameters.AddWithValue("@Tipo", "Mesa");
            cmd.Parameters.AddWithValue("@Controle",Convert.ToInt32( controle));
            cmd.Parameters.AddWithValue("@Status", "Entregue");
            cmd.Parameters.AddWithValue("@Contador", 1);
            cmd.Parameters.AddWithValue("@Pagamento", "N");
            cmd.Parameters.AddWithValue("@Confirma_pagamento", "N");
            }
            if (contador == 2)
            {
                //cmd.Parameters.AddWithValue("@Produto", "Taxa de Entrega");
                //cmd.Parameters.AddWithValue("@Quantidade", 1);
                cmd.Parameters.AddWithValue("@Valor", valor);
                cmd.Parameters.AddWithValue("@Data", s);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Controle", Convert.ToInt32(controle));
                //cmd.Parameters.AddWithValue("@Status", "Aguardando");
                //cmd.Parameters.AddWithValue("@Contador", 1);
                //cmd.Parameters.AddWithValue("@Pagamento", "N");
                //cmd.Parameters.AddWithValue("@Confirma_pagamento", "N");
            }
            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            return clientes;
        }

        public static DataTable Recupera_taxa_entrega()
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Recupera_taxa_entrega";

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

            //cmd.Parameters.AddWithValue("@Id", id);
            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            cmd.Dispose();
            con.Dispose();
            return clientes;
        }

        public static DataTable Abrir_entregas(string procedure,int id)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            //string strSQL = "Abrir_entregas";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(procedure, con);

            //abre a conexao
            con.Open();

            //define o tipo do comando 
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);
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
            return clientes;



        }
        public static DataTable Listar_telefones(string procedure)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Listar_telefones";

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

            //cmd.Parameters.AddWithValue("@Controle", control);
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
            return clientes;



        }

        public  static DataTable Mesas_ocupadas( string procedure)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = procedure;
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

            //cmd.Parameters.AddWithValue("@Controle", control);
            /*cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            //cmd.Parameters.AddWithValue("@Familia", "Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            return  clientes;
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
                 
            
        }
        public static DataTable Abrir_mesas(string procedure, int control)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = procedure;
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

            cmd.Parameters.AddWithValue("@Numero", control);
            /*cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            //cmd.Parameters.AddWithValue("@Familia", "Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            return clientes;
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;


        }


        //datagridview3_cellclick
        public static DataTable Listar_pedidos(string procedure, int control)
        {
             //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Listar_pedidos";

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

            cmd.Parameters.AddWithValue("@Controle", control);
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
            return clientes;


            
        }
        public static DataTable Listar_pedidos2(string procedure, int control)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Listar_pedidos2";

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

            cmd.Parameters.AddWithValue("@Controle", control);
            //cmd.Parameters.AddWithValue("@Contador", contador);
            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            return clientes;
        }
        public static DataTable Produtos_list(string procedure)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = "Produtos_list";
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

            //cmd.Parameters.AddWithValue("@Familia", "Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            con.Close();
            return clientes;
        }

        public static DataTable Mesas_livres(string procedure)
        {
            //define string de conexão - Provedor + fonte de dados (caminho do banco de dados e seu nome)            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = procedure;
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

            //cmd.Parameters.AddWithValue("@Familia", "Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            con.Close();
            return clientes;
        }

        public static DataTable Finalizar_dinheiro(string procedure, int control)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";

            string strSQL = "Finalizar_dinheiro";

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


            cmd.Parameters.AddWithValue("@Controle", control);

            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            
            //atribui o datatable ao datagridview para exibir o resultado
            con.Dispose();
            con.Close();
            cmd.Dispose();
            return clientes;
        }
        public static DataTable Entregas_abertas(string procedure)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Magnus;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string strSQL = procedure;
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

            //cmd.Parameters.AddWithValue("@Controle", control);
            /*cmd.Parameters.Add("@prod_nome", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@prod_descricao", SqlDbType.NVarChar).Value = textBox3.Text;*/
            //método obsoleto

            //cmd.Parameters.AddWithValue("@Familia", "Açaí");


            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Close();
            return clientes;
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;


        }
    }
}
