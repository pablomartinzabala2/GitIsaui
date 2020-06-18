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
    string n = "";
    // ciclo lectivo lo usamos por todos lado , lo deje global, asi sacamos codigo
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

    /*private void cargarCombo()
    {
        string str = cConexion.GetCadena();
        SqlConnection con = new SqlConnection(str);
        string com = "SELECT * from CicloLectivo";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "Nombre";
        DropDownList1.DataValueField = "CodCiclo";
        DropDownList1.DataBind();
    }*/

    private void cargarCombo()
    {
       
        //cCicloLectivo cl = new cCicloLectivo();
        DataTable dt = new DataTable();
        dt = cl.selectCarga();
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "Nombre";
        DropDownList1.DataValueField = "CodCiclo";
        //DropDownList1.DataValueField = "Activo";
        DropDownList1.DataBind();
    }

    private void AnoActivo()
    {
        //cCicloLectivo cl = new cCicloLectivo();
        DataTable dt = cl.selectActivo();
        txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();
    }

    protected void BtnCrearCLectivo_Click(object sender, EventArgs e)
    {
        //se duplica cuando recarga
        //validar activo
        //cCicloLectivo cl = new cCicloLectivo();

        //debemos sacar esta variable fecha y usar las globales , todavia no la saque por q debemos hacer q limpie lo campo y variable antes, asi no genera conflicto
        string fecha = "";

        if (txtNFecha.Text != "")
        {
            fecha = txtNFecha.Text;
            cl.agregarCicloLectivo(fecha);
        }

        txtNFecha.Text = "";
        fecha = "";
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
        //hacer modal o buscar otra forma.
        //ScriptManager.RegisterStartupScript(this, GetType(), "", "myFunction();", true);


        // podemos hacer q el metodo SELECT() lo carge solo cuando lo muestre y si panel no esta visible hacer validaciones por las dudas q mas adelante no enredemos mas, si validadmos q si campos esta con valor (osea q panel este visible q edita, caso contrario q no haga nada.. tamien puede funcionar con el guardar nuevo dato)
        select();
        if (panelEditar.Visible == true)
        {
            panelEditar.Visible = false;
        }
        else
        {
            panelEditar.Visible = true;
        }

    }

    protected void btnAnoMod_Click(object sender, EventArgs e)
    {
        //cCicloLectivo cl = new cCicloLectivo();

        //nombre = txtAnoActivo.Text;
        // somos unos pelotudos!!! estamos tomando el TXT Q NO SE MODIFICA!!! OBVEO Q NO SE VA A CAMBIAR EL VALO
        nombre = txtAnoMod.Text;
         cod = int.Parse(DropDownList1.SelectedValue);
        int checkActivo = cbAnoMod.Checked ? 1 : 0; // ternario, googlear.
        //debemos validar q si coloca q esta activo el q modifico, q el resto de desactiven (valor 0) esto se puede hacer en un metodo, ya q le podemos hacer mas amigable el pograma al q lo use, lo podra activa de varias forma y no se fatigara el usuario q ande entrando de un lado a otro para hacer las cosas
        
        cl.modificarCicloLectivo(nombre, checkActivo, cod);
        // refrescar el combo
        cargarCombo();
        //limpiar campo y desactivas componenes
    }

    // usamos este metodo 1 sola vez por el momento , a lo mejor solo va en el dropdowsnList y nada mas
    public void select()
    {
        n = DropDownList1.SelectedItem.Text;
        txtAnoMod.Text = n;
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

    //hacer metodos de desactivas y limpiar , capas sera mejor separarlo, lo veremos mientras programamamos
}

