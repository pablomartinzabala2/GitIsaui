using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos;
public partial class FrmAbmAlumno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CodAlumno"] !=null)
            {
                Int32 CodALumno = Convert.ToInt32(Session["CodAlumno"]);
                CargarAlumno(CodALumno);
            }
        }
    }

    private void CargarAlumno(Int32 CodAlumno)
    {
        cAlumno alumno = new cAlumno();
        DataTable tb = alumno.GetAlumnoxCodAlumno(CodAlumno);
        if (tb.Rows.Count >0)
        {
            txtCodAlumno.Text = CodAlumno.ToString();
            txtApellido.Text = tb.Rows[0]["Apellido"].ToString();
            txtNombre.Text = tb.Rows[0]["Nombre"].ToString();
        }
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        cFunciones fun = new cFunciones();
        if (txtApellido.Text =="")
        {
            Mensaje("Debe seleccionar un apellido");
            return;
        }

        if (txtNombre.Text =="")
        {
            Mensaje("Debe ingresar un nombre");
            return;
        }

        if (txtNroDocumento.Text  =="")
        {
            Mensaje("Debe ingresar un número de documento");
            return;
        }

        string Apellido = "";
        string Nombre = "";
        string NroDoc = "";
        string Telefono = "";
        Int32 CodAlumno = 0;

        if (txtCodAlumno.Text != "")
            CodAlumno = Convert.ToInt32(txtCodAlumno.Text);
        Apellido = txtApellido.Text;
        Nombre = txtNombre.Text;
        Telefono = txtTelefono.Text;
        NroDoc = txtNroDocumento.Text;
        cAlumno alumno = new cAlumno();
       

        if (txtCodAlumno.Text =="")
        {
            alumno.Agregar(Apellido, Nombre, NroDoc, Telefono);
        }
        else
        {
            alumno.Modificar(CodAlumno, Apellido, Nombre, NroDoc, Telefono);
        }
        if (chkRegistrar.Checked==false)
        {
            Response.Redirect("FrmListadoAlumnos.aspx");
        }
        else
        {
            txtCodAlumno.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtNroDocumento.Text = "";
            txtTelefono.Text = "";
            Mensaje("Datos grabados correctamente");
        }
    }
    /*
    public void Mensaje(string Msj)
    {
        string Cuerpo = "<script language=javascript>alert('" + Msj + "');</script>";
        //Response.Write("<script language=javascript>alert('hola');</script>");
        Response.Write(Cuerpo);
    }
    */

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
            "   <div class=\"modal-body\">" + Msj + "</div>     <div class=\"modal-footer\">   " +
            "   <button type=\"button\" class=\"btn btn-info\" data-dismiss=\"modal\">Cerrar</button> </div>  " +
            "  </div>  </div></div><script>$(\"#ventanaModal\").modal(\"show\");</script>";
        Response.Write(Cuerpo);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmListadoAlumnos.aspx");
    }
}