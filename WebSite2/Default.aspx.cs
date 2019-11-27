using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "1")
        {
            
         Response.ContentType = "application/exe";
         //Response.AddHeader("content-disposition", "attachment; filename=Gerenciador_Comercial.exe");
         Response.TransmitFile(@"D:\Projetos_Visual_Studio\teste\teste\bin\Debug\teste.exe");
         Response.End();
        }
        else
        {
            Label3.Visible = true;
        }
    }
}