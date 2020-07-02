using System;
using System.Activities;
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
 * -NO CARGA BIEN LA TABLA , NO ME CAMBIA EL BOTON
    
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
            FillGrid();
            YearActive();
            panelEditar.Visible = false;
            btnBack.Visible = false;
           
        }
    }

    private void YearActive()
    {//llena el txt con el año que activo
        dt = cl.selectAct();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Nombre"].ToString() != "")
                lblActiveYear.Text = " " + dt.Rows[0]["Nombre"].ToString();
        }
        else
        {
            lblActiveYear.Text = "Ninguno";
        }
    }

    protected void btnAnoMod_Click(object sender, EventArgs e)
    {

        string mje = "";
        string name = txtAnoMod.Text;
        if (name == "")
        {
            Clean();
            mje = "Debe ingressar solo 4 caracteres sin comas ni puntos";
            lblMjeANoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertMNo()", true);
            return;
        }
        if (ValidateLength(name) == true)
        {
            //mensaje de que usa , y .
            Clean();
            mje = "Debe ingressar solo 4 caracteres sin comas ni puntos";
            lblMjeANoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertMNo()", true);
            return;
        }
        if (ValidateNameEdit(txtAnoMod.Text, int.Parse(txtCod.Text)) == true)
        {
            //mensaje de que usa , y .
            Clean();
            mje = "La fecha ya existe";
            lblMjeANoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertMNo()", true);
            return;
        }

        int checkActivo = chkAnoMod.Checked ? 1 : 0;
        if (ActivateModal(checkActivo) == true)
        {
            lblTituloModal.Text = "Informacion";
            lblMjeModal.Text = "Ya existe un ciclo lectivo activo ¿esta seguro que desea activarlo?";
            btnAceptarEliminar.Text = "Aceptar";
            ClientScript.RegisterStartupScript(GetType(), "ActionModal", "modalAction()", true);
            return;
        }

        cod = int.Parse(txtCod.Text);
        cl.updateCL(name, checkActivo, cod);
        FillGrid();
        Clean();
        ShowButtons();
        YearActive();
        mje = "Registro guardado con exito";
        lblMjeASiCCL.Text = mje;
        ClientScript.RegisterStartupScript(GetType(), "alertsucces", "alertMSi()", true);

    }

    private void Clean()
    {//limpias campos
        txtAnoMod.Text = string.Empty;
        txtNameCL.Text = string.Empty;
        txtNameCL.Text = "";
        chkActive.Checked = false;
        chkAnoMod.Checked = false;
    }

    private bool ValidateNameEdit(string nombre2, int cod)
    {//valida que no repita el nombre
        dt = cl.selectById(cod);
        string nom1 = dt.Rows[0]["Nombre"].ToString();
        if (nom1 == nombre2)
        {
            return false;
        }
        if (ValidateName(nombre2) == true)
        {
            return true;
        }
        return false;
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
            lblMjeANoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertMNo()", true);
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
            lblMjeANoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertMNo()", true);
            return;
        }
        if (ValidateName(name) == true)
        {
            // de que ya existe 
            name = "";//sacar esto
            Clean();
            mje = "La fecha ya existe";
            lblMjeANoCCL.Text = mje;
            ClientScript.RegisterStartupScript(GetType(), "alertdanger", "alertMNo()", true);
            return;
        }

        int checkActivo = chkActive.Checked ? 1 : 0;
        if (ActivateModal(checkActivo) == true)
        {
            lblTituloModal.Text = "Informacion";
            lblMjeModal.Text = "Ya existe un ciclo lectivo activo ¿esta seguro que desea activarlo?";
            btnAceptarEliminar.Text = "Aceptar";
            ClientScript.RegisterStartupScript(GetType(), "ActionModal", "modalAction()", true);
            return;
        }



        cl.addCL(name, checkActivo);
        FillGrid();
        Clean();
        panelEditar.Enabled = false;
        YearActive();
        mje = "Registro guardado con exito";
        lblMjeASiCCL.Text = mje;
        ClientScript.RegisterStartupScript(GetType(), "alertsucces", "alertMSi()", true);

    }

    private void ShowButtons()
    {// mostrar lo votones de ABM y panel
        if (panelEditar.Visible == true)
        {
            //estaria bueno q desaparesca los otros datos de la tabla

            panelEditar.Visible = false;
            panelCrear.Visible = true;
        }
        else
        {
            panelEditar.Visible = true;
            panelCrear.Visible = false;
        }
    }

    private bool ActivateModal(int check)
    {
        dt = cl.selectAct();
        if (dt.Rows.Count > 0)
        {
            if (check == 1)
            {
                return true;
            }
        }
        return false;
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

    private void FillGrid()
    {//trae toda la grilla
        dt = cl.selectAll();
        //gvCL.DataSource = dt;
        //gvCL.DataBind();
        chargerG(dt);

    }

    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        btnAceptarEliminar.Text = "Eliminar";
        ClientScript.RegisterStartupScript(GetType(), "ActionModal", "modalAction()", true);
        ImageButton btnEliminar = sender as ImageButton;
        GridViewRow row = (GridViewRow)btnEliminar.NamingContainer;
        int codCL = Convert.ToInt32(row.Cells[0].Text);
        txtCod.Text = codCL.ToString();

    }

    protected void gvCL_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)

            e.Row.Cells[0].Attributes.Add("style", "display:none");
    }


    protected void btnEditar_Click(object sender, ImageClickEventArgs e)
    {
        
        ImageButton btnEditar = sender as ImageButton;
        GridViewRow row = (GridViewRow)btnEditar.NamingContainer;
        ShowButtons();
        int codCL = Convert.ToInt32(row.Cells[0].Text);
        txtCod.Text = codCL.ToString();
        if (panelEditar.Visible == true)
        {
            btnEditar.ImageUrl = "~/Iconos/return.png";
            dt = cl.selectById(codCL);
            txtAnoMod.Text = dt.Rows[0]["Nombre"].ToString();
            lblEditar.Text = "Se editara el año: " + dt.Rows[0]["Nombre"].ToString();
            string activo = dt.Rows[0]["Activo"].ToString();
            chkAnoMod.Checked = false;
           
            if (activo == "True")
            {
                chkAnoMod.Checked = true;
            }
            //revisar
            dt = cl.selecSerch(txtAnoMod.Text);
            chargerG(dt);
            //revisar
        }
        else
        {
            btnEditar.ImageUrl = "~/Iconos/saveas.ico";
            FillGrid();
        }
      
    }

    protected void btnAceptarEliminar_Click(object sender, EventArgs e)
    {
        string mje = "";
        if (btnAceptarEliminar.Text == "Eliminar")
        {
            int codCL = int.Parse(txtCod.Text);
            cl.deleteCL(codCL);
            FillGrid();
            Clean();
            mje = "Registro eliminado con exito";
            ClientScript.RegisterStartupScript(GetType(), "AlertEliminado", "alertMSi()", true);
        }
        if (btnAceptarEliminar.Text == "Aceptar")
        {

            int checkActivo = chkActive.Checked ? 1 : 0;
            int checkActivo2 = chkAnoMod.Checked ? 1 : 0;
            if (checkActivo == 1)
            {

                string name = txtNameCL.Text;
                ChangeToZero(checkActivo);
                cl.addCL(name, checkActivo);
                FillGrid();
                Clean();
                panelEditar.Visible = false;
                YearActive();
                mje = "Registro guardado con exito";
                lblMjeASiCCL.Text = mje;
                ClientScript.RegisterStartupScript(GetType(), "alertsucces", "alertMSi()", true);

            }
            if (checkActivo2 == 1)
            {
                cod = int.Parse(txtCod.Text);
                string name = txtAnoMod.Text;
                ChangeToZero(checkActivo2);
                cl.updateCL(name, checkActivo2, cod);
                FillGrid();
                Clean();
                ShowButtons();
                YearActive();
                mje = "Registro guardado con exito";
                lblMjeASiCCL.Text = mje;
                ClientScript.RegisterStartupScript(GetType(), "alertsucces", "alertMSi()", true);

            }
        }
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtBuscar.Text != "")
        {
            dt = cl.selecSerch(txtBuscar.Text);
            if (dt.Rows.Count > 0)
            {
                chargerG(dt);
                btnBack.Visible = true;
            }
        }
        else
        {
            FillGrid();
        }

    }

    private GridView chargerG(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        { 
            gvCL.DataSource = dt;
            gvCL.DataBind();
        }
        return gvCL;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        FillGrid();
        btnBack.Visible = false;
    }

   
}
