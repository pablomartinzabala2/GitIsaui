using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
public partial class FrmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public void Mensaje(string Msj)
    {
        string Cuerpo = "<script language=javascript>alert('" + Msj + "');</script>";
        //Response.Write("<script language=javascript>alert('hola');</script>");
        Response.Write(Cuerpo);
    }
    protected void BtnIngresar_Click(object sender, EventArgs e)
    {
        string Usuario = "";
        string Clave = "";
        if (txtUsuario.Text == "")
        {
            Mensaje("Debe ingresar el usuario");
            return;
        }

        if (txtClave.Text == "")
        {
            Mensaje("Debe ingresar la contraseña ");
            return;
        }
        Usuario = txtUsuario.Text;
        Clave = txtClave.Text;
        cUsuario user = new cUsuario();
        DataTable trdo = user.GetUsuario(Usuario, Clave);
        if (trdo.Rows.Count > 0)
        {
            Session.Contents.RemoveAll();
            Session["CodUsuario"] = trdo.Rows[0]["CodUsuario"].ToString();
            Response.Redirect("FrmPrincipal.aspx");
        }
        else
        {
            //Response.Write("<script language=javascript>alert('hola');</script>");
            Mensaje("Usuario incorrecto");
        }
    }
}