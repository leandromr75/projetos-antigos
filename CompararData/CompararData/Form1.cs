using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompararData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime data1 = new DateTime(DateTime.Now.Year,DateTime.Now.Month,
                DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);

            DateTime data2 = new DateTime(2015,7,14,16,04,0);

            int resilt = DateTime.Compare(data1, data2);
            if (resilt < 0)
            {
                MessageBox.Show(Convert.ToString(data1) +  " é anterior à  " + 
                    Convert.ToString(data2));    
            }
            else
            {
                MessageBox.Show(Convert.ToString(data1) + " é posterior à  " +
                    Convert.ToString(data2));  
            }

            
        }
    }
}
