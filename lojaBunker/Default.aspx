<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 617px;
        }
        .auto-style2 {
            height: 18px;
        }
        .auto-style3 {
            height: 325px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div class="auto-style1">

        Cadastro de produtos (teste) :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Font-Bold="True"></asp:Label>
        <br />

        <br />
        <asp:Label ID="Label2" runat="server" Text="Marca"></asp:Label>
&nbsp;:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Família"></asp:Label>
&nbsp;:<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Modelo / Referência"></asp:Label>
&nbsp;:<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Voltagem :"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        Prazo Envio :<br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <br />
        Iluminação :<br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;<asp:Label ID="Label6" runat="server" Text="descrição :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:TextBox ID="TextBox7" runat="server" Height="162px" TextMode="MultiLine" Width="870px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </div>
      <div class="auto-style2">

          <br />
          <br />

      </div>  
    <div>
      <div id="content">
              
        <div class="auto-style3">
            Imagem do Produto :<br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
        <br />
        <asp:FileUpload ID="FileUploadControl" runat="server" class="multi" AllowMultiple="True" />
                      &nbsp;<br />
            <br />
                                          <asp:Label runat="server" id="StatusLabel" text=""  ForeColor="Red" />
                      <br />
                      <asp:Button ID="btnUpload" runat="server" Text=" Salvar dados do produto     "
                          onclick="btnUpload_Click" BackColor="#CC0000" BorderColor="#CC0000" Font-Bold="True" ForeColor="White" Height="54px" />                    
                      <br /> <br />
                     <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
                     </div>
              
                     <br class="clearfix" />             
        </div>

      </div>
    </form>
</body>
</html>
