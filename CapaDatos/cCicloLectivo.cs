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

        public void addCL(string fecha, int activo)
        {
            string sql = $"insert into CicloLectivo (Nombre, activo) values ('{ fecha }', {activo} )";
            cDb.Grabar(sql);
        }

        public void updateCL(string nombre, int activo, int id)
        {
            string sql = $"UPDATE CicloLectivo SET Nombre = {nombre}, Activo = {activo} WHERE CodCiclo = {id}";
            cDb.Grabar(sql);
        }

        public void deleteCL(int id)
        {
            string sql = $"DELETE FROM CicloLectivo WHERE CodCiclo = {id.ToString()}";
            cDb.Grabar(sql);
        }

        public DataTable selectById(int id)
        {
            string sql = $"SELECT Nombre,Activo FROM CicloLectivo WHERE CodCiclo = {id}";
            return cDb.GetDatos(sql);
        }

        public DataTable selectAct()
        {
            string sql = $"SELECT Nombre,Activo FROM CicloLectivo WHERE Activo = 1";
            return cDb.GetDatos(sql);
        }

        public DataTable selectAll()
        {
            string com = "SELECT * FROM CicloLectivo ORDER BY Nombre ASC";
            return cDb.GetDatos(com);
        }

        public DataTable selecSerch(string nom)
        {           
                string sql = $"select * from CicloLectivo where Nombre like  {nom}" ;
                return cDb.GetDatos(sql);   
        }
    }
}
