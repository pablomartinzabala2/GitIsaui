<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmCicloLectivo.aspx.cs" Inherits="FrmCicloLectivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
<div >
    <div><label>Selecciones el Ciclo</label> <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></div>
    <button class="btn-primary ">Comenzar ciclo lectivo</button>
    <br />
</div>

    <div >
    <div><label>Crear Ciclo Lectivo</label> <input type="text" id="txtNFecha" placeholder="Ej: 2020"  class="text-center form-control" /></div>
        <asp:Button ID="BtnCrearCLectivo" runat="server" Text="Crear ciclo lectivo" class="btn-primary " OnClick="BtnCCL"/>
        
    <br />
</div>
</asp:Content>


