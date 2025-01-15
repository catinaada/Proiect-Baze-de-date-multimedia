<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cautare.aspx.cs" Inherits="Proiect_BDM.Cautare" %>

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
                <div >
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
        <div>
            <h2>Cautare dupa diverse criterii</h2>

        </div>
        <div style="text-align:left">
             &nbsp;Cautare tablou dupa id-ul acestuia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Id tablou:&nbsp; <asp:TextBox ID="tb_nume" runat="server" OnTextChanged="tb_nume_TextChanged"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_cautare" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" Height="36px" OnClick="btn_cautare_Click" Text="CAUTARE TABLOU DUPA ID" Width="222px" />
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<br />
             <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <br />

                    Cautare tablouri dupa coeficientul de importanta :
                    <br />
                    <br />
                    <asp:Button ID="btn_generare_sem" runat="server" BorderStyle="Dotted" ForeColor="#660033" Height="34px" OnClick="btn_generare_sem_Click" style="margin-top: 0px" Text="GENERARE SEMNATURA" Width="269px" />

                    <br />

                    <br />
                    Fisierul de cautat:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <br />
                    <br />
                    &nbsp;Coeficient de importanta culoare: &nbsp;
                    <asp:TextBox ID="tb_culoare" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    &nbsp;Coeficient de importanta forma:&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="tb_forma" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    &nbsp;Coeficient de importanta textura:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tb_textura" runat="server"></asp:TextBox>
                    <br />
                    &nbsp;Coeficient de importanta locatie:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tb_locatie" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_regasire" runat="server" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" Height="36px" Text="CAUTARE " Width="222px" OnClick="btn_regasire_Click" />
                    &nbsp;&nbsp;&nbsp; &nbsp;Rezultat:&nbsp;&nbsp;
             <asp:TextBox ID="tb_rez" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
               
             
                    <br />
             <asp:Image ID="Image1" runat="server" Height="291px" Width="305px" />
               
             
             <br />
             <br />
             <br />
             Cautare tablouri dupa&nbsp; tema:<br />
             Tema: &nbsp;
             <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="166px">
                 <asp:ListItem>Portret</asp:ListItem>
                 <asp:ListItem>Flori</asp:ListItem>
                 <asp:ListItem>Peisaj</asp:ListItem>
                 <asp:ListItem>Abstract</asp:ListItem>
                 <asp:ListItem>Animale</asp:ListItem>
             </asp:DropDownList>
             &nbsp;&nbsp;
             <asp:Button ID="btn_cautare_tema" runat="server" OnClick="btn_cautare_tema_Click" Text="CAUTARE DUPA TEMA" BackColor="#660033" BorderColor="#660033" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="False" ForeColor="White" Height="36px"  Width="222px" />
             <br />
             <br />

               <asp:DataList ID="dataList" runat="server" RepeatColumns="3" CellPadding="5" Height="449px" Width="869px" style="margin-right: 3px; margin-left: 289px; margin-bottom: 5px;">
    <ItemTemplate>
        <div style="text-align: center; margin-left: auto; margin-right: auto;" > 
            <asp:Image  runat="server" ImageUrl ='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagine")) %>' Width="200" Height="200" />
            <p  style="font-family: Elephant; color:darkslateblue;"><%# Eval("Denumire") %></p>
            <p style="font-style: oblique; "><%# Eval("NumeArtist") %></p>
            <p >Categorie: <%# Eval("Tema") %></p>
            <p   style="color: cornflowerblue;"><%# Eval("Pret") %> RON</p>
        </div>
    </ItemTemplate>
</asp:DataList>

             <br />
             <br />
             <br />
               
             
             <br />
               
             
</div>

        </form>
</body>
</html>
