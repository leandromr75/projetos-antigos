using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.BarCode;


namespace RecolheEAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                

                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {

                    string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";

                    String strSQL = "Verifica";
                    //cria a conexão com o banco de dados
                    OleDbConnection dbConnection = new OleDbConnection(strConnection);
                    //cria a conexão com o banco de dados
                    OleDbConnection con = new OleDbConnection(strConnection);
                    //cria o objeto command para executar a instruçao sql
                    OleDbCommand cmd = new OleDbCommand(strSQL, con);
                    //abre a conexao
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Caixa", textBox1.Text);
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

                    if (clientes.Rows.Count > 0)
                    {
                        pictureBox2.Visible = true;
                        timer1.Enabled = true;
                        textBox1.Text = "";

                    }
                    if (clientes.Rows.Count <= 0)
                    {
                        pictureBox1.Visible = true;
                        timer1.Enabled = true;
                        string strConnection1 = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";

                        String strSQL1 = "CriaEAN";
                        //cria a conexão com o banco de dados
                        OleDbConnection dbConnection1 = new OleDbConnection(strConnection1);
                        //cria a conexão com o banco de dados
                        OleDbConnection con1 = new OleDbConnection(strConnection1);
                        //cria o objeto command para executar a instruçao sql
                        OleDbCommand cmd1 = new OleDbCommand(strSQL1, con1);
                        //abre a conexao
                        con1.Open();
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@Caixa", textBox1.Text);
                        OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
                        //cria um objeto datatable
                        DataTable clientes2 = new DataTable();
                        //preenche o datatable via dataadapter
                        da1.Fill(clientes2);
                        con1.Dispose();
                        con1.Close();
                        cmd1.Dispose();
                        dbConnection1.Dispose();
                        dbConnection1.Close();
                        BarCodeBuilder bb = new BarCodeBuilder();

                        //Set the Code text for the barcode
                        bb.CodeText = textBox1.Text;

                        //Set the symbology type to Code128
                        if (textBox1.Text.Length == 13)
                        {
                            bb.SymbologyType = Symbology.EAN13;    
                        }
                        if (textBox1.Text.Length == 11)
                        {
                            bb.SymbologyType = Symbology.Code11;
                        }
                        if (textBox1.Text.Length == 8)
                        {
                            bb.SymbologyType = Symbology.EAN8;
                        }
                        
                        pictureBox3.Visible = true;
                        pictureBox3.Image = bb.BarCodeImage;
 
                        textBox1.Text = "";
                    } 
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarCodeBuilder bb = new BarCodeBuilder();

            //Set the Code text for the barcode
            bb.CodeText = textBox1.Text;

            //Set the symbology type to Code128
            
            pictureBox3.Visible = true;
            pictureBox3.Image = bb.BarCodeImage;
        }
    }
}
