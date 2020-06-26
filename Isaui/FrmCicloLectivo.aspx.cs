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

/*
    
    3_ mje de usuario de validaciones
    4_ diseño
    5_ cuando aprento F5 me realiza la ultiam accion nuevamente 
   
*/
public partial class FrmCicloLectivo : System.Web.UI.Page
{
    int cod = 0;
    cCicloLectivo cl = new cCicloLectivo();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDdl();
            YearActive();
            panelEditar.Visible = false;
        }
    }


    private void FillDdl()
    {//llena el DrowDopList
        dt = cl.selectAll();
        if (dt.Rows.Count > 0)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Nombre";
            DropDownList1.DataValueField = "CodCiclo";
            DropDownList1.DataBind();
        }
    }

    private void YearActive()
    {//llena el txt con el año que activo
        dt = cl.selectAct();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Nombre"].ToString() != "")
                txtActiveYear.Text = dt.Rows[0]["Nombre"].ToString();
        }
        else
        {
            txtActiveYear.Text = "Ninguno";
        }
    }


    protected void btnAnoMod_Click(object sender, EventArgs e)
    {
        string mje="";
        string name = txtAnoMod.Text;
        if (name=="")
        {
            Clean();
            mje = "Debe ingressar solo 4 caracteres sin comas ni puntos";
            lblMjePNoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertPNo()", true);
            return;
        }
        if (ValidateLength(name) == true)
        {

            //mensaje de que usa , y .
            name = "";
            Clean();
            mje = "Debe ingressar solo 4 caracteres sin comas ni puntos";
            lblMjePNoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertPNo()", true);
            return;
        }
        if (ValidateName(name) == true)
        {
            // de que ya existe 
            name = "";
            Clean();
            mje = "La fecha ya existe";
            lblMjePNoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertPNo()", true);
            return;
        }

        if (name != "")
        {
            //aca validar q no tenga coma ni E, ni la coma, y espacio

            cod = int.Parse(DropDownList1.SelectedValue);
            int checkActivo = cbAnoMod.Checked ? 1 : 0;
            //mje de que si esta seguro que quiere activar el año "este"
            ChangeToZero(checkActivo);
            //fin del if
            cl.updateCL(name, checkActivo, cod);
            FillDdl();
            Clean();
            ShowButtons();
            YearActive();
            mje = "Registro guardado con exito";
            lblMjePSiCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertsucces", "alertPSi()", true);
        }
    }

    public void BringDdlItem()
    {//carbar modal
        if (panelEditar.Visible == true)
        {
            Int32 CodCiclo = Convert.ToInt32(DropDownList1.SelectedValue);
            dt = cl.selectById(CodCiclo);
            txtAnoMod.Text = dt.Rows[0]["Nombre"].ToString();
            string activo = dt.Rows[0]["Activo"].ToString();
            cbAnoMod.Checked = false;
            if (activo == "True")
            {
                cbAnoMod.Checked = true;
            }
            string name = DropDownList1.SelectedItem.Text;
            txtAnoMod.Text = name;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BringDdlItem();
    }

    private void Clean()
    {//limpias campos
        txtAnoMod.Text = string.Empty;
        txtNameCL.Text = string.Empty;
        txtNameCL.Text = "";
        chkActive.Checked = false;
    }

    protected void btnDeleteCL_Click(object sender, EventArgs e)
    {//modal
        int cod = int.Parse(DropDownList1.SelectedValue);
        cl.deleteCL(cod);
        FillDdl();
        
    }

    private bool ValidateName(string nombre2)
    {//valida que no repita el nombre
        dt = cl.selectAll();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string n = dt.Rows[i]["Nombre"].ToString();
            if (n == nombre2)
            {

                return true;
            }
        }
        return false;
    }

    protected void btnCreateCL_Click(object sender, EventArgs e)
    {
        string mje = "";
        string name = txtNameCL.Text;
        if (name == "")
        {
            mje = "Ingrese una fecha valida";
            //mje vacio
            lblMjeNoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertNo()", true);
            //tring script = "<script languaje=javascript >console.log('error')</script>";
            //Response.Write(script);
            return;
        }
        if (ValidateLength(name) == true)
        {
            //mensaje de que usa , y .
            name = "";
            Clean();
            mje = "Debe ingressar solo 4 caracteres sin comas ni puntos";
            lblMjeNoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertNo()", true);
            return;
        }
        if (ValidateName(name) == true)
        {
            // de que ya existe 
            name = "";//sacar esto
            Clean();
            mje = "La fecha ya existe";
            lblMjeNoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertNo()", true);
            return;
        }
        //validar q no tenga campos vacio, volver a chequear (required)

        if (name != "")//sacar esto
        {
            int checkActivo = chkActive.Checked ? 1 : 0;
            //mje de que si esta seguro que quiere activar el año "este"
            ChangeToZero(checkActivo);
            // fin del if.
            cl.addCL(name, checkActivo);
            FillDdl();
            Clean();
            panelEditar.Enabled = false;
            YearActive();
            //mensaje de exito
            mje = "Registro guardado con exito";
            lblMjeSiCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertsucces", "alertSi()", true);
        }
    }
    
    private void ShowButtons()
    {// mostrar lo votones de ABM y panel
        if (panelEditar.Visible == true)
        {
            btnStartCL.Enabled = true;
            btnDeleteCL.Enabled = true;
            btnStartCL.Visible = true;
            btnDeleteCL.Visible = true;
            panelEditar.Visible = false;

        }
        else
        {
            btnStartCL.Enabled = false;
            btnDeleteCL.Enabled = false;
            btnStartCL.Visible = false;
            btnDeleteCL.Visible = false;
            panelEditar.Visible = true;
            BringDdlItem();
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ShowButtons();
    }

    private void ChangeToZero(int checkActivo)
    {// valida si hay un activo y me pone el resto de los campos en 0
        dt = cl.selectAll();
        if (dt.Rows.Count > 0)
        {
            if (checkActivo == 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id = int.Parse(dt.Rows[i]["CodCiclo"].ToString());
                    string nombre = dt.Rows[i]["Nombre"].ToString();
                    cl.updateCL(nombre, 0, id);
                }
            }
        }
    }

    private bool ValidateLength(string nombre)
    {//valida si tiene mas de 4 o menos de 4, y si el TXT continene "Coma y punto"
        char[] ar;
        ar = nombre.ToCharArray();
        if (ar.Length < 4 || ar.Length >= 5)
        {//no va dentro del for
            return true;
        }
        for (int i = 0; i < ar.Length; i++)
        {
            if (ar[i] == 44 || ar[i] == 46)
            {
                return true;
            }
        }
        return false;
    }

}
