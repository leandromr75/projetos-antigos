using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Vendedor.NomeVendedor = "Wendell";
            label1.Text = "";
            label2.Text = "";
            button1.Focus();
            button2.Visible = false;
            button3.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            GerenciadorDeFormulario.Abre(form2);
            
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.Date.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
            button1.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vendedor.NomeVendedor = "Leandro";
        }

       
        private void button2_Click_2(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                button2.Visible = false;
                button3.Visible = false;
                string cor = this.BackColor.ToString();
                MessageBox.Show(cor);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.BackColor = Form1.DefaultBackColor;
            
            button2.Visible = false;
            button3.Visible = false;
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
        }
    }
}
