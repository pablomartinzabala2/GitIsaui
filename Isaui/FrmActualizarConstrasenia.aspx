<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmActualizarConstrasenia.aspx.cs" Inherits="FrmActualizarConstrasenia" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9.15.1/dist/sweetalert2.all.min.js"></script>
    <script type = "text/javascript">

        function alerta() {
            Swal.fire({

                icon: 'success',
                title: 'Los datos se han actualizado correctamente',
                showConfirmButton: false,
                timer: 1500,
            });
        };

        function alertaError() {
            Swal.fire({
            icon: 'error',
            title: 'Ups parace que algunos de los datos no coinciden :(',
            ShowConfirmButton: false,
                
            });
        }

        function alertaVacio() {
            Swal.fire({
                icon: 'warning',
                title: 'Debes complentar los campos',
                ShowConfirmButton: false,

            });
        }

    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <div class="container">
        <div class="row">
        <div class="col-sm-12">
        <h1>Cambiar Contraseña</h1>
        </div>
        </div>
        <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
        <p>"Usuario" Podras cambiar tu contraseña rellenando los siguientes cambios</p>
        <form id="form1" runat="server">
           
        <asp:TextBox ID="passvieja" type="password" runat="server"  ClientIDMode="Static" CssClass="input-lg form-control" placeholder="tu contraseña anterior" AutoCompleteType="Disabled"></asp:TextBox>
       
       <br/>
        <asp:TextBox ID="passnueva" type="password" runat="server" CssClass="input-lg form-control" placeholder="Nueva Contraseña" AutoCompleteType="Disabled"></asp:TextBox>
        <div class="row">
        </div>
        <br/>
        <asp:TextBox ID="passnueva2" type="password" runat="server" CssClass="input-lg form-control" placeholder="Repetir Contraseña" AutoCompleteType="Disabled"></asp:TextBox>
        
        <div class="row">
        <div class="col-sm-12">
        <br />
        <asp:Button runat="server" CssClass="col-xs-12 btn btn-primary btn-load btn-lg" Text="Cambiar Contraseña"  OnClick="Unnamed1_Click"/>
      
        </div>
        
    </form>
            </div><!--/col-sm-6-->
        </div><!--/row-->
        </div>
</body>
     
    
</html>
