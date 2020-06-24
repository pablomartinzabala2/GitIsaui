using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class cActualizarC
    {
        public bool GetExisteUsuario(string nombre)
        {
            string user = "";
            string sql = "select Nombre from Usuario";
            sql = sql + " where Nombre='"+nombre+"'";
            DataTable trdo = cDb.GetDatos(sql);
            if (trdo.Rows.Count > 0)
                user = trdo.Rows[0]["Nombre"].ToString();
            return true;
        }

        public string GetPassUsuario(string nombre) {
            string pass = "";
            string sql = "select clave from Usuario";
            sql = sql + " where Nombre='" + nombre + "'";
            DataTable trdo = cDb.GetDatos(sql);
            if (trdo.Rows.Count > 0)
                pass = trdo.Rows[0]["Clave"].ToString();
            return pass;

        }

        public void UpdatePass( string passnuevo, string nombre) {
            string sql = "";
            sql = "update Usuario";
            sql = sql + " set Clave='"+ passnuevo +"'";
            sql = sql + "where Nombre= '"+nombre+"'";
            cDb.Grabar(sql);
        }
    }
}
