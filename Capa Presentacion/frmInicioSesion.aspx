<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicioSesion.aspx.cs" Inherits="LogisticaBercam.frmInicioSesion" %>
<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>LOGIN</title>
  <script src="https://s.codepen.io/assets/libs/modernizr.js" type="text/javascript"></script>


  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

  
      <link rel="stylesheet" href="css/style.css">

  
</head>

<body>
<div class="login">
  <header class="header">
    <span class="text">LOGIN</span>
    <span class="loader"></span>
  </header>
      <%--<form class="form">--%> 
  <form id="form1" class="form" runat="server">
      <div>
         <asp:Image ID="imgLogoBer" runat="server" ImageUrl="~/Bercam/LogoBercam.jpg" Width="100px" Height="80px"/>
          <hr />
     <%-- </div>      
       <div>--%>
            <input runat="server" class="input" type="text" placeholder="Usuario" id="us">
            <input runat="server" class="input" type="password" placeholder="Password" id="pass">
            <button runat="server" class="btn" type="submit" onserverclick="Button1_Click"></button>      
         <%--OnClick="BtnAceptar_Click>--%>          <%--<asp:Button runat="server" class="btn" type="submit" OnClick="BtnAceptar_Click>/>--%>
            <%--<asp:Button ID="BtnAceptar" runat="server" CssClass="btn" type="submit" OnClientClick="Button1_Click" OnClick="Button1_Click" Visible="true"/>--%>
       </div>
  </form>
</div>
    <%--<button class ="resetbtn" type= "reset">Reset it--%><%--</button>--%>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

    <script src="js/index.js"></script>

</body>
</html>










<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
