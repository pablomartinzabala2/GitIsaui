using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class cCarreras
    {
        public void agregarCarrera(string nombre)
        {
            string sql = $"insert into Carrera (Nombre) values ('{ nombre }')";
            cDb.Grabar(sql);
        }

        public void modificarCarrera(string nombre, int id)
        {
            string sql = $"UPDATE Carrera SET Nombre = {nombre} WHERE CodCarrera = {id}";
            cDb.Grabar(sql);
        }

        public void eliminarCarrera(int id)
        {
            string sql = $"DELETE FROM Carrera WHERE CodCarrera = {id.ToString()}";
            cDb.Grabar(sql);
        }
        public DataTable getXid(int id)
        {
            string sql = $"SELECT Nombre FROM Carrera WHERE CodCarrera = {id.ToString()}";
            return cDb.GetDatos(sql);
        }
        public DataTable getTodo()
        {
            string com = "SELECT * FROM Carrera ORDER BY Nombre ASC";
            return cDb.GetDatos(com);
        }
    }

}

