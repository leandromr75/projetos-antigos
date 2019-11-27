using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace FT_Comercio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //fornece valores iniciais ao carregar o form
            dataGridView1.DataSource = Dal.Listar_Produtos();
            dataGridView3.DataSource = Dal.Listar_Clientes();
            comboBox1.Text = "Caixa";
            textBox3.Text = "Consumidor";
            textBox4.Text = "xxxxx";
            dataGridView4.DataSource = Dal.Ultimo_Pedido();
            dataGridView2.DataSource = Dal.Listar_Pedidos
                (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

            //faz a soma do Total
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            }
            //formata saída com conf. local de moeda
            label11.Text = String.Format("{0:C2}", sum);
        
        }


        private void button10_Click(object sender, EventArgs e)
        {


            string promptValue = Prompt.ShowDialog("Quantidade:", "FT Comércio");
            Int32 qtde;
            if (int.TryParse(promptValue.Trim(), out qtde) == false)
            {
                MessageBox.Show("Quantidade incorreta");
                return;
            }

            if (qtde == 1)
            {
                //faz verificação de existe produto selecionado
                if (dataGridView1.SelectedCells.Count != 0 
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
                {
                        DateTime d = DateTime.Now;
                        string s = d.ToString("dd/MM/yyyy");



                        Dal.Incluir_Pedido(1, textBox2.Text, comboBox1.SelectedItem.ToString(), Convert.ToDecimal(textBox1.Text), label9.Text,
                            Convert.ToInt32( dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()),s,"Aguardando");
                        dataGridView2.DataSource = Dal.Listar_Pedidos
                            (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                        double sum = 0;
                        for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                        {
                            sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                        }
                    
                        label11.Text = String.Format("{0:C2}", sum);
                        dataGridView1.DataSource = Dal.Listar_Produtos();

                }
                else
                {
                    MessageBox.Show("Favor Selecionar Produto!!");
                }

                
            }
            if (qtde > 1)
            {
                //faz verificação de existe produto selecionado
                if (dataGridView1.SelectedCells.Count != 0 
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
                {
                        DateTime d = DateTime.Now;
                        string s = d.ToString("dd/MM/yyyy");

                       

                        Dal.Incluir_Pedido(Convert.ToInt32( promptValue), textBox2.Text, comboBox1.SelectedItem.ToString(), (Convert.ToDecimal(textBox1.Text) * qtde), label9.Text,
                            Convert.ToInt32( dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()),s,"Aguardando");
                        dataGridView2.DataSource = Dal.Listar_Pedidos
                            (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                        double sum = 0;
                        for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                        {
                            sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                        }
                    
                        label11.Text = String.Format("{0:C2}", sum);
                        dataGridView1.DataSource = Dal.Listar_Produtos();

                }
                else
                {
                    MessageBox.Show("Favor Selecionar Produto!!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //faz verificação se produto já está cadastrado e insere novo produto
            if (dataGridView1.SelectedCells.Count != 0 
                && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
            {

                MessageBox.Show("Produto já cadastrado!!");
            }
            else
            {
                try
                {
                    //verifica se campos estão vazios
                    if (String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox1.Text) == false)
                    {
                    
                        decimal number;
                        if (Decimal.TryParse(textBox1.Text, out number))
                        {
                            Dal.Inserir_Produto(textBox2.Text, Convert.ToDecimal(textBox1.Text));
                            MessageBox.Show("Produto cadastrado com sucesso!!");
                        }
                        else
                            MessageBox.Show("Valor em formato incorreto!! Utilizar vírgula para centavos");
                    
                    }
                    else
                    {
                        MessageBox.Show("Campos Vazios!!");
                    }
                
                }
                catch
                {
                    throw;
                }
                finally
                {
                    //código que será sempre executado
                    dataGridView1.DataSource = Dal.Listar_Produtos();
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox2.Focus();
                }
            }
            
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //faz verificação antes de excluír produto
            if (dataGridView1.SelectedCells.Count != 0
               && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
               && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
            {
                string message = "Você deseja excluír o Produto selecionado?";
                string caption = "FT Comércio";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {

                    int num = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString());
                    Dal.Excluir_Produto(num);
                    dataGridView1.DataSource = Dal.Listar_Produtos();
                    textBox1.Text = null;
                    textBox2.Text = null;
                    MessageBox.Show("Produto excluído com sucesso!!");
                }
                

            }
            else
                MessageBox.Show("Favor selecionar Produto para exclusão!!");

       }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            dataGridView1.DataSource = Dal.Listar_Produtos();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            //faz verificação e alteração dos produtos
            if (dataGridView1.SelectedCells.Count != 0
                && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() != textBox2.Text
                || dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() != textBox1.Text)
            {
                if (String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox1.Text) == false)
                    
                {
                    try
                    {

                        int num = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString());
                        Dal.Alterar_Produto(num, textBox2.Text, Convert.ToDecimal(textBox1.Text));

                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {

                        dataGridView1.DataSource = Dal.Listar_Produtos();
                        textBox1.Text = null;
                        textBox2.Text = null;
                        MessageBox.Show("Dados alterados com sucesso!!");

                    }
                }
                else
                {
                    MessageBox.Show("Campos Vazios!!");
                }
           
           }

            //verifica se houve alteração nos dados antes de inserir
            if (dataGridView1.SelectedCells.Count != 0
               && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
               || dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
            {
                MessageBox.Show("Não foram modificados os dados!!");
            }
            
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
        
        }


        private void button9_Click(object sender, EventArgs e)
        {
            
            if (dataGridView3.SelectedCells.Count != 0 
                && dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox3.Text
                && dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox4.Text)
            {
                MessageBox.Show("Cliente já cadastrado!!");
            }    
            
            else
            {
                try
                {
                    
                    if (String.IsNullOrEmpty(textBox3.Text) == false && String.IsNullOrEmpty(textBox4.Text) == false)
                    {

                        if (textBox3.Text == "Consumidor")
                        {
                            MessageBox.Show("Não é necessário cadastrar Consumidor!!");
                        }
                        else
                        {
                            Dal.Inserir_Cliente(textBox3.Text, textBox4.Text);
                            MessageBox.Show("Cliente cadastrado com sucesso!!");
                        }  

                     }
                                 
                    else
                    {
                        MessageBox.Show("Campos Vazios!!");
                    }

                }
                catch
                {
                    throw;
                }
                finally
                {
                    dataGridView3.DataSource = Dal.Listar_Clientes();
                    
                }
            }
          }


        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            textBox4.Text = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
        }


        private void button8_Click(object sender, EventArgs e)
        {

            if (dataGridView3.SelectedCells.Count != 0
               && textBox3.Text != "Consumidor"
               && textBox4.Text != "xxxxx")
            {
                
                string message = "Você deseja excluír o Cliente selecionado?";
                string caption = "FT Comércio";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                   
                    if (dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox3.Text
                        && dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox4.Text)
                    {
                        int num = Convert.ToInt32(dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString());
                        Dal.Excluir_Clientes(num);
                        MessageBox.Show("Cliente excluído com sucesso!!");
                        dataGridView3.DataSource = Dal.Listar_Clientes();

                        textBox3.Text = "Consumidor";
                        textBox4.Text = "xxxxx";
                    }
                    else
                    {
                        MessageBox.Show("Não é possível excluír Cliente não cadastrado!!");
                    }

                }
            }
            else
                MessageBox.Show("Favor selecionar um Cliente para exclusão!!");
            
        }


        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            dataGridView3.DataSource = Dal.Listar_Clientes();
        }


        private void button5_Click(object sender, EventArgs e)
        {

            if (dataGridView3.SelectedCells.Count != 0 && textBox3.Text != "Consumidor")
            {

                if (String.IsNullOrEmpty(textBox3.Text) == false && String.IsNullOrEmpty(textBox4.Text) == false)
                {

                    
                    if (dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() != textBox3.Text 
                        || dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() != textBox4.Text )
                    {
                        
                        try
                        {

                            Dal.Alterar_Clientes(Convert.ToInt32
                                (dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()),textBox3.Text, textBox4.Text);

                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {

                            dataGridView3.DataSource = Dal.Listar_Clientes();
                            textBox1.Text = null;
                            textBox2.Text = null;
                            MessageBox.Show("Dados alterados com sucesso!!");

                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Campos Vazios!!");
                }
                
              
            }

            /*if (dataGridView3.SelectedCells.Count != 0
               && dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox3.Text
               && dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox4.Text)
            {
                MessageBox.Show("Não foram modificados os dados!!");
            }*/
        }


        private void button11_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Consumidor";
            textBox4.Text = "xxxxx";
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedCells.Count == 0)
            {
                label9.Text = textBox3.Text;
                dataGridView3.DataSource = Dal.Listar_Clientes();
            }
            else 
            {
                MessageBox.Show("Orçamento não finalizado");
            }
        }


        private void button15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedCells.Count != 0)
            {
                Dal.Excluir_Pedido(Convert.ToInt32 (dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString()));
                dataGridView2.DataSource = Dal.Listar_Pedidos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                }

                label11.Text = String.Format("{0:C2}", sum);
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            Impressao relat = new Impressao();
            relat.Show();
            Dal.Update_Contador();
            dataGridView4.DataSource = Dal.Ultimo_Pedido();
            dataGridView2.DataSource = Dal.Listar_Pedidos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
            label9.Text = "Consumidor";
            label11.Text = "R$ 0,00";
            textBox2.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "Caixa";
            
        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Informar a Quantidade deste Ítem ", "FT Comércio");
            Int32 qtde;
            if (int.TryParse(promptValue.Trim(), out qtde) == false)
            {
                MessageBox.Show("Quantidade incorreta");
                return;
            }

            if (promptValue == null)
            {
                //faz verificação de existe produto selecionado
                if (dataGridView1.SelectedCells.Count != 0
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
                {
                    DateTime d = DateTime.Now;
                    string s = d.ToString("dd/MM/yyyy");



                    Dal.Incluir_Pedido(1, textBox2.Text, comboBox1.SelectedItem.ToString(), Convert.ToDecimal(textBox1.Text),  label9.Text,
                        Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()), s, "Aguardando");
                    dataGridView2.DataSource = Dal.Listar_Pedidos
                        (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }

                    label11.Text = String.Format("{0:C2}", sum);
                    dataGridView1.DataSource = Dal.Listar_Produtos();

                }
                else
                {
                    MessageBox.Show("Favor Selecionar Produto!!");
                }


            }
            if (promptValue != null)
            {
                //faz verificação de existe produto selecionado
                if (dataGridView1.SelectedCells.Count != 0
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
                {
                    DateTime d = DateTime.Now;
                    string s = d.ToString("dd/MM/yyyy");

                    decimal tot = Convert.ToDecimal(promptValue) * Convert.ToDecimal(textBox1.Text);

                    Dal.Incluir_Pedido(Convert.ToInt32(promptValue), textBox2.Text, comboBox1.SelectedItem.ToString(), Convert.ToDecimal(textBox1.Text),  label9.Text,
                        Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()), s, "Aguardando");
                    dataGridView2.DataSource = Dal.Listar_Pedidos
                        (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }

                    label11.Text = String.Format("{0:C2}", sum);
                    dataGridView1.DataSource = Dal.Listar_Produtos();

                }
                else
                {
                    MessageBox.Show("Favor Selecionar Produto!!");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedCells.Count == 0)
            {
                Pesquisa pesq = new Pesquisa();
                pesq.Show();    
            }
            else
            {
                MessageBox.Show("Existem Items que não foram impressos!!");
            }
            
        }

        
        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            string s = e.KeyChar.ToString();
            dataGridView1.DataSource = Dal.Localiza(Convert.ToChar(s));
            
        }

        private void dataGridView3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string r = e.KeyChar.ToString();
            dataGridView3.DataSource = Dal.Localiza_Cliente(Convert.ToChar(r));
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Quantidade:", "FT Comércio");
            Int32 qtde;
            if (int.TryParse(promptValue.Trim(), out qtde) == false)
            {
                MessageBox.Show("Quantidade incorreta");
                return;
            }

            if (qtde == 1)
            {
                //faz verificação de existe produto selecionado
                if (dataGridView1.SelectedCells.Count != 0
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
                {
                    DateTime d = DateTime.Now;
                    string s = d.ToString("dd/MM/yyyy");



                    Dal.Incluir_Pedido(1, textBox2.Text, comboBox1.SelectedItem.ToString(), Convert.ToDecimal(textBox1.Text), label9.Text,
                        Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()), s, "Aguardando");
                    dataGridView2.DataSource = Dal.Listar_Pedidos
                        (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }

                    label11.Text = String.Format("{0:C2}", sum);
                    dataGridView1.DataSource = Dal.Listar_Produtos();

                }
                else
                {
                    MessageBox.Show("Favor Selecionar Produto!!");
                }


            }
            if (qtde > 1)
            {
                //faz verificação de existe produto selecionado
                if (dataGridView1.SelectedCells.Count != 0
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString() == textBox2.Text
                    && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString() == textBox1.Text)
                {
                    DateTime d = DateTime.Now;
                    string s = d.ToString("dd/MM/yyyy");

                    

                    Dal.Incluir_Pedido(Convert.ToInt32(promptValue), textBox2.Text, comboBox1.SelectedItem.ToString(), (Convert.ToDecimal(textBox1.Text) * qtde ), label9.Text,
                        Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()), s, "Aguardando");
                    dataGridView2.DataSource = Dal.Listar_Pedidos
                        (Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));

                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    }

                    label11.Text = String.Format("{0:C2}", sum);
                    dataGridView1.DataSource = Dal.Listar_Produtos();

                }
                else
                {
                    MessageBox.Show("Favor Selecionar Produto!!");
                }
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            string email = textBox4.Text;
            if (String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Favor selecionar ou cadastrar novo e-mail");
            }
            else
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.outlook.com";
                client.EnableSsl = true;
                
                client.Credentials = new NetworkCredential("leandromr75@outlook.com", "#lecoteco1975#");
                

               

                /*OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Cursor Files|*.pdf";
                dialog.Title = "Selecione um orçamento para enviar";

                // Show the Dialog.
                // If the user clicked OK in the dialog and
                // a .CUR file was selected, open it.
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Assign the cursor in the Stream to the Form's Cursor property.
                    Attachment at = new Attachment(dialog.FileName);
                    
                    MailMessage message = new MailMessage();
                    
                    //message.From = new MailAddress("leandromrxx75@gmail.com","teste#");
                    //message.To.Add = (new MailAddress(email,"teste"));
                    

                    message.Subject = "Olá";
                    
                    message.Priority = MailPriority.High;
                    message.Attachments.Add(at);*/
                    
                    client.Send("leandromr75@outlook.com",Convert.ToString( email), "Olá", "Segue orçamento em anexo conforme combinado");
                    
                //}
            }
        }
    }
}
