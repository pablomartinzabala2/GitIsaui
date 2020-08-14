
 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrmAbmDocente.aspx.cs"  Inherits="FrmAbmDocente" %>
 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var idElimina=0;
      
        function setElimina(id){
            document.getElementById('hidden').value=id;
            idElimina=id;
            
        }
       
    </script> 
 <br/>
    <br/>
    
    <div runat="server" OnInit="inicializaForm">
        <div class="table-responsive">
            <table class ="table table-hover" style="border:1px solid rgba(237,237,237,1) ;" id="tabla-docente">
                <thead class="thead-light" >
                    <tr>
                        <th >Nombre</th>
                        <th >Apellido</th>
                        <th >Documento</th>
                        <th >Telefono</th>
                        <th >Email</th>
                        <th >Acciones</th>
                    </tr>
                </thead>
                <tbody>
                 <asp:Repeater id="repDocentes" runat="server" >
                    <ItemTemplate>
                     <tr>
                        <td><asp:Label  id="lblNombre" Text='<%# Eval("nombre")%>' runat="server" ></asp:Label></td>
                        <td><asp:Label id="lblApellido" Text='<%# Eval("apellido")%>' runat="server" ></asp:Label></td>
                        <td><asp:Label id="lblDocumento" Text='<%# Eval("nrodoc")%>' runat="server" ></asp:Label></td>
                        <td><asp:Label id="lblCelular" Text='<%# Eval("telefono")%>' runat="server" ></asp:Label></td>
                        <td><asp:Label id="lblCorreo" Text='<%# Eval("email")%>' runat="server" ></asp:Label></td>
                        <td><asp:LinkButton class="btn btn-outline-info" CommandName="EditarDocente" CommandArgument='<%# Eval("coddocente")%>' id="btnEditar" OnClick="EditarDocente"  ToolTip="Ver/editar" runat="server" ><span aria-hidden="true" class="fa fa-eye"></span></asp:LinkButton> 
                            <button type="button" tooltip="Eliminar" class="btn btn-outline-danger" onclick='setElimina(<%# Eval("coddocente")%>)' id="btnEliminar"  data-toggle="modal" data-target='#exampleModal<%# Eval("coddocente")%>' ><span aria-hidden="true" class="fa fa-trash"></span></button></td>
                            <!--<asp:Button   data-whatever="mensaje" id = "btnShowDialog"></asp:Button>-->
                        </tr>
                    
                    <!-- Modal -->
<div class="modal fade" id='exampleModal<%# Eval("coddocente")%>' tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Confirmar</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
             ¿Desea eliminar este docente? <span class="nombreDocente"></span>
      </div>
               
      <div class="modal-footer">
        <button type="button" class="btn btn-outline-danger" data-dismiss="modal">Cancelar</button>
        <asp:LinkButton runat="server" CommandName="EditarDocente" CommandArgument='<%# Eval("coddocente")%>' OnClick="EliminarDocente" id="btnConfirma" class="btn btn-outline-success" >Eliminar</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
                        </ItemTemplate>
                </asp:Repeater>
                
                </tbody>
            </table>
            </div>
        <hr>
        <asp:LinkButton style="margin:20px; color:white;" runat="server" id="btnNuevo" OnClick="NuevoDocente" class="btn btn-info" >Nuevo registro</asp:LinkButton>
    <br> 
    </div>
  
   
<br>
 <br>
  
<br>
</asp:Content>
    