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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarCombo();
        }
    }

    protected void BtnCCL(object sender, EventArgs e)
    {

    }

    private void cargarCombo()
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
        //DropDownList1.DataValueField = "Activo";
        DropDownList1.DataBind();
    }

    private void AnoActivo()
    {
        cCicloLectivo cl = new cCicloLectivo();

        txtAnoActivo.Text = "";

    }

    protected void BtnCrearCLectivo_Click(object sender, EventArgs e)
    {
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
        cCicloLectivo cl = new cCicloLectivo();
        int cod = int.Parse(DropDownList1.SelectedValue);
    }
}

