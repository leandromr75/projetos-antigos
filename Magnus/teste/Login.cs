using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace teste
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "#magnus_edu")
            {
               
                DateTime date2 = new DateTime(2014,07,20,13,08,50);
                   
                DateTime d = DateTime.Now;

                DateTime date1 = new DateTime(2014,08,01,13,08,50);
                int result = DateTime.Compare(date1,d);
                int result2 = DateTime.Compare(date2, d);
                if (result2 < 0)
                {
                    MessageBox.Show("O Sistema expira em 01/08/2014");
                }
                if (result > 0)
                {
                    Tela_inicial tl = new Tela_inicial();
                    tl.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("O Sistema Expirou!");
                    
                }
                    
                
                 
                 
             }
            else
            {
                MessageBox.Show("Senha Incorreta!");
            }

                

           
                   
                
               
        
            
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
