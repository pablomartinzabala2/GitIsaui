<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmListadoAlumnos.aspx.cs" Inherits="FrmListadoAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <h1>Listado de alumnos</h1>
</div>
<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Apellido"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Iconos/search.ico" Height="20px" OnClick="btnBuscar_Click" Width="20px" />
            </td>
            <td>
                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/Iconos/insert.ico" Height="20px" OnClick="btnAgregar_Click1" Width="20px" />
            </td>
        </tr>
    </table>
</div>
<div>
    <asp:GridView ID="Grilla" runat="server" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="BtnEditar" Width="20px" Height ="20px" runat="server" ImageUrl="~/Iconos/FOLDER100.ico" OnClick="BtnEditar_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="BtnEliminar" Width="20px" Height ="20px" runat="server" ImageUrl="~/Iconos/stop-error.ico" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CodAlumno" HeaderText="CodAlumno">
            <HeaderStyle Width="100px" />
            </asp:BoundField>
             <asp:BoundField DataField="Apellido" HeaderText="Apellido">
            <HeaderStyle Width="100px" HorizontalAlign="Left" />
            </asp:BoundField>
             <asp:BoundField DataField="Nombre" HeaderText="Nombre">
            <HeaderStyle Width="100px" />
            </asp:BoundField>
             <asp:BoundField DataField="NroDoc" HeaderText="Nro Doc">
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono">
            <HeaderStyle Width="100px" />
            </asp:BoundField> 
        </Columns>
    <HeaderStyle CssClass ="HeaderStyle" Height="25px" />
    <AlternatingRowStyle CssClass ="AlternatingRowStyle" />
    <RowStyle CssClass ="RowStyle" />
        <EditRowStyle CssClass ="EditRowStyle" />
    <FooterStyle CssClass ="FooterStyle" />
    </asp:GridView>
</div>
</asp:Content>

