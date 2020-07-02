<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmCicloLectivo.aspx.cs" Inherits="FrmCicloLectivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <!-- Modal-->
    <div class="modal fade" id="ventanaModalAction" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header p-3 mb-2 bg-warning text-white">
                    <h5 class="modal-title" id="exampleModalLongTitle">
                        <asp:Label ID="lblTituloModal" runat="server" Text="Label"></asp:Label>
                    </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMjeModal" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAceptarEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnAceptarEliminar_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- -->
    <div id="ContHead" class="form-control-file card-header">
        <h1 class="text-info font-weight-bold font-italic">Ciclo Lectivo</h1>
    </div>
    <div id="ContBody" class="form-control-file display:flex col-sm-12 row justify-content-center h-100 align-items-center">

        <div id="contAnoAct" class="bg-secondary card col-sm-7 align-self-center text-center form-signin shadow">
            <h3>
                <asp:Label ID="Label1" runat="server" Text="AÑO LECTIVO: " CssClass="text-white font-weight-light"></asp:Label>
                <asp:Label ID="lblActiveYear" runat="server" Text=" 2020" class="text-warning font-weight-bold"></asp:Label>
            </h3>
        </div>
       <br />
        <div class="mjeconteiner form-signin shadow">

            <div id="divASiCCL" class="alert alert-success" role="alert" style="display: none">
                <asp:Label ID="lblMjeASiCCL" runat="server" Text=""></asp:Label><button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>

            </div>
            <div id="divANoCCL" class="alert alert-danger" role="alert" style="display: none">
                <asp:Label ID="lblMjeANoCCL" runat="server" Text=""></asp:Label>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>

            </div>
        </div>

        <div id="contCrearEditar" class="card shadow form-signin">
            <div class="card-body">
            <asp:Panel ID="panelCrear" runat="server" >
                <div>
                    <h3 class="font-weight-bold">Crear</h3>
                </div>
                <asp:Label ID="Label3" runat="server" Text="Ingresar Ciclo Lectivo: "></asp:Label>
                <asp:TextBox ID="txtNameCL" runat="server" placeholder="Ej: 2020" TextMode="Number"></asp:TextBox>
                <asp:CheckBox ID="chkActive" runat="server" Text=" Activar" />
                <asp:Button ID="btnNewCL" runat="server" Text="Guardar" class=" btn btn-primary" OnClick="btnCreateCL_Click" />
                
            </asp:Panel>
</div>
            <div class="card-body">
            <asp:Panel ID="panelEditar" runat="server" >
                <div>
                    <h3 class="font-weight-bold">Editar</h3>
                </div>
                <div class="bg-info">
                    <h5>
                        <asp:Label ID="lblEditar" runat="server" Text="Editar" CssClass="text-white"></asp:Label></h5>
                </div>
                <asp:Label ID="Label2" runat="server" Text="Ingresar Ciclo Lectivo: "></asp:Label>
                <asp:TextBox ID="txtAnoMod" runat="server" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                <asp:CheckBox ID="chkAnoMod" runat="server" Text=" Activar" />
                <asp:Button ID="btnAnoMod" class="btn btn-primary btn-sm" runat="server" Text="Guardar" OnClick="btnAnoMod_Click" />
                <asp:TextBox ID="txtCod" runat="server" Visible="false" Width="16px"></asp:TextBox>
            </asp:Panel>
            </div>
            
        </div>

        <div id="contBuscar" class="card shadow form-signin">
            <asp:Panel ID="panelBuscar" runat="server">
                <div>
                    <h3 class="font-weight-bold">Buscar</h3>
                </div>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="" placeholder="Buscar fecha" TextMode="Number"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass=" btn btn-success" OnClick="btnBuscar_Click" />

                        </td>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Volver" CssClass=" btn btn-info" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        
        <div id="ContTable" class="card shadow form-signin">
            <asp:GridView ID="gvCL" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowDataBound="gvCL_RowDataBound" PageSize="2" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" horizontalalign="Right" GridLines="Vertical" >
                <Columns>
                    <asp:BoundField DataField="CodCiclo" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />

                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Iconos/saveas.ico" OnClick="btnEditar_Click" class="Iconabm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Iconos/stop-error.ico" OnClick="btnEliminar_Click" class="Iconabm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>


