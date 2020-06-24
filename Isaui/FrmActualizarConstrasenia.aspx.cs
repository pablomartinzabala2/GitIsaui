using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

public partial class FrmActualizarConstrasenia : System.Web.UI.Page
{
    //y cuando el usuario ingrese a ese formulario le debe traer el nombre de usuario que se logueo y tres campos,
    // el primero que diga contraseña anterior, el segundo contraseña nueva y el tercero reingresar contraseña nueva
    //.Si ya lo quieres ir programando, te paso el scrip de la tabla Usuario. 
    // Pro´ba de agregar tu cadena de conexión en la clase cConexíon y subir los cambios así compruebo
    //que esta funcionando el git.
    //
    protected void Page_Load(object sender, EventArgs e)
    {
        // espero tener almacenado en la sesion el nombre del usuario
        string nombreDeUsuario = "";

      //  nombreDeUsuario = Session["nUsuario"].ToString();
    }

    


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string passviejo = passvieja.Text;
        string passnuevo = passnueva.Text;
        string passnuevo2 = passnueva2.Text;

        cActualizarC actualizarP = new cActualizarC();

        if (actualizarP.GetExisteUsuario("Agustin")) {

            if (passviejo == "" && passnuevo == "" && passnuevo2 == "")
            {

                ClientScript.RegisterStartupScript(GetType(), "Atencion", "alertaVacio()", true);
            }
            else if (passviejo == actualizarP.GetPassUsuario("Agustin"))
            {


                if (passnuevo == passnuevo2)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Exito", "alerta()", true);

                    actualizarP.UpdatePass(passnuevo, "Agustin");

                    Response.Redirect("FrmLogin.aspx");

                }

                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Fracaso", "alertaError()", true);
                }

            }

            else {

                Response.Write("Usuario No existe en la base de datos");
            }
           

        };


       
      


    }


}