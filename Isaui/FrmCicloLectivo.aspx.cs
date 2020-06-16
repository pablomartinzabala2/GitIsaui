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

    void cargarCombo()
    {
        DataTable dt = new DataTable();
        string sql = "SELECT * FROM CicloLectivo";
        string Cadena = cConexion.GetCadena();
        SqlConnection con = new SqlConnection(Cadena);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = sql;
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string nombre;
                nombre = dt.Rows[i]["Nombre"].ToString();
                DropDownList1.Items.Add(nombre);
            }
        }
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
        string cod = DropDownList1.SelectedItem.Value;
        //cl.eliminarCicloLectivo();
    }
}

