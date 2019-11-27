using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
	
	    public static DataTable ListaAUXVendas()
        {
            string strConnection = "Password=#lecoteco1975;User ID=leandromr75;Initial Catalog=SQL-DEV;Data Source=tcp:ol7mfcoud1.database.windows.net";
            //string strConnection = "Data Source=ol7mfcoud1.database.windows.net;Initial Catalog=DQL-DEV;User ID=leandromr75;Password=#lecoteco1975;Provider=Microsoft.Jet.OLEDB.4.0";
            
            String strSQL = "Listar";
            //cria a conexão com o banco de dados
            SqlConnection dbConnection = new SqlConnection(strConnection);
            //cria a conexão com o banco de dados
            SqlConnection con = new SqlConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            SqlCommand cmd = new SqlCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            
            //cmd.Parameters.AddWithValue("@CodEANTrib", codeantrib);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
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