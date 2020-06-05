<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmAbmAlumno.aspx.cs" Inherits="FrmAbmAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Documento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Apellido"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Teléfono"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:CheckBox ID="chkRegistrar" Text ="Continúa registrando" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCodAlumno" Visible ="false" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" CssClass="Botones" />
                        </td>
                        <td>
                             <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Botones" OnClick="btnRegresar_Click" />   
                        </td>
                    </tr>
                </table>
                
                
            </td>
        </tr>
       
    </table>
</div>
<div>
    <table>
        <tr>
            <td>
               
            </td>
            <td>
                
            </td>
        </tr>
    </table>
</div>
</asp:Content>

