<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inserare.aspx.cs" Inherits="Proiect_BDM.Inserare" %>

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
       
        <br />
        <h2>Adaugare tablou</h2>
      
        <hr />
        <br />
        <asp:Panel ID="Panel1" runat="server" BorderColor="#993366" BorderStyle="Double" Height="334px" style="margin-left: 440px; margin-top: 0px; margin-right: 15px;" Width="583px">
            <br />
            Id tablou:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_id" runat="server"></asp:TextBox>
            <br />
            <br />
            Nume artist:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_nume_artist" runat="server"></asp:TextBox>
            <br />
            <br />
            Denumire tablou:&nbsp;
            <asp:TextBox ID="tb_den_tablou" runat="server"></asp:TextBox>
            <br />
            <br />
            Tema tablou:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="164px">
                <asp:ListItem>Portret</asp:ListItem>
                <asp:ListItem>Peisaj</asp:ListItem>
                <asp:ListItem>Flori</asp:ListItem>
                <asp:ListItem>Abstract</asp:ListItem>
                <asp:ListItem>Animale</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Pret:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_pret" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Alege fisier:
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
            <br />
        
   
            &nbsp;

   
            <asp:Button ID="btn_inserare" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" OnClick="Button1_Click" Text="ADAUGA TABLOU" Height="36px" Width="222px" />
            &nbsp;

        </asp:Panel>

        <br />



            <br />
            <asp:Label ID="label_mesaj" runat="server" BorderColor="#993366" BorderStyle="Ridge" BorderWidth="2px" Font-Bold="True" Font-Italic="True" Font-Names="Comic Sans MS" Font-Size="Medium" Height="29px" style="margin-left: 0px; margin-top: 0px" Text=" Poti introduce datele!" Width="271px"></asp:Label>
            <br />
            <br />

    </form>
</body>
</html>
