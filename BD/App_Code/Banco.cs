using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Banco
/// </summary>
public class Banco
{

    public static DataTable listaProdutosTodos()
    {
        string strConnection = "";
        
        strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        
            
        String strSQL = "listaProdutosTodos";
        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);
        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);
        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@IdProd", ident);
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