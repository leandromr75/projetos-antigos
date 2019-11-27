<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cursos - EAD</h1>
        <p class="lead">&nbsp;</p>
        <p class="lead">Cursos Disponíveis</p>
    </div>
    <div>          
            
            <video width="320" height="240" controls title="Video teste aula #1" poster="videos/ead.jpg">
            <source src=<% Response.Write( End.sit()); %> type="video/mp4">
            
            Your browser does not support the video tag.
            </video>
    </div>
    

    
</asp:Content>
