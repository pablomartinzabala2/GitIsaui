using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;


public partial class FrmCicloLectivo : System.Web.UI.Page
{
    int cod = 0;
    string nombre = "";
    string traerNombre = "";
    cCicloLectivo cl = new cCicloLectivo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarCombo();
            AnoActivo();
            panelEditar.Visible = false;
        }
    }

    protected void BtnCCL(object sender, EventArgs e)
    {

    }

    private void cargarCombo()
    {
        DataTable dt = new DataTable();
        dt = cl.selectTodoCL();
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "Nombre";
        DropDownList1.DataValueField = "CodCiclo";
        DropDownList1.DataBind();
    }

    private void AnoActivo()
    {
        DataTable dt = cl.selectActivo();
        txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();
    }

    protected void BtnCrearCLectivo_Click(object sender, EventArgs e)
    {
        //se duplica cuando recarga
        //validar activo

        string fecha = "";
        if (txtNFecha.Text == "")
        {
            return;
        }
        if (txtNFecha.Text != "")
        {
            int checkActivo = cbActivo.Checked ? 1 : 0;
            fecha = txtNFecha.Text;
            cl.agregarCicloLectivo(fecha, checkActivo);
        }
        Limpiar();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        cCicloLectivo cl = new cCicloLectivo();
        int cod = int.Parse(DropDownList1.SelectedValue);
        cl.eliminarCicloLectivo(cod);
        cargarCombo();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        // podemos hacer q el metodo SELECT() lo carge solo cuando lo muestre y si panel no esta visible hacer validaciones por las dudas q mas adelante no enredemos mas, si validadmos q si campos esta con valor (osea q panel este visible q edita, caso contrario q no haga nada.. tamien puede funcionar con el guardar nuevo dato)

        ActivarPanel();
    }

    protected void btnAnoMod_Click(object sender, EventArgs e)
    {
        nombre = txtAnoMod.Text;
        cod = int.Parse(DropDownList1.SelectedValue);
        int checkActivo = cbAnoMod.Checked ? 1 : 0; // ternario, googlear.
        //debemos validar q si coloca q esta activo el q modifico, q el resto de desactiven (valor 0) esto se puede hacer en un metodo, ya q le podemos hacer mas amigable el pograma al q lo use, lo podra activa de varias forma y no se fatigara el usuario q ande entrando de un lado a otro para hacer las cosas
        cl.modificarCicloLectivo(nombre, checkActivo, cod);
        cargarCombo();
        Limpiar();
        panelEditar.Visible = false;
    }

    public void select()
    {

        DataTable dt = cl.selectTodoCL();
        txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();

        traerNombre = DropDownList1.SelectedItem.Text;
        //int esActivo = 
        txtAnoMod.Text = traerNombre;
        //if (DropDownList1.Items.FindByValue(dt.Rows[0].ToString()))
        //{

        //} ;
       // cbAnoMod.Checked = 
        //traer y mostrar q si esta activo o no en el checkbox
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //esta viajando a cada momento q cambiamos valor en combobox
        select();
    }

    protected void txtAnoMod_TextChanged(object sender, EventArgs e)// para mi no va
    {
        //si hago esto en este momento la variable nombre esta vacio asi q lo comente
        //txtAnoMod.Text = nombre;
    }

    private void Limpiar()
    {
        txtAnoMod.Text = string.Empty;
        txtNFecha.Text = string.Empty;
        txtNFecha.Text = "";
        //cbAnoMod.Checked = false;
        cbActivo.Checked = false;
    }

    public void ActivarPanel()
    {
        if (panelEditar.Visible == true)
        {
            btnComenzar.Enabled = true;
            btnEliminar.Enabled = true;
            btnComenzar.Visible = true;
            btnEliminar.Visible = true;
            panelEditar.Visible = false;
        }
        else
        {
            select();
            btnComenzar.Enabled = false;
            btnEliminar.Enabled = false;
            btnComenzar.Visible = false;
            btnEliminar.Visible = false;
            panelEditar.Visible = true;
        }
    }

    //hacer metodos de desactivas y limpiar , capas sera mejor separarlo, lo veremos mientras programamamos

    protected void txtAnoActivo_TextChanged(object sender, EventArgs e)
    {

    }

    protected void cbAnoMod_CheckedChanged(object sender, EventArgs e)
    {
        //if(cbAnoMod.Checked) DropDownList1.SelectedValue = "1";
        //else DropDownList1.SelectedValue = "0";
    }
}

