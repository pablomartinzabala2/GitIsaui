using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaDatos
{
    public class cCicloLectivo
    {
        //public void ValidateYear()
        //{
        //    string cad = $"select Nombre from CicloLectivo";
        //    cDb.GetDatos(cad);
        //    int ano = DateTime.Now.Year;
        //    int anoBD = int.Parse(cad);
        //    string con="";
        //    if (anoBD < ano)
        //    {
        //         con = "update CicloLectivo set Activo=0";
        //    }
        //    if (anoBD==ano)
        //    {
        //        con = "update CicloLectivo set Activo=1";
        //    }
        //    else
        //    {
        //        con = "update CicloLectivo set Activo=null";
        //    }
        //    cDb.Grabar(con);
        //}


        public void agregarCicloLectivo(string fecha, int activo)
        {
            string sql = $"insert into CicloLectivo (Nombre, activo) values ('{ fecha }', {activo} )";
            cDb.Grabar(sql);
        }

        public void modificarCicloLectivo(string nombre, int activo, int id)
        {
            string sql = $"UPDATE CicloLectivo SET Nombre = {nombre}, Activo = {activo} WHERE CodCiclo = {id}";
            cDb.Grabar(sql);
        }

        public void eliminarCicloLectivo(int id)
        {
            string sql = $"DELETE FROM CicloLectivo WHERE CodCiclo = {id.ToString()}";
            cDb.Grabar(sql);
        }

        public DataTable selectById(int id)
        {
            string sql = $"SELECT Nombre,Activo FROM CicloLectivo WHERE CodCiclo = {id.ToString()}";
            return  cDb.GetDatos(sql);
        }

        public DataTable selectActivo()
        {
            string sql = $"SELECT Nombre,Activo FROM CicloLectivo WHERE Activo = 1";
            return cDb.GetDatos(sql);
        }

        public DataTable selectTodoCL()
        {
            string com = "SELECT * FROM CicloLectivo ORDER BY Nombre ASC";
            return cDb.GetDatos(com);
        }

        //public DataTable changeToNull()
        //{
        //    string sql = "UPDATE CicloLectivo SET Activo = 0";
        //}
    }
}
