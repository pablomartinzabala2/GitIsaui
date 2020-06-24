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
    DataTable dt = new DataTable();

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
        //borrar
    }

    private void cargarCombo()
    {
        dt = cl.selectTodoCL();
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "Nombre";
        DropDownList1.DataValueField = "CodCiclo";
        DropDownList1.DataBind();
    }

    private void AnoActivo()
    {

        cCicloLectivo cl = new cCicloLectivo();
       // DataTable dt = cl.selectActivo();
       // txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();

        //validar si la base tiene datos
        dt = cl.selectActivo();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Nombre"].ToString() != "")
                txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();

            if (dt.Rows[0]["Activo"].ToString() == "1")
                cbActivo.Checked = true;
        }

    }

    protected void BtnCrearCLectivo_Click(object sender, EventArgs e)
    {
        string fecha = "";
        if (txtNFecha.Text == "")
        {
            return;
        }
        if (txtNFecha.Text != "")
        {
            dt = cl.selectActivo();
            DataTable dt2 = cl.selectTodoCL();
            string activo = dt.Rows[0]["Activo"].ToString();
            string nombreActivo = dt.Rows[0]["Nombre"].ToString();

            if (txtNFecha.Text == nombreActivo)
            {
                string script = "<script languaje=javascript>console.log('error')</script>";
                Response.Write(script);
                return; //agregar modal de error
            }

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string nombre2 = dt2.Rows[i]["Nombre"].ToString();
                if (txtNFecha.Text == nombre2)
                {
                    string script = "<script languaje=javascript >console.log('error')</script>";
                    Response.Write(script);
                    Limpiar();
                    return; //agregar modal de error
                }
            }
            int checkActivo = cbActivo.Checked ? 1 : 0;
            fecha = txtNFecha.Text;
            if (checkActivo == 1)
            {
                //mensaje
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    int id = int.Parse(dt2.Rows[i]["CodCiclo"].ToString());
                    string nombre = dt2.Rows[i]["Nombre"].ToString();
                    cl.modificarCicloLectivo(nombre, 0, id);
                }
            }
            cl.agregarCicloLectivo(fecha, checkActivo);
            cargarCombo();
            Limpiar();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        int cod = int.Parse(DropDownList1.SelectedValue);
        cl.eliminarCicloLectivo(cod);
        cargarCombo();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        ActivarPanel();
    }

    protected void btnAnoMod_Click(object sender, EventArgs e)
    {
        nombre = txtAnoMod.Text;
        cod = int.Parse(DropDownList1.SelectedValue);
        int checkActivo = cbAnoMod.Checked ? 1 : 0;
        cl.modificarCicloLectivo(nombre, checkActivo, cod);
        cargarCombo();
        Limpiar();
        panelEditar.Visible = false;
    }

    public void select()
    {
        if (panelEditar.Visible == true)
        {
            Int32 CodCiclo = Convert.ToInt32(DropDownList1.SelectedValue);
            dt = cl.selectById(CodCiclo);
            txtAnoActivo.Text = dt.Rows[0]["Nombre"].ToString();
            string activo = dt.Rows[0]["Activo"].ToString();
            cbAnoMod.Checked = false;
            if (activo == "True")
            {
                cbAnoMod.Checked = true;
            }
            traerNombre = DropDownList1.SelectedItem.Text;
            txtAnoMod.Text = traerNombre;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        select();
    }

    protected void txtAnoMod_TextChanged(object sender, EventArgs e)
    {
        //borrar
    }

    private void Limpiar()
    {
        txtAnoMod.Text = string.Empty;
        txtNFecha.Text = string.Empty;
        txtNFecha.Text = "";
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

    protected void txtAnoActivo_TextChanged(object sender, EventArgs e)
    {
        //borrar
    }

    protected void cbAnoMod_CheckedChanged(object sender, EventArgs e)
    {
        //borrar
    }
}

