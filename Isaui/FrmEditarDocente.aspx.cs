using System;
using System.Data;
using System.Web;
using System.Web.UI;

    public partial class FrmEditarDocente: System.Web.UI.Page
    {
        int actual;
        public void inicializaForm(object sender, EventArgs e)
        {
            string idDocente = Application["idDocenteEdita"].ToString();
            if (idDocente != null && idDocente != "")
            {
                var cDoc = new CapaDatos.cDocente();
                DataTable dt  = cDoc.GetDocentexCodDocente(Convert.ToInt32(idDocente));
                if (dt.Rows.Count > 0)
                    {
                        actual = Convert.ToInt32(dt.Rows[0]["coddocente"]);
                    
                    
                this.txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                this.txtApellido.Text = dt.Rows[0]["apellido"].ToString();
                this.txtNroDocumento.Text = dt.Rows[0]["nrodoc"].ToString();
                this.txtCelular.Text = dt.Rows[0]["telefono"].ToString();
                this.txtCorreo.Text = dt.Rows[0]["email"].ToString();
            }

        }
            else { }

        }
        public void guardarDocente(object sender, EventArgs e)
        {
            if (Application["idDocenteEdita"].ToString() != null && Application["idDocenteEdita"].ToString() != "")
            {

             var cDoc = new CapaDatos.cDocente();
            cDoc.Modificar(actual, this.txtApellido.Text, this.txtNombre.Text, this.txtNroDocumento.Text, this.txtCelular.Text, this.txtCorreo.Text);
               //Application["idAlumnoEdita"] = "";
                Response.Redirect("FrmAbmDocente.aspx");
            }
            else {
            var cDoc = new CapaDatos.cDocente();
            cDoc.Agregar(this.txtApellido.Text, this.txtNombre.Text, this.txtNroDocumento.Text, this.txtCelular.Text, this.txtCorreo.Text);
            //Application["idAlumnoEdita"] = "";
            Response.Redirect("FrmAbmDocente.aspx");
        }
        }



        public void verFormDocentes(object sender, EventArgs e)
        {
             
            Response.Redirect("FrmAbmDocente.aspx");
        }

        public void TextBox_TextChanged(object sender, EventArgs e)
        {
            e.ToString();
        }
    }
