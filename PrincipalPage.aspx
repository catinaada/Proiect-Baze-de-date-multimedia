<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrincipalPage.aspx.cs" Inherits="Proiect_BDM.PrincipalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proiect BDM</title>
    <link rel="stylesheet" href="StyleSheet1.css"/>
</head>
<body >
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

        <h1>
            Galerie de arta online
        </h1>
        <h3>Locul perfect unde isi pot expune lucrarile pictorii romani</h3>
        <br />
        <hr />
        <br/>
        
        
        <br />
        <br />
       
        <div >
           <asp:DataList ID="dataList" runat="server" RepeatColumns="3" CellPadding="5" Height="449px" Width="869px" style="margin-right: 3px; margin-left: 289px; margin-bottom: 5px;">
                 <ItemTemplate>
                          <div style="text-align: center; margin-left: auto; margin-right: auto;" > 
                           <asp:Image  runat="server" ImageUrl ='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Imagine")) %>' Width="200" Height="200" />
                          <p style="font-family: Elephant; color:darkslateblue;"><%# Eval("Denumire") %></p>
                          <p style="font-style: oblique; "><%# Eval("NumeArtist") %></p>
                           <p >Categorie: <%# Eval("Tema") %></p>
                           <p style="color: cornflowerblue;"><%# Eval("Pret") %> RON</p>
        </div>
    </ItemTemplate>
</asp:DataList>
            
        <asp:Label ID="label_mesaj" runat="server" Text=""></asp:Label>
        </div>
        <div style="margin-left: 64px; margin-right: 64px; border:medium double #800080; border-block-color:purple; padding: 20px 20px" >
            <h4>BUN VENIT LA GALERIAMEA </h4>
            <h4>TABLOURI MODERNE DE VANZARE ONLINE</h4>
            <p  >
GaleriaMea este o galerie de arta specializata in vanzarea de tablouri moderne, originale semnate de catre artisti contemporani din Romania. Misiunea noastra este simpla: de a conecta iubitorii de arta si colectionarii cu picturi originale de vanzare si semnate de talentati pictori din Romania.

Fiecare tablou prezentat pe GaleriaMea este original, unic si semnat de catre artist. Altfel spus, noi nu vindem reproduceri. Fiecare tablou este pictat manual. Am incercat sa selectam unii dintre cei mai buni artisti din Romania. Unii artisti sunt deja faimosi altii sunt tineri, in asteptarea de a fi descoperiti. Sa-i ajutam investind in arta lor unica. Daca esti in cautarea de tablouri canvas, detinem si magazinul GaleriaQ.ro, pe care de asemenea il poti vizita.</p>
           
        </div>
       <video width="560" height="450" controls>
            <source src="Video.mp4" type="video/mp4">
        </video>
    </form>
</body>
</html>
