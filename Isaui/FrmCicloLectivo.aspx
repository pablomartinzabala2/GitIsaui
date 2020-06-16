<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmCicloLectivo.aspx.cs" Inherits="FrmCicloLectivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <div>
        <div>
            <label>Crear Ciclo Lectivo</label>
            <asp:TextBox ID="txtNFecha" runat="server" placeholder="Ej: 2020"></asp:TextBox>
        </div>
        <asp:Button ID="BtnCrearCLectivo" runat="server" Text="Crear ciclo lectivo" class="btn-primary" OnClick="BtnCrearCLectivo_Click" />
        <br />
    </div>
    <br />
    <div>
        <div>
            <label>Selecciones el Ciclo</label>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>
        <asp:Button ID="btnComenzar" runat="server" Text="Comenzar ciclo lectivo" class="btn-primary" />

        <asp:Button ID="btnModificar" runat="server" Text="Modificar ciclo lectivo" class="btn-primary" />

        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar ciclo lectivo" class="btn-primary" OnClick="btnEliminar_Click" />
        <br />
    </div>


</asp:Content>


