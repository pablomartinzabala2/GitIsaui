using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public static class cConexion
    {
        public static string GetCadena()
        {
            //Pablo // 12/06/2020 10:00
            //Pablo
            //string Cadena = "Data Source =DESKTOP-QKECIIE; Initial Catalog =ISAUI; Integrated Security = True";
            //Matias G
            //string Cadena = "Server=localhost;Port=5432;User Id=postgres;Password=matias;";
            //Matias M // 4/6/2020
            //string Cadena = "Data Source=.;Initial Catalog=ISAUI;Integrated Security=True";

            //Agustina
            // string Cadena = "Data Source =DESKTOP-QKECIIE; Initial Catalog =ISAUI; Integrated Security = True";

            //Maxi ch
            // string Cadena = "Data Source =DESKTOP-QKECIIE; Initial Catalog =ISAUI; Integrated Security = True";
            // Cadena Agus V.
            string Cadena = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog=ISAUI; Integrated Security=True";
            return Cadena;
        }
    }
}
