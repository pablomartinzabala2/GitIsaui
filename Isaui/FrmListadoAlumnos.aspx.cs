using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
public partial class FrmListadoAlumnos : System.Web.UI.Page
{
    //hola agustina
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarAlumnos();
        }
    }

    private void CargarAlumnos()
    {
        cAlumno alumno = new cAlumno();
        DataTable trdo = alumno.GetAlumnos();
        Grilla.DataSource = trdo;
        Grilla.DataBind();
    }

    protected void BtnEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton BtnEditar = sender as ImageButton;
        GridViewRow row = (GridViewRow)BtnEditar.NamingContainer;
        Int32 CodAlumno = Convert.ToInt32(row.Cells[2].Text);
        Session["CodAlumno"] = CodAlumno.ToString();
        Response.Redirect("FrmAbmAlumno.aspx");
    }

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[2].Attributes.Add("style", "display:none");
        }
    }

   

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnAgregar_Click1(object sender, ImageClickEventArgs e)
    {
        Session["CodAlumno"] = null;
        Response.Redirect("FrmAbmAlumno.aspx");
    }
}