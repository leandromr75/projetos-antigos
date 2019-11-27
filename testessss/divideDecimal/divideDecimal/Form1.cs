using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace divideDecimal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                decimal temp1 = Convert.ToDecimal(textBox1.Text) * Convert.ToDecimal(textBox2.Text);
                MessageBox.Show(Convert.ToString(temp1));
                return;
            }
            decimal temp = Convert.ToDecimal(textBox1.Text) / Convert.ToDecimal(textBox2.Text);
            MessageBox.Show(Convert.ToString(temp));
        }
    }
}
