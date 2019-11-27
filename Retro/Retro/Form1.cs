using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Retro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "1")
            {
                
                System.Diagnostics.Process.Start("Nigel.Bat");
            }
            
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (label1.Text == "1")
            {
                pictureBox1.Image = Retro.Properties.Resources.nm1;
                pictureBox2.Image = Retro.Properties.Resources.nm2;
                pictureBox3.Image = Retro.Properties.Resources.nm3;
                pictureBox8.Image = Retro.Properties.Resources.nm4;
                pictureBox7.Image = Retro.Properties.Resources.nm5;
                pictureBox9.Image = Retro.Properties.Resources.snes2;
                richTextBox1.Text = "Produtor: GameTek\nDesenvolvedor: Gremlin Graphics\nAno de Lançamento: 1992\n" +
                    "Gênero: Corrida\nPaís de Origem: Estados Unidos\nNúmero de Jogadores: 1\nCapacidade (Memória): 8 Mega";
                
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form list = new Lista();
            list.ShowDialog();
        }
    }
}
