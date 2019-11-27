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
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
            textBox1.Focus();
            textBox1.Select();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "#magnus_edu_admin")
            {
                Cadastro cad = new Cadastro();
                cad.Show();

                this.Visible = false;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            lo.Show();


        }
    }
}
