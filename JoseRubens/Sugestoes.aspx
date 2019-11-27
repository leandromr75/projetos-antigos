<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sugestoes.aspx.cs" Inherits="Sugestoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 358px;
            width: 391px;
        }
    </style>
</head>
<body style="height: 372px">
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <br />
        Nome:<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="190px"></asp:TextBox>
        <br />
        <br />
        E-Mail:<br />
        <asp:TextBox ID="TextBox2" runat="server" TabIndex="1" Width="190px"></asp:TextBox>
        <br />
        <br />
        Comentário:<br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Height="132px" MaxLength="500" TabIndex="2" TextMode="MultiLine" Width="190px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
    
    </div>
    </form>
</body>
</html>
