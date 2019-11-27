using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Retro
{
    public partial class Visualiza : Form
    {
        public Visualiza(string numero)
        {
            InitializeComponent();
            if (numero == "1")
            {
                pictureBox1.Image = Retro.Properties.Resources.nm1;
                pictureBox2.Image = Retro.Properties.Resources.nm2;
                pictureBox3.Image = Retro.Properties.Resources.nm3;
                pictureBox8.Image = Retro.Properties.Resources.nm4;
                pictureBox7.Image = Retro.Properties.Resources.nm5;
                
                
            }

            if (numero == "2")
            {
                pictureBox1.Image = Retro.Properties.Resources._21;
                pictureBox2.Image = Retro.Properties.Resources._22;
                pictureBox3.Image = Retro.Properties.Resources._23;
                pictureBox8.Image = Retro.Properties.Resources._24;
                pictureBox7.Image = Retro.Properties.Resources._25;
                                
            }
            if (numero == "3")
            {
                pictureBox1.Image = Retro.Properties.Resources._31;
                pictureBox2.Image = Retro.Properties.Resources._32;
                pictureBox3.Image = Retro.Properties.Resources._33;
                pictureBox8.Image = Retro.Properties.Resources._34;
                pictureBox7.Image = Retro.Properties.Resources._35;

            }
            if (numero == "4")
            {
                pictureBox1.Image = Retro.Properties.Resources._41;
                pictureBox2.Image = Retro.Properties.Resources._42;
                pictureBox3.Image = Retro.Properties.Resources._43;
                pictureBox8.Image = Retro.Properties.Resources._44;
                pictureBox7.Image = Retro.Properties.Resources._45;

            }
            if (numero == "5")
            {
                pictureBox1.Image = Retro.Properties.Resources._51;
                pictureBox2.Image = Retro.Properties.Resources._52;
                pictureBox3.Image = Retro.Properties.Resources._53;
                pictureBox8.Image = Retro.Properties.Resources._54;
                pictureBox7.Image = Retro.Properties.Resources._55;

            }
            if (numero == "6")
            {
                pictureBox1.Image = Retro.Properties.Resources._61;
                pictureBox2.Image = Retro.Properties.Resources._62;
                pictureBox3.Image = Retro.Properties.Resources._63;
                pictureBox8.Image = Retro.Properties.Resources._64;
                pictureBox7.Image = Retro.Properties.Resources._65;

            }
            if (numero == "7")
            {
                pictureBox1.Image = Retro.Properties.Resources._71;
                pictureBox2.Image = Retro.Properties.Resources._72;
                pictureBox3.Image = Retro.Properties.Resources._73;
                pictureBox8.Image = Retro.Properties.Resources._74;
                pictureBox7.Image = Retro.Properties.Resources._75;

            }
            if (numero == "8")
            {
                pictureBox1.Image = Retro.Properties.Resources._81;
                pictureBox2.Image = Retro.Properties.Resources._82;
                pictureBox3.Image = Retro.Properties.Resources._83;
                pictureBox8.Image = Retro.Properties.Resources._84;
                pictureBox7.Image = Retro.Properties.Resources._85;

            }
            if (numero == "9")
            {
                pictureBox1.Image = Retro.Properties.Resources._91;
                pictureBox2.Image = Retro.Properties.Resources._92;
                pictureBox3.Image = Retro.Properties.Resources._93;
                pictureBox8.Image = Retro.Properties.Resources._94;
                pictureBox7.Image = Retro.Properties.Resources._95;

            }
            if (numero == "10")
            {
                pictureBox1.Image = Retro.Properties.Resources._101;
                pictureBox2.Image = Retro.Properties.Resources._102;
                pictureBox3.Image = Retro.Properties.Resources._103;
                pictureBox8.Image = Retro.Properties.Resources._104;
                pictureBox7.Image = Retro.Properties.Resources._105;

            }
        }
        
        private void Visualiza_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
