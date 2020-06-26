using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

public partial class FrmAbmCarreras : System.Web.UI.Page
{
    cCarreras cC = new cCarreras();
    DataTable dt = new DataTable();
    string getNombre;
    int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarDdlCarrera();
            pnlMostrar.Visible = true;
        }
    }
    public void Botonera(int indice)
    {
        switch (indice) {
            case 1:
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnCambiar.Enabled = false;
                btnCancelar.Enabled = false;
                break;

            case 2:
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnCambiar.Enabled = true;
                btnCancelar.Enabled = true;
                break;
        } 

    }

    private void cargarDdlCarrera()
    {
       dt = cC.getTodo();
        ddlCarreras.DataSource = dt;
        ddlCarreras.DataBind();
        ddlCarreras.DataTextField = "Nombre";
        ddlCarreras.DataValueField = "CodCarrera";
        ddlCarreras.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        pnlMostrar.Enabled = Visible;
        ddlCarreras.Visible = true;
        Botonera(2);
        btnCambiar.Text = "Crear";
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        
        string nombre = txtNombre.Text;
        cCarreras cC = new cCarreras();
        if (txtNombre.Text != "")
        {
            cC.agregarCarrera(nombre);
        }
        else
        {
            int id = int.Parse(ddlCarreras.SelectedValue);
            cC.modificarCarrera(nombre,id);
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        pnlMostrar.Enabled = Visible;
        Botonera(2);
        btnCambiar.Text = "Aceptar";
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {//hacer mensaje de confirmacion para eliminar
        
        int cod = int.Parse(ddlCarreras.SelectedValue);
        cC.eliminarCarrera(cod);
        cargarDdlCarrera();

    }

    protected void ddlCarreras_SelectedIndexChanged(object sender, EventArgs e)
    {
        select();
    }
    public void select()
    {
        if (pnlMostrar.Visible == true)
        {
            Int32 CodCar = Convert.ToInt32(ddlCarreras.SelectedIndex);
            getNombre = ddlCarreras.SelectedItem.Text;
            txtNombre.Text = getNombre;
        }
    }
}