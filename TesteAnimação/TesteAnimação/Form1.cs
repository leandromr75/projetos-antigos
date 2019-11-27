using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TesteAnimação
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 0;
        int y = 0;
        int w = 20;
        int z = 580;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
      
            if (w <= 340)
            {
                 panel1.SetBounds(x,y,w,z);
                 w = w + 5;
                 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.SetBounds(0, 0, 20, 580);
        }
    }
}
