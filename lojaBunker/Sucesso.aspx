<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sucesso.aspx.cs" Inherits="Sucesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 430px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        Cadastro e Imagem foram salvos.<br />
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/uploads/site/morning.gif" Width="204px" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="55px" OnClick="Button1_Click" Text="OK" Width="104px" />
        <br />
        <br />
        <br />

        <img src="uploads/fotos/site48.JPG" width="100" height="100" />
    </div>
    </form>
</body>
</html>
