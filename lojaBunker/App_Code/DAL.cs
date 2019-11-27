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
    public static void InsereSite(string marca, string familia, string modelo, string voltagem, string prazo, string iluminacao,
            string descricao, string imagem)
    {
        String strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=lojaBunker;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                
        String strSQL = "Cadastrar_site";
        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);
        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);
        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@marca", marca);
        cmd.Parameters.AddWithValue("@familia", familia);
        cmd.Parameters.AddWithValue("@modelo", modelo);
        cmd.Parameters.AddWithValue("@voltagem", voltagem);
        cmd.Parameters.AddWithValue("@prazo", prazo);
        cmd.Parameters.AddWithValue("@iluminacao", iluminacao);
        cmd.Parameters.AddWithValue("@descricao", descricao);
        cmd.Parameters.AddWithValue("@imagem", imagem);

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

    }
    public static String PegaIdSite()
    {
        String strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=lojaBunker;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        string retorno;
        String strSQL = "Id_site";
        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);
        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);
        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        retorno = Convert.ToString( cmd.ExecuteScalar() );
        //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //cria um objeto datatable
        //DataTable clientes = new DataTable();
        //preenche o datatable via dataadapter
        //da.Fill(clientes);
        con.Dispose();
        con.Close();
        cmd.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();

        return retorno;

    }
}