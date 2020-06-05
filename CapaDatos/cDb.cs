using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDatos
{
    public static class cDb
    {
        public static DataTable GetDatos(string sql)
        {
            string Cadena = cConexion.GetCadena();
            SqlConnection con = new SqlConnection(Cadena);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static void Grabar(string sql)
        {
            string cadena = cConexion.GetCadena();
            SqlConnection con = new SqlConnection(cadena);
            con.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con;
            comando.CommandText = sql;
            comando.ExecuteNonQuery();
            comando.CommandType = System.Data.CommandType.Text;
            con.Close();
        }
    }
}
