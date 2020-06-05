using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CapaDatos
{  //alumno
    public class cAlumno
    {
        public DataTable GetAlumnos()
        {
            string sql = "select * from Alumno order by Apellido,Nombre";
            return cDb.GetDatos(sql);
        }

        public void Eliminar(Int32 CodAlumno)
        {
            string sql = "delete from Alumno ";
            sql = sql + " where CodAlumno=" + CodAlumno.ToString();
            cDb.Grabar(sql);
        }

        public DataTable GetAlumnoxCodAlumno(Int32 CodAlumno)
        {
            string sql = "select * from Alumno";
            sql = sql + " where CodALumno=" + CodAlumno.ToString();
            return cDb.GetDatos(sql);
        }

        public void Agregar(string Apellido,string Nombre,string NroDocumento,String Telefono)
        {
            string sql = "";
            sql = "insert into Alumno(Apellido,Nombre,NroDoc,Telefono)";
            sql = sql + " Values(" + "'" + Apellido + "'";
            sql = sql + "," + "'" + Nombre  +"'";
            sql = sql + "," + "'" + NroDocumento  + "'";
            sql = sql + "," + "'" + Telefono  + "'";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public void Modificar(Int32 CodAlumno, string Apellido, string Nombre, string NroDocumento, String Telefono)
        {
            string sql = "";
            sql = "update Alumno ";
            sql = sql + " set Apellido=" + "'" + Apellido +"'";
            sql= sql + ",Nombre=" +"'" + Nombre + "'";
            sql = sql + ",NroDoc=" + "'" + NroDocumento  + "'";
            sql = sql + ",Telefono=" + "'" + Telefono  + "'";
            sql = sql + " where CodAlumno=" + CodAlumno.ToString();
            cDb.Grabar(sql);
        }
    }
}
