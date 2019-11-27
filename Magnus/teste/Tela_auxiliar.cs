using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace teste
{
    public partial class Tela_auxiliar : Form
    {
        public Tela_auxiliar()
        {
            InitializeComponent();
            dataGridView1.DataSource = Dal.Items_pendentes();
            dataGridView2.DataSource = Dal.Items_pendentes2();
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.Items_pendentes();
            dataGridView2.DataSource = Dal.Items_pendentes2();
        }
        
   
        
        
            
            
        
    }
}
