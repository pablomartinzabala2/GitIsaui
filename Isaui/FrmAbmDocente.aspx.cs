using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

  public partial class FrmAbmDocente : System.Web.UI.Page
    {
        //List<Docente> alumnos;

        public void inicializaForm(object sender, EventArgs e)
        {
            refrescarTabla();
        }
        public void EditarDocente(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
             Application["idDocenteEdita"] = lb.CommandArgument;
             Response.Redirect("FrmEditarDocente.aspx");
        }
        public void EliminarDocente(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            String id = lb.CommandArgument;
            var cDoc = new CapaDatos.cDocente();
            cDoc.Eliminar(Convert.ToInt32(id));
            //ControlAlumnos.Instance.Delete(Convert.ToInt32(id));
            refrescarTabla();

        }
        private void refrescarTabla() {
        //ControlAlumnos.Instance.SearchAll();
        //alumnos = ControlAlumnos.Instance.Alumnos;
           var cDoc = new CapaDatos.cDocente();
            DataTable dt = cDoc.GetDocentes();
            repDocentes.DataSource = dt;
            repDocentes.DataBind();

        }
        public void NuevoDocente(object sender, EventArgs e)
        {
            Application["idDocenteEdita"] = "";
            Response.Redirect("FrmEditarDocente.aspx");
        }
    }
