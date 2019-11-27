using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
            
        Label7.Text = Convert.ToString(Convert.ToInt32(DAL.PegaIdSite()) + 1);
        
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
                 if (FileUploadControl.PostedFile.ContentLength < 8388608)
                {
                    try
                    {
                        if (FileUploadControl.HasFile)
                        {
                            try
                            {
                                //Aqui ele vai filtrar pelo tipo de arquivo
                                if (FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                                    FileUploadControl.PostedFile.ContentType == "image/png" ||
                                    FileUploadControl.PostedFile.ContentType == "image/gif" ||
                                    FileUploadControl.PostedFile.ContentType == "image/bmp")
                                {
                                    try
                                    {
                                        //Obtem o  HttpFileCollection
                                        HttpFileCollection hfc = Request.Files;
                                        for (int i = 0; i < hfc.Count; i++)
                                        {
                                            HttpPostedFile hpf = hfc[i];
                                            if (hpf.ContentLength > 0)
                                            {
                                                //Pega o nome do arquivo
                                                string nome = System.IO.Path.GetFileName(hpf.FileName);
                                                //Pega a extensão do arquivo
                                                string extensao = Path.GetExtension(hpf.FileName);
                                                //Gera nome novo do Arquivo numericamente
                                                string filename = string.Format("{0:00000000000000}", GerarID());
                                                //Caminho a onde será salvo
                                                //string filename = "site";
                                               
                                                // AQUI VC JOGA ISSU PARA UMA IMAGEM ... O RESTO E MOLEZA :P

                                                
                                               
                                               hpf.SaveAs(Server.MapPath("~/uploads/fotos/") + filename + extensao);

                                               //Prefixo p/ img pequena
                                               var prefixoP = "site" + Label7.Text;
                                               Label1.Text = filename + extensao;

                                                //pega o arquivo já carregado
                                               string pth = Server.MapPath("~/uploads/fotos/") + filename + extensao;
                                               
                                                //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                               Redefinir.resizeImageAndSave(pth, 1024, 768, prefixoP);
                                               DAL.InsereSite(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, prefixoP + extensao);

                                               //Page.Response.Redirect(Page.Request.RawUrl);
                                               Page.Controls.Clear();
                                               Response.Redirect("Sucesso.aspx",false);
                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    // Mensagem se tudo ocorreu bem
                                    StatusLabel.Text = "Todas imagens carregadas com sucesso!";

                                }
                                else
                                {
                                    // Mensagem notifica que é permitido carregar apenas 
                                    // as imagens definida la em cima.
                                    StatusLabel.Text = "É permitido carregar apenas imagens!";
                                }
                            }
                            catch (Exception ex)
                            {
                                // Mensagem notifica quando ocorre erros
                                StatusLabel.Text = "O arquivo não pôde ser carregado. O seguinte erro ocorreu: " + ex.Message;
                            }
                    }
                }
                catch (Exception ex)
                {
                    // Mensagem notifica quando ocorre erros
                    StatusLabel.Text = "O arquivo não pôde ser carregado. O seguinte erro ocorreu: " + ex.Message;
                }
            }
            else
            {
                // Mensagem notifica quando imagem é superior a 8 MB
                StatusLabel.Text = "Não é permitido carregar mais do que 8 MB";
            }
       
        
        
    }
    public Int64 GerarID()
    {
        try
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            string s = data.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            return Convert.ToInt64(s);
        }
        catch (Exception erro)
        {

            throw;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void FileUploadControl_DataBinding(object sender, EventArgs e)
    {
        
    }
}