using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
	
        //oledb azure
		public static DataTable ListaAUXVendas()
        {
            string strConnection = "Provider=SQLNCLI11;Password=#lecoteco1975;User ID=leandromr75;Initial Catalog=SQL-DEV;Data Source=tcp:ol7mfcoud1.database.windows.net";
            //string strConnection = "Data Source=ol7mfcoud1.database.windows.net;Initial Catalog=DQL-DEV;User ID=leandromr75;Password=#lecoteco1975;Provider=Microsoft.Jet.OLEDB.4.0";
            
            String strSQL = "Listar";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            
            //cmd.Parameters.AddWithValue("@CodEANTrib", codeantrib);

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