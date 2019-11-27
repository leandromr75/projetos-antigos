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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string ean = "2000030051808";
            string ean = "2000030001808";
            string codigo = ean.Substring(1,5);
            string peso = ean.Substring(7,5);
            string und = peso.Substring(0,2);
            string primeiracasa = und.Substring(0,1);
            string segundacasa = und.Substring(1,1);
            string fracionado = peso.Substring(2,3);
            string junção = und + "," + fracionado;
            decimal dec = Convert.ToDecimal(junção);
            textBox1.Text = Convert.ToString(dec);

            if (primeiracasa == "0")
            {
                MessageBox.Show(ean + " ======> " + codigo + " =====> " + peso + " =======> " + segundacasa + "," + fracionado);    
            }
            else
            {
                MessageBox.Show( ean + " ======> " + codigo + " =====> " + peso + " =======> " + und + "," + fracionado); 
            }
            
            
        }
    }
}
