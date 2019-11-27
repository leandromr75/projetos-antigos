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
        public static DataTable Inserir(string Cod_Prod, string Descrição, string Cod_EAN, string Cod_EAN_Trib, string Qtde, string Und, string Valor)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Inserir";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            Valor = Valor.Replace(".",",");
            Qtde = Qtde.Replace(".",",");
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_Prod", Convert.ToInt32( Cod_Prod));
            cmd.Parameters.AddWithValue("@Descrição", Descrição);
            cmd.Parameters.AddWithValue("@Cod_EAN", Cod_EAN);
            cmd.Parameters.AddWithValue("@Cod_EAN_Trib", Cod_EAN_Trib);
            cmd.Parameters.AddWithValue("@Qtde", Convert.ToDecimal (Qtde));
            cmd.Parameters.AddWithValue("@Und", Und);
            cmd.Parameters.AddWithValue("@Valor",Convert.ToDecimal( Valor));

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

        public static DataTable Listar()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Listar";

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




        public static DataTable MostrarData()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Teste;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "MostrarData";

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
    

        public static DataTable InserirData(DateTime Data)
            {
                string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Teste;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                //define a instrução SQL para somar Quantidade e agrupar resultados

                string strSQL = "InserirData";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                //abre a conexao
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@data",Convert.ToDateTime( Data));

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

        public static Object Mostrar()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Teste;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "SELECT data FROM Table_1 WHERE id = 1";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.Text;
            Object returnValue;
            returnValue = cmd.ExecuteScalar();

            //define o tipo do comando 

            
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return returnValue; 
        }

        public static Object Medir()
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Rancheiros;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Medir";

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




    }


}
