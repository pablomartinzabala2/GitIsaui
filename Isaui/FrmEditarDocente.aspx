<%@ Page Title="FrmEditarDocente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmEditarDocente.aspx.cs"  Inherits="FrmEditarDocente" %>

<asp:Content ID="BodyContent"  AutoPostBack="false" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <div class="cuadro-editar container " style="width:auto;">
 <div runat="server" AutoPostBack="false" OnInit="inicializaForm" class="form-group">
        <br>
        
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox class="form-control" runat="server" AutoPostBack="false" id="txtNombre"></asp:TextBox> 
         <br>
            <label for="txtApellido">Apellido :</label> 
            <asp:TextBox class="form-control" runat="server" AutoPostBack="false" id="txtApellido"></asp:TextBox>  
         <br>
            <label for="txtNroDocumento"> Nro. Documento :</label> 
            <asp:TextBox class="form-control" runat="server" AutoPostBack="false" id="txtNroDocumento"></asp:TextBox>  
        <br>
         
            <label for="txtCelular"> Celular :</label>
            <asp:TextBox class="form-control" runat="server" AutoPostBack="false" id="txtCelular"></asp:TextBox>  
         <br>
            <label for="txtCorreo"> Email :</label>
            <asp:TextBox class="form-control" runat="server" AutoPostBack="false" id="txtCorreo"></asp:TextBox> 
            <br>
          <asp:LinkButton style="margin:20px;" ToolTip="Volver" class="btn btn-outline-info" OnClick="verFormDocentes" id="btnVolver" runat="server" ><span aria-hidden="true" class="fa fa-arrow-alt-circle-left"></span> Ver Listado</asp:LinkButton>
            <asp:LinkButton class="btn btn-outline-success" style="margin:20px;"  id="btnEditar" data-toggle="modal" data-target="#exampleModal" AutoPostBack="false"  ToolTip="Guardar cambios" runat="server" ><span aria-hidden="true" class="fa fa-check-circle"></span> Guardar cambios</asp:LinkButton>
           
       
      
         </div>   
        
    </div>
    
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Confirmación</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
            ¿ Desea almacenar los cambios realizados ? <span class="nombreDocente"></span>
      </div>
               
      <div class="modal-footer">
        <button type="button" class="btn btn-outline-danger" data-dismiss="modal">Cancelar</button>
        <asp:LinkButton runat="server" OnClick="guardarDocente" id="btnConfirma" class="btn btn-outline-success" >Guardar</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<br>
 </asp:Content>