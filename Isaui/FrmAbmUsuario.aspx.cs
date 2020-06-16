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

        var r = usuario.Agregar(nombre, clave);
        if (r.Equals("ok")) {
            Session["mensaje"]="Usuario generado correctamente";
            Response.Redirect("FrmPrincipal.aspx");
        }
        else {
            this.Mensaje(r);
        }

    }
    protected void validarUsuario(object sender, EventArgs e)
    {
        cUsuario usuario = new cUsuario();
        if (!usuario.consultaUsuario(txtNombre.Text)){
            this.txtNombre.Text = "";
            Mensaje("El usuario ingresado ya está registrado en el sistema");
        }
    }

    protected void btnPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmPrincipal.aspx");
    }


    public void Mensaje(string Msj)

    {
       /* string Cuerpo = $"<script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.js\"></script>" +
            "<script src=\"https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js\"></script>" +
            "<script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js\" integrity=\"sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI\" crossorigin=\"anonymous\"></script>" +
            "<div class=\"modal fade\" id=\"ventanaModal\" " +
            $"tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"exampleModalCenterTitle\" " +
            $"aria-hidden=\"true\">  <div class=\"modal-dialog modal-dialog-centered\" role=\"document\">  " +
            $"  <div class=\"modal-content\">      <div class=\"modal-header\">     " +
            $"   <h5 class=\"modal-title\" id=\"exampleModalLongTitle\">ISAUI</h5>       " +
            $" <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">" +
            $"          <span aria-hidden=\"true\">&times;</span>       </button>      </div>   " +
            $"   <div class=\"modal-body\">{Msj}</div>     <div class=\"modal-footer\">   " +
            $"     <button type=\"button\" class=\"btn btn-info\" data-dismiss=\"modal\">Cerrar</button>  " +
            $"       </div>  " +
            "  </div>  </div></div><script>$(\"#ventanaModal\").modal(\"show\");</script>";
        //Response.Write("<script language=javascript>alert(\"hola\");</script>");
        Response.Write(Cuerpo);*/
    }

}