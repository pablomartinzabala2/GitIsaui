using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CapaDatos
{  
    public class cDocente
    {
        public DataTable GetDocentes()
        {
            string sql = "select * from  docente order by Apellido,Nombre";
            return cDb.GetDatos(sql);
        }

        public List<string> GetListDocentes()
        {

            string sql = "select coddocente+'#'+nombre+' '+apellido from docente order by Apellido,Nombre";
            DataTable dt = cDb.GetDatos(sql);
            List<string> lista = new List<string>();
            for (var i = 0;i< dt.Rows.Count; i++) {
                lista.Add(dt.Rows[i][0].ToString());
            }
            return lista;
        }

        public void Eliminar(Int32 CodDocente)
        {
            string sql = "delete from docente ";
            sql = sql + " where coddocente=" + CodDocente.ToString();
            cDb.Grabar(sql);
        }

        public DataTable GetDocentexCodDocente(Int32 CodDocente)
        {
            string sql = "select * from docente";
            sql = sql + " where CodDocente=" + CodDocente.ToString();
            return cDb.GetDatos(sql);
        }

        public void Agregar(string apellido ="",string nombre ="",string nrodoc = "", string telefono = "", string email = "", Int32 codtipodoc = 0)
        {
            string sql = "";
            sql = "insert into Docente(apellido,nombre,nrodoc,telefono, email, codtipodoc, activo)";
            sql = sql + " Values(" + "'" + apellido + "'";
            sql = sql + "," + "'" + nombre  +"'";
            sql = sql + "," + "'" + nrodoc  + "'";
            sql = sql + "," + "'" + telefono  + "'";
            sql = sql + "," + "'" + email + "'";
            sql = sql + ","+ codtipodoc.ToString()  ;
            sql = sql + ", true " ;
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public void Modificar(Int32 coddocente, string apellido = "", string nombre = "", string nrodoc = "", string telefono = "", string email = "", Int32 codtipodoc = 0, bool activo = true)
        {
            string sql = "";
            sql = "update docente ";
            sql = sql + " set apellido=" + "'" + apellido +"'";
            sql= sql + ",nombre=" +"'" + nombre + "'";
            sql = sql + ",nrodoc=" + "'" + nrodoc  + "'";
            sql = sql + ",telefono=" + "'" + telefono  + "'";
            if (activo) {
                sql = sql + ",activo = true ";
            }
            else { sql = sql + ",activo = false "; }
            sql = sql + " where coddocente=" + coddocente.ToString();
            cDb.Grabar(sql);
        }
    }
}
