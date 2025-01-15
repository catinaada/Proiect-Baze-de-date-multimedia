<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vizualizare.aspx.cs" Inherits="Proiect_BDM.Vizualizare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="StyleSheet1.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <div>
                     <ul>
                         <li>Proiect BDM - Catina Ada</li>
                         <li><a href="PrincipalPage.aspx" runat="server">Pagina Principala</a></li>
                          <li><a href="Inserare.aspx" runat="server">Inserare tablou</a></li>
                          <li><a href="Vizualizare.aspx" runat="server">Prelucrare tablouri</a></li>
                          <li><a href="Cautare.aspx" runat="server">Cautare tablouri</a></li>
                      </ul>
                </div>
            </nav>
        </div>

        <h2>Prelucrare tablouri</h2>

         <asp:Panel ID="Panel1" runat="server" BorderColor="#993366" BorderStyle="Double" >

             <br />
             &nbsp;Id-ul tabloului:
        <asp:TextBox ID="tb_id" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
             <asp:Button ID="btn_cautare" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" Height="36px" OnClick="btn_cautare_Click" Text="VIZUALIZARE" Width="222px" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:Image ID="Image1" runat="server" Height="265px" Width="275px" />
             <br />
             <br />
        <br />
        <br />
             Rotatie:&nbsp;
        <asp:TextBox ID="tb_rotatie" runat="server" OnTextChanged="tb_rotatie_TextChanged"></asp:TextBox>
&nbsp;
             <asp:Button ID="btn_roteste_tablou" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" OnClick="btn_roteste_tablou_Click" Text="ROTIRE" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btn_flip" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" OnClick="btn_flip_Click" Text="FLIP" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_greyscale" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" OnClick="btn_grey_Click" Text="GREYSCALE" />
             &nbsp;<br />
             <br />
             <br />
             <br />
             <asp:Label ID="Label1" runat="server"></asp:Label>
             <br />
             <br />
             &nbsp;</asp:Panel>

        
    </form>
</body>
</html>
