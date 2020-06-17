﻿using Microsoft.SqlServer.Server;
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
        // CodCiclo   Nombre(varchar 20)   Activo(bit)

        //public void AddCicloLectivo(string fecha)
        //{
        //    string con = $"insert into CicloLectivo (Nombre, Activo) values ('{ fecha}' )";
        //    cDb.Grabar(con);
        //}

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


        public void agregarCicloLectivo(string fecha)
        {
            string sql = $"insert into CicloLectivo (Nombre) values ('{ fecha }' )";
            cDb.Grabar(sql);
        }

        public void modificarCicloLectivo(string nombre, byte activo, int id)
        {
            string sql = $"UPDATE CicloLectivo SET Nombre = {nombre}, Activo = {activo} WHERE CodCiclo = {id.ToString()}";
            cDb.Grabar(sql);
        }

        public void eliminarCicloLectivo(int id)
        {
            string sql = $"DELETE FROM CicloLectivo WHERE CodCiclo = {id.ToString()}";
            cDb.Grabar(sql);
        }

        public DataTable selectActivo()
        {
            string sql = $"SELECT Nombre FROM CicloLectivo WHERE Activo = 1";
            return cDb.GetDatos(sql);
        }
    }
}
