<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmCicloLectivo.aspx.cs" Inherits="FrmCicloLectivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <div>
        <h1 >Ciclo Lectivo</h1>
    </div>
    <br />
    <div>
        <div>
            <label>Crear Ciclo Lectivo</label>
            <asp:TextBox ID="txtNameCL" runat="server" placeholder="Ej: 2020" TextMode="Number"></asp:TextBox>

            <asp:CheckBox ID="chkActive" runat="server" Text="ACTIVO" />
        </div>
        <div id="divSiCCL" class="alert alert-success" role="alert" style="display: none">
            <asp:Label ID="lblMjeSiCCL" runat="server" Text=""></asp:Label>
            <a class="close" data-dismiss="alert">×</a>
        </div>
        <div id="divNoCCL" class="alert alert-danger" role="alert"  style="display: none">
            <asp:Label ID="lblMjeNoCCL" runat="server" Text=""></asp:Label>
            <a class="close" data-dismiss="alert">×</a>
        </div>
        <div>
            <asp:Button ID="btnNewCL" runat="server" Text="Crear ciclo lectivo" class="btn btn-primary" OnClick="btnCreateCL_Click" />
        </div>
        <br />
    </div>
    <br />
    <div>
        <div >
            <div class="bg-secondary">
            <h3><asp:Label ID="Label1" runat="server" Text="El año activo es: " CssClass="text-white"></asp:Label>
            <asp:TextBox ID="txtActiveYear" runat="server" Enabled="false" Width="111px"></asp:TextBox>
                </h3>
                </div>
            <br />
            <label>Selecciones el Ciclo</label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="editar" id="editarAno">
            <div class="contenedor">
                <asp:Panel ID="panelEditar" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Ingrese nuevo año:"></asp:Label>
                    <asp:TextBox ID="txtAnoMod" runat="server" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                    <asp:CheckBox ID="cbAnoMod" runat="server" Text="ACTIVO" />
                    <asp:Button ID="btnAnoMod" class="btn btn-primary btn-sm" runat="server" Text="GUARDAR" OnClick="btnAnoMod_Click" />
                </asp:Panel>
            </div>
        </div>
        <div class="mjeconteiner">
            <div id="divPSiCCL" class="alert alert-success" role="alert" style="display: none">
            <asp:Label ID="lblMjePSiCCL" runat="server" Text=""></asp:Label>
            <a class="close" data-dismiss="alert">×</a>
        </div>
        <div id="divPNoCCL" class="alert alert-danger" role="alert"  style="display: none">
            <asp:Label ID="lblMjePNoCCL" runat="server" Text=""></asp:Label>
            <a class="close" data-dismiss="alert">×</a>
        </div>
        </div>
        <div class="btnContainer">

            <asp:Button ID="btnEditCL" runat="server" Text="Modificar" class="btn btn-primary" OnClick="btnEdit_Click" />
            <asp:Button ID="btnStartCL" runat="server" Text="Comenzar ciclo lectivo" class="btn btn-success" />


            <asp:Button ID="btnDeleteCL" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnDeleteCL_Click" />
        </div>
        <br />
    </div>
</asp:Content>


