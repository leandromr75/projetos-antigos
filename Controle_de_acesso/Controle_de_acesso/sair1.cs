using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_acesso
{
    public partial class sair1 : Form
    {
        public sair1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "#15101982#")
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Entre com a senha de administrador para parar a execução");
                this.Close();
            }
        }
    }
}
