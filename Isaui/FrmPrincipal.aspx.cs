using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //esta variable de sesion se puede utilizar para mostrar mensajes en el formulario principal
        if (Session["mensaje"] != null)
        { 
                var msj = Session["mensaje"].ToString();
                Session["mensaje"] = null;
                Mensaje(msj); 
        }

    }

    public void Mensaje(string Msj)
    {
        string Cuerpo = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.js\"></script>" +
            "<script src=\"https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js\"></script>" +
            "<script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js\" integrity=\"sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI\" crossorigin=\"anonymous\"></script>" +
            "<div class=\"modal fade\" id=\"ventanaModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"exampleModalCenterTitle\" " +
            "aria-hidden=\"true\">  <div class=\"modal-dialog modal-dialog-centered\" role=\"document\">  " +
            "<div class=\"modal-content\">      <div class=\"modal-header\">     " +
            " <h5 class=\"modal-title\" id=\"exampleModalLongTitle\">ISAUI</h5>       " +
            " <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">" +
            " <span aria-hidden=\"true\">&times;</span>       </button>      </div>   " +
            "   <div class=\"modal-body\">"+Msj+"</div>     <div class=\"modal-footer\">   " +
            "   <button type=\"button\" class=\"btn btn-info\" data-dismiss=\"modal\">Cerrar</button> </div>  " +
            "  </div>  </div></div><script>$(\"#ventanaModal\").modal(\"show\");</script>";
        Response.Write(Cuerpo);
    }
}