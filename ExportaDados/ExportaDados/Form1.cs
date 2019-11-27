using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExportaDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string caminho = "Produtos.txt";

            // criar um arquivo para escrever
            using (StreamWriter sw = File.CreateText(caminho))
            {
                //Server=myServerName\theInstanceName;Database=myDataBase;Trusted_Connection=True;
                //Monta a string de conexão para SQL Server com os dados do formulário
                string conn = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";

                OleDbConnection cn = new OleDbConnection(conn);
                //define a instrução SQL para executar contra o banco de dados
                string sql = " Select CodEAN,DescInterna,Unidade,CF_NCM,ValorVenda from Produtos ";
                OleDbCommand cmd = new OleDbCommand(sql,cn);
                try
                {
                    //abre a conexão e gera o datareader
                    cn.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    // percorre o datareader e escreve os dados no arquivo .xls definido
                    while (dr.Read())
                    {
                        sw.WriteLine(dr["CodEAN"].ToString() + "\t" + dr["DescInterna"].ToString() + "\t" + dr["Unidade"].ToString() + "\t" +
                            dr["CF_NCM"].ToString() + "\t" + dr["ValorVenda"].ToString());
                    }
                    //exibe mensagem ao usuario
                    MessageBox.Show("Arquivo " + caminho + " gerado com sucesso.");
                }
                catch (Exception excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
        }
    }
}
