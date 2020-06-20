﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmCicloLectivo.aspx.cs" Inherits="FrmCicloLectivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <div>
        <div>
            <label>Crear Ciclo Lectivo</label>
            <asp:TextBox ID="txtNFecha" runat="server" placeholder="Ej: 2020"></asp:TextBox>
            <asp:CheckBox ID="cbActivo" runat="server" Text="ACTIVO" />
        </div>
        <asp:Button ID="BtnCrearCLectivo" runat="server" Text="Crear ciclo lectivo" class="btn btn-primary" OnClick="BtnCrearCLectivo_Click" />
        <br />
    </div>
    <br />
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="El año activo es: "></asp:Label>
            <asp:TextBox ID="txtAnoActivo" runat="server" Enabled="false" Width="111px" OnTextChanged="txtAnoActivo_TextChanged"></asp:TextBox>
            <br />
            <label>Selecciones el Ciclo</label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="editar" id="editarAno">
            <div class="contenedor">
                <asp:Panel ID="panelEditar" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Ingrese nuevo año:"></asp:Label>
                    <asp:TextBox ID="txtAnoMod" runat="server" AutoPostBack="true" OnTextChanged="txtAnoMod_TextChanged"></asp:TextBox>
                    <asp:CheckBox ID="cbAnoMod" runat="server" Text="ACTIVO" OnCheckedChanged="cbAnoMod_CheckedChanged" />
                    <asp:Button ID="btnAnoMod" class="btn btn-primary btn-sm" runat="server" Text="GUARDAR" OnClick="btnAnoMod_Click" />
                </asp:Panel>
            </div>
        </div>
        <div class="btnContainer">
            <asp:Button ID="btnComenzar" runat="server" Text="Comenzar ciclo lectivo" class="btn btn-success" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-primary" OnClick="btnModificar_Click" />

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />
        </div>
        <br />
    </div>
</asp:Content>


