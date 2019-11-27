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
        public static string time = "";
        private void button1_Click(object sender, EventArgs e)
        {
           
            DateTime comp1 = Convert.ToDateTime(time);
            DateTime dt = DateTime.Now;
            string dat3 = Convert.ToString(dt);
            DateTime comp2 = Convert.ToDateTime(dat3);
            int result = DateTime.Compare(comp1,comp2);
            if (result < 0)
            {
                MessageBox.Show("data : " + time + " é anterior à " + dat3 );
            }
           
            //MessageBox.Show(Convert.ToString( dt));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dta = DateTime.Now;
            time = Convert.ToString(dta);
            
        }
    }
}
