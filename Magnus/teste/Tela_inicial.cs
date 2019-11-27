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
    public partial class Tela_inicial : Form
    {
        public Tela_inicial()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form_principal fp = new Form_principal();
            fp.Show();
            this.Visible = false;
            
                       
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login2 log = new Login2();
            log.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Você deseja sair do aplicativo?";
            string caption = "Magnus Açaí";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {


                // Closes the parent form.
                Application.Exit();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            teste.Taxa taxa = new Taxa();
            taxa.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login3 log2 = new Login3();
            log2.Show();
            this.Visible = false;
        }
    }
}
