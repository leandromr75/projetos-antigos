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
    public partial class Login3 : Form
    {
        public Login3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "#magnus_edu_admin")
            {
                Movimento mov = new Movimento();
                mov.Show();
                this.Visible = false;
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
    }
}
