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
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
           
            this.Cursor = Cursors.Hand;
            pictureBox1.Width = 215;
            pictureBox1.Height = 187;
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox1.Width = 195;
            pictureBox1.Height = 167;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Nigel.Bat");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("1");
            visu.ShowDialog();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mariow.bat");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox3.Width = 215;
            pictureBox3.Height = 187;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox3.Width = 195;
            pictureBox3.Height = 167;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("2");
            visu.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mariok.bat");
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox7.Width = 215;
            pictureBox7.Height = 187;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox7.Width = 195;
            pictureBox7.Height = 167;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("3");
            visu.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("castle.bat");
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox9.Width = 215;
            pictureBox9.Height = 187;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox9.Width = 195;
            pictureBox9.Height = 167;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("4");
            visu.ShowDialog();
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("axelay.bat");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("5");
            visu.ShowDialog();
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("aero.bat");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("6");
            visu.ShowDialog();
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("sgg.bat");
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("7");
            visu.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("8");
            visu.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("dk.bat");
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("dk2.bat");
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("9");
            visu.ShowDialog();
        }

        private void pictureBox25_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox25.Width = 215;
            pictureBox25.Height = 187;


        }

        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("axelay.bat");
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            Form visu = new Visualiza("5");
            visu.ShowDialog();
        }

        private void pictureBox16_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox16_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox17_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox17.Width = 215;
            pictureBox17.Height = 187;
        }

        private void pictureBox17_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox17.Width = 195;
            pictureBox17.Height = 167;
        }

        private void pictureBox14_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox14_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox15_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox15.Width = 215;
            pictureBox15.Height = 187;
        }

        private void pictureBox15_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox15.Width = 195;
            pictureBox15.Height = 167;
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("aero.bat");
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            Form visu = new Visualiza("6");
            visu.ShowDialog();
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            Form visu = new Visualiza("7");
            visu.ShowDialog();
        }

        private void pictureBox12_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("sgg.bat");
        }

        private void pictureBox13_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox13.Width = 215;
            pictureBox13.Height = 187;

        }

        private void pictureBox13_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox13.Width = 195;
            pictureBox13.Height = 167;
        }

        private void pictureBox12_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("dk.bat");
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            Form visu = new Visualiza("8");
            visu.ShowDialog();
        }

        private void pictureBox10_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox10_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox11_MouseEnter_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox11.Width = 215;
            pictureBox11.Height = 187;
        }

        private void pictureBox11_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox11.Width = 195;
            pictureBox11.Height = 167;
        }

        private void pictureBox24_Click_1(object sender, EventArgs e)
        {
            Form visu = new Visualiza("9");
            visu.ShowDialog();
        }

        private void pictureBox24_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Help;
        }

        private void pictureBox24_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox25_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("dk2.bat");
        }

        private void pictureBox25_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox25.Width = 195;
            pictureBox25.Height = 167;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("dk3.bat");
        }

        private void pictureBox23_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox23.Width = 215;
            pictureBox23.Height = 187;
        }

        private void pictureBox23_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox23.Width = 195;
            pictureBox23.Height = 167;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Form visu = new Visualiza("10");
            visu.ShowDialog();
        }
    }
}
