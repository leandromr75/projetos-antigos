using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int contador = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            /*int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            MessageBox.Show("resolução da tela = " + x + " x " + y);*/
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.xml";
            openFileDialog1.Title = "Select a Cursor File";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.
                
                string caminho = openFileDialog1.FileName;
                
                
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(caminho); //Carregando o arquivo

                //Pegando elemento pelo nome da TAG
                

                XmlNodeList xnList = xmlDoc.GetElementsByTagName("prod");


                
                //Usando foreach para imprimir na tela
                foreach (XmlNode xn in xnList)
                {
	                string codProd = xn["cProd"].InnerText;
                    string descrição = xn["xProd"].InnerText;
                    string codEAN = xn["cEAN"].InnerText;
                    string codEANTrib = xn["cEANTrib"].InnerText;
                    string qtde = xn["qCom"].InnerText;
                    string und = xn["uCom"].InnerText;
                    string valor = xn["vProd"].InnerText;
                    

                    Dal.Inserir(codProd, descrição, codEAN, codEANTrib, qtde, und, valor);
                    
                    
	
	                
                    
                }
                 dataGridView1.DataSource = Dal.Listar();
                 comboBox1.DataSource = null; 
                 comboBox1.DataSource = Dal.Listar();
                 comboBox1.ValueMember = "Id";
                 comboBox1.DisplayMember = "Descrição";
                 comboBox1.SelectedItem = "";
                 comboBox1.Refresh();
               
             }
                
          }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            Dal.InserirData(time);
            dataGridView1.DataSource = Dal.MostrarData();
            string time2 = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            time2.Replace("/","-");
            DateTime date2 = new DateTime(2015, 04, 06, 11, 10, 00);
            DateTime date3 = new DateTime(2014, 07, 19, 13, 08, 50);
            
            //int result = DateTime.Compare(Convert.ToDateTime( time2),time);
            int result = DateTime.Compare(Convert.ToDateTime( time2),date2);
            if (result > 0)
            {
                MessageBox.Show("expirou");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* SqlConnection sqlConnection1 = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Teste;User ID=sa;Password=#lecoteco1975 ;");
            SqlCommand cmd = new SqlCommand();
            Object returnValue;

            cmd.CommandText = "SELECT data FROM Table_1 WHERE id = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            returnValue = cmd.ExecuteScalar();
            textBox1.Text = returnValue.ToString();

            sqlConnection1.Close();*/
            DateTime t = Convert.ToDateTime(Dal.Mostrar());
            String.Format("{0:G}", t);  // "9/3/2008 16:05:07"	
            textBox1.Text = Convert.ToString( t);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Text = "Atualizando sistema: aguarde por favor";
            contador = 0;
            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*progressBar1.PerformStep();
            contador++;
            if (contador >= 6)
            {
                label1.Text = "Sistema atualizado com sucesso!";
                timer1.Enabled = false;
            }*/
            
            dataGridView1.DataSource = Dal.Medir();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BACKUP DATABASE Rancheiros TO DISK ='d:\\rancheiros.bak' ");
            sb.Append("WITH FORMAT, ");
            sb.Append("MEDIANAME = 'd', ");
            sb.Append("NAME = 'Backup total Teste';");
            
            
            
            
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=#lecoteco1975 ;");
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            
            sqlConnection1.Close();
            cmd.Dispose();

            
            
            
            
            
            
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=#lecoteco1975 ;");
            SqlCommand cmd = new SqlCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append("RESTORE DATABASE Rancheiros FROM DISK =N'D:\\rancheiros.bak' ");
            sb.Append("WITH  FILE = 1, ");
            sb.Append("NOUNLOAD,  ");
            sb.Append("STATS = 10");

            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Medir();
        }  
        

        
    }
}
