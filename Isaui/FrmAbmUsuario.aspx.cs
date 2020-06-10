using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos;
public partial class FrmAbmUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (txtNombre.Text == "")
        {
            Mensaje("Debe ingresar un nombre de usuario");
            return;
        }

        if (txtClave.Text == "")
        {
            Mensaje("Debe ingresar una clave de usuario");
            return;
        }
        var nombre = txtNombre.Text;
        var clave = txtClave.Text;
        cUsuario usuario = new cUsuario();

        usuario.Agregar(nombre, clave);

    }

    public void Mensaje(string Msj)
    {
        string Cuerpo = $"<div class=\"modal fade\" id=\"exampleModalCenter\" " +
            $"tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"exampleModalCenterTitle\" " +
            $"aria-hidden=\"true\">\n  <div class=\"modal-dialog modal-dialog-centered\" role=\"document\">\n  " +
            $"  <div class=\"modal-content\">\n      <div class=\"modal-header\">\n     " +
            $"   <h5 class=\"modal-title\" id=\"exampleModalLongTitle\">ISAUI</h5>\n       " +
            $" <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\n" +
            $"          <span aria-hidden=\"true\">&times;</span>\n        </button>\n      </div>\n   " +
            $"   <div class=\"modal-body\">\n {Msj} \n      </div>\n      <div class=\"modal-footer\">\n   " +
            $"     <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Cerrar</button>\n  " +
            $"       </div>\n  " +
            $"  </div>\n  </div>\n</div>";
        //Response.Write("<script language=javascript>alert('hola');</script>");
        Response.Write(Cuerpo);
    }

}