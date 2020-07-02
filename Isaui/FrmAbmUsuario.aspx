<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmAbmUsuario.aspx.cs" Inherits="FrmAbmUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="contenido" AutoPostBack="false" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="text-center">
        <div class="form-signin"  >
            
          <h1 class="h3 mb-3 font-weight-normal">Crear usuarios</h1>
            <div class="form-group">
          <label for="inputEmail" class="sr-only">Nombre de usuario</label>
          <asp:TextBox runat="server" ID="txtNombre" type="text" maxlength="50" OnTextChanged="validarUsuario"  class="form-control" placeholder="Nombre de usuario"  ></asp:TextBox>
          <br />
            <label for="inputPassword" class="sr-only">Clave de usuario</label>

          <asp:TextBox  runat="server" ID="txtClave" TextMode="Password" MaxLength="25" class="form-control" placeholder="Clave de usuario" ></asp:TextBox>
          </div>
                <div class="form-group">
             <label for="listDocentes" >Docentes: </label><asp:DropDownList class="form-control" runat="server" id="listDocentes"></asp:DropDownList>
          <div class="checkbox mb-3">
            </div>
          </div>
          <asp:Button OnClick="btnPrincipal_Click" style="margin:5px; width:130px;" Text="Volver" runat="server" ID="btnPrincipal" class="btn btn-info" > </asp:Button><asp:Button style="margin:5px; width:130px;" OnClick="btnGuardar_Click" Text="Crear" runat="server" ID="btnGuardar" class="btn btn-info" ></asp:Button>
          <p class="mt-5 mb-3 text-muted"></p>
</div>


</div>
    
     
    
    </asp:Content>
