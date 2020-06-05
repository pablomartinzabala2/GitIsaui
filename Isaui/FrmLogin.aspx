<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmLogin.aspx.cs" Inherits="FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
  <link href="Estilo/HojaEstilo.css" rel="stylesheet" />
        <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
    </style>
</head>
<body style="background-color :black">
    <form id="form1" runat="server">
        <div style="min-height:100px"></div>
        <div class ="DivCentrado">
            <div class ="DivEncabezado">

                <asp:Label ID="Label3" runat="server" Text="Iniciar Sesión"></asp:Label>

            </div>
            <div style ="width:300px;height:10px">

            </div>
            <div class ="DivDetalle">
                <table style="empty-cells;">
                    <tr>
                        <td>
                            Usuario:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" Width="296px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contraseña:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="296px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnIngresar" runat="server" OnClick="BtnIngresar_Click" Text="Ingresar" CssClass="Fuente" Height="40px" Width="296px" BackColor="#009933" Font-Size="X-Large" ForeColor="White" />
                        </td>
                    </tr>
        </table>
            </div>
        
    </div>
    </form>
</body>
</html>
