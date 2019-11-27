using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var x = "Leandro" ;
            x += " Ribeiro ";
            x += 102;
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("valor de X = " + x + "\nvalor de X na posição #2 = " + x[2]);
                System.Diagnostics.Debugger.Break();
                    
            }
            
            textBox1.Text = x;

        }
    }
}
