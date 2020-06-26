<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmAbmCarreras.aspx.cs" Inherits="FrmAbmCarreras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />                                                                  
    <div>
        <div>  
            <h1>
            Carreras
            </h1>
            
        </div>

    </div>
    
    <div>
        <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    </div>
    
    <div>
        <br />
        
        <asp:Panel ID="pnlMostrar" runat="server"  Visible="true">
            <asp:DropDownList ID="ddlCarreras" runat="server" OnSelectedIndexChanged="ddlCarreras_SelectedIndexChanged">

            </asp:DropDownList>

            <asp:TextBox ID="txtNombre" runat="server">
            </asp:TextBox>  
            
            <br />
         <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" OnClick="btnCambiar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </asp:Panel>
    </div>
    

</asp:Content>

