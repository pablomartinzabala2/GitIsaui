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
        //string str = cConexion.GetCadena();
        //SqlConnection con = new SqlConnection(str);
        //string com = "SELECT * from CicloLectivo";
        //SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        cCicloLectivo cl = new cCicloLectivo();//mati
        DataTable dt = new DataTable();
        dt = cl.selectCarga();// mati
        //adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "Nombre";
        DropDownList1.DataValueField = "CodCiclo";
        //DropDownList1.DataValueField = "Activo";
        DropDownList1.DataBind();
    }

    private void AnoActivo()
    {
        cCicloLectivo cl = new cCicloLectivo();
        DataTable dt = cl.selectActivo();
        txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();
    }

    protected void BtnCrearCLectivo_Click(object sender, EventArgs e)
    {
        //se duplica cuando recarga
        //validar activo
        cCicloLectivo cl = new cCicloLectivo();
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
        cCicloLectivo cl = new cCicloLectivo();
        txtAnoMod.Text = DropDownList1.SelectedItem.Text;
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
        cCicloLectivo cl = new cCicloLectivo();
        int cod = int.Parse(DropDownList1.SelectedValue);
        int checkActivo = cbAnoMod.Checked ? 1 : 0; // ternario, googlear.
        cl.modificarCicloLectivo(txtAnoMod.Text, checkActivo, cod);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        cCicloLectivo cl = new cCicloLectivo();
        cod = int.Parse(DropDownList1.SelectedValue);

    }
}

