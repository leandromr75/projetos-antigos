using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void FileUploadControl_DataBinding(object sender, EventArgs e)
    {
        StatusLabel.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DirectoryInfo arquivos = new DirectoryInfo(Server.MapPath("~/fotos/"));
        // Pega todas as imagens .gif

        GridView1.DataSource = arquivos.GetFiles("*.*");
        // vincula os dados no listbox 

        GridView1.DataBind();
    }
}