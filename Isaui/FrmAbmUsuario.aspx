﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmAbmUsuario.aspx.cs" Inherits="FrmAbmUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="contenido" AutoPostBack="false" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="text-center">
        <div class="form-signin"  >
         <img class="mb-4" src="./Iconos/logo-isaui.png" alt="" width="120px" > 
          <h1 class="h3 mb-3 font-weight-normal">Crear usuarios</h1>
          <label for="inputEmail" class="sr-only">Nombre de usuario</label>
          <asp:TextBox runat="server" ID="txtNombre" type="text" maxlength="50"   class="form-control" placeholder="Nombre de usuario"  ></asp:TextBox>
          <br>
            <label for="inputPassword" class="sr-only">Clave de usuario</label>
          <asp:TextBox  runat="server"ID="txtClave" type="password" MaxLength="25"   class="form-control" placeholder="Clave de usuario" ></asp:TextBox>
          <div class="checkbox mb-3">
            <label>
              <!--<input type="checkbox" value="remember-me">--> 
            </label>
          </div>
          <asp:Button OnClick="btnGuardar_Click" Text="Crear" runat="server" ID="btnGuardar" class="btn btn-lg btn-primary btn-block" > </asp:Button>
          <p class="mt-5 mb-3 text-muted"></p>
</div>


</div>
    
    </asp:Content>
