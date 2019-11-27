using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Controle_de_acesso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }
        bool vai = false;
        string limpa = DateTime.Now.ToShortDateString();
        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Text += String.Format(" Arquivo Excluído: {0}, {1}", e.FullPath, Environment.NewLine);
            //richTextBox1.Text += String.Format(" Nome: {0} {1}", e.Name, Environment.NewLine);
            //richTextBox1.Text += String.Format(" Evento: {0} {1}", e.ChangeType, Environment.NewLine);
            richTextBox1.Text += String.Format(" Data: " + DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString() + "\n");
            
            richTextBox1.Text += String.Format("---------------------------------------------------------- {0}", Environment.NewLine);
                      

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            richTextBox3.Text += String.Format(" Arquivo Modificado: {0}, {1}", e.FullPath, Environment.NewLine);
            //richTextBox3.Text += String.Format(" Nome: {0} {1}", e.Name, Environment.NewLine);
            //richTextBox3.Text += String.Format(" Evento: {0} {1}", e.ChangeType, Environment.NewLine);
            richTextBox3.Text += String.Format(" Data: " + DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString() + "\n");
            
            richTextBox3.Text += String.Format("---------------------------------------------------------- {0}", Environment.NewLine);
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            richTextBox2.Text += String.Format(" Arquivo Criado: {0}, {1}", e.FullPath, Environment.NewLine);
            //richTextBox2.Text += String.Format(" Nome: {0} {1}", e.Name, Environment.NewLine);
            //richTextBox2.Text += String.Format(" Evento: {0} {1}", e.ChangeType, Environment.NewLine);
            richTextBox2.Text += String.Format(" Data: " + DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString() + "\n");
            
            richTextBox2.Text += String.Format("---------------------------------------------------------- {0}", Environment.NewLine);
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            richTextBox4.Text += String.Format(" Arquivo Renomeado: {0}, {1}", e.FullPath, Environment.NewLine);
            //richTextBox4.Text += String.Format(" Nome: {0} {1}", e.Name, Environment.NewLine);
            //richTextBox4.Text += String.Format(" Evento: {0} {1}", e.ChangeType, Environment.NewLine);
            richTextBox4.Text += String.Format(" Data: " + DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString() + "\n");
            
            richTextBox4.Text += String.Format("---------------------------------------------------------- {0}", Environment.NewLine);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkBox2.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
            }
        }

        private void iniciarLOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                label7.Text = "Status: Monitorando Pastas";
                pictureBox2.Visible = true;
                //caminho da pasta que o FileSystemWatcher irá monitorar (atribuo o valor do TextBox)
                fileSystemWatcher1.Path = textBox1.Text;
                //tipos de filtro que o FileSystemWatcher irá considerar
                fileSystemWatcher1.Filter = textBox2.Text;
                //lista de atributos que irão disparar eventos
                fileSystemWatcher1.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
                //permitir a monitoração (sem o valor estar como true, é impossível do FSW monitorar os arquivos)
                fileSystemWatcher1.EnableRaisingEvents = checkBox1.Checked;
                //monitorar subdiretórios (atribuo o valor do checkbox. Como está checado, assume o valor true)
                fileSystemWatcher1.IncludeSubdirectories = checkBox2.Checked;
                //uso a propriedade abaixo como false para evitar o erro de chamada ilegal de thread, que pode
                //acessar um controle em outra thread aconteça. Se isso acontecer, será disparado uma exceção.
                CheckForIllegalCrossThreadCalls = false;
                //uso do WaitForChangedResults (mostrado no artigo) para Windows Services e Console Application's
                //instancio a classe WaitForChangedResults, passando o FSW com o método WaitForChanged e dois
                //parâmetros: o tipo de modificações que ele irá aguardar, que no caso são todas, e o tempo de
                //espera para que sejam disparados estes eventos, que será de 10 segundos.
                WaitForChangedResult wcr = fileSystemWatcher1.WaitForChanged(WatcherChangeTypes.All, 10000);
                //faço uma verificação, se der Timeout (passar o tempo esperado de 10 segundos),
                //disparo um aviso. Se não der Timeout, exibo o Nome do Evento e o Tipo dele.
                /*if (wcr.TimedOut)
                {
                    richTextBox1.Text += "Já se passaram 10 minutos do evento";

                }
                else
                {
                    richTextBox1.Text += "Evento: " + wcr.Name, wcr.ChangeType.ToString();
                }*/
            }
            catch (Exception)
            {

                throw;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string data1 = DateTime.Now.ToShortDateString();
            if (limpa != data1)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                richTextBox3.Text = "";
                richTextBox4.Text = "";
                limpa = DateTime.Now.ToShortDateString();
            }

            data1 = data1.Replace("/", "-");
            if (vai == false)
            {
                string message = "Você deseja carregar o LOG da data atual?";
                string caption = "LOG";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    richTextBox1.LoadFile(data1 + "_deletados.rtf", RichTextBoxStreamType.PlainText);
                    richTextBox2.LoadFile(data1 + "_criados.rtf", RichTextBoxStreamType.PlainText);
                    richTextBox3.LoadFile(data1 + "_modificados.rtf", RichTextBoxStreamType.PlainText);
                    richTextBox4.LoadFile(data1 + "_renomeados.rtf", RichTextBoxStreamType.PlainText);
                }
                vai = true;
            }
            

            richTextBox1.SaveFile(data1 + "_deletados.rtf", RichTextBoxStreamType.PlainText);
            richTextBox2.SaveFile(data1 + "_criados.rtf", RichTextBoxStreamType.PlainText);
            richTextBox3.SaveFile(data1 + "_modificados.rtf", RichTextBoxStreamType.PlainText);
            richTextBox4.SaveFile(data1 + "_renomeados.rtf", RichTextBoxStreamType.PlainText);
        }

        private void carregarLogExcluídosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText);
            }
        }

        private void carregarLogCriadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox2.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void carregarLogModificadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox3.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void carregarLogRenomeadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox4.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software licenciado para ArtChik Produtos Publicitários");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sai = new sair1();
            sai.ShowDialog();
        }

       
    }
}
