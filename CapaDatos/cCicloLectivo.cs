using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
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
    }
}
