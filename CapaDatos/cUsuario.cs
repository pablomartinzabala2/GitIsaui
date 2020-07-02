using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace CapaDatos
{
    public class cUsuario
    {
        public DataTable GetUsuario(string USUARIO, string CLAVE)
        {
            //Le agregue un encriptador de claves para que no 
            // se vean las contraseñas en la base de datos, deben ser privadas
            CLAVE = this.enc_des(CLAVE, 'e');
            string sql = "select *";
            sql = sql + " from Usuario";
            sql = sql + " Where Nombre=" + "'" + USUARIO.ToString() + "'";
            sql = sql + " AND Clave=" + "'" + CLAVE + "'";
            return cDb.GetDatos(sql);
        }

        public string GetNombreUsuarioxCodUsuario(Int32 CodUsuario)
        {
            string user = "";
            string sql = "select * from  Usuario";
            sql = sql + " where CodUsuario=" + CodUsuario.ToString();
            DataTable trdo = cDb.GetDatos(sql);
            if (trdo.Rows.Count > 0)
                user = trdo.Rows[0]["Nombre"].ToString();
            return user;
        }

        public bool consultaUsuario(string nombre) {
            string sql = "select * from  Usuario";
            sql = sql + " where Nombre LIKE '"+ nombre +"'";
            DataTable trdo = cDb.GetDatos(sql);
            if (trdo.Rows.Count > 0) {
                return false;
            }
            return true;
        }
        public DataTable GetUsuarioxCodigo(Int32 CodUsuario)
        {
            cUsuario user = new cUsuario();
            string sql = "select * from  Usuario ";
            sql = sql + " where CodUsuario=" + CodUsuario.ToString();
            return cDb.GetDatos(sql);
        }

        public string Eliminar(Int32 codusuario) {
            try {
                string sql = $"DELETE FROM  USUARIO WHERE CODUSUARIO = {codusuario}";
                cDb.Grabar(sql);
                return "ok";
                }catch(Exception e) {
                return "La operación no se pudo realizar "+e; }
        }

        public string Agregar(String  nombre, String clave , int docente =0)
        {
            clave = this.enc_des(clave, 'e'); // se encripta la clave  
            try
            {
                string sql = "";
                if (docente != 0)
                {
                    sql = $"INSERT INTO  \"ISAUI\".USUARIO (nombre, clave, coddocente) VALUES ('{nombre}','{clave}',{docente.ToString()})";
                }else
                    sql = $"INSERT INTO  USUARIO (nombre, clave ) VALUES ('{nombre}','{clave}')";
                cDb.Grabar(sql);
                return "ok";
            }
            catch (Exception e)
            {
                return "La operación no se pudo realizar "+e;
            }
        }

        public string Modificar(Int32 codusuario, string nombre, string clave)
        {
            clave = this.enc_des(clave, 'e');
            try
            {
                string sql = $"UPDATE FROM  USUARIO SET nombre ='{nombre}', clave ='{clave}' WHERE CODUSUARIO = {codusuario}";
                cDb.Grabar(sql);
                return "ok";
            }
            catch (Exception e)
            {
                return "La operación no se pudo realizar "+e;
            }
        }
        //Este metodo encripta / desencripta la cadena de claves para que no se vea en la base de datos
        private String enc_des(String clave, char tipo) {
            if (tipo == 'e')
            {
                var IV = ASCIIEncoding.ASCII.GetBytes("isaui123"); //La clave debe ser de 8 caracteres
                var EncryptionKey  = Convert.FromBase64String("naAr66AWvyVzxc8M05mDCZf9qYvShUT8");

                var buffer = Encoding.UTF8.GetBytes(clave);
                var des   = new TripleDESCryptoServiceProvider();
                des.Key = EncryptionKey;
                des.IV = IV;

                return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            if (tipo == 'd')
            {

                var IV  = ASCIIEncoding.ASCII.GetBytes("isaui123"); //La clave debe ser de 8 caracteres
                var EncryptionKey  = Convert.FromBase64String("naAr66AWvyVzxc8M05mDCZf9qYvShUT8"); //No se puede alterar la cantidad de caracteres pero si la clave

                var buffer = Convert.FromBase64String(clave);
                var des = new TripleDESCryptoServiceProvider();
                des.Key = EncryptionKey;
                des.IV = IV;
                return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));

            }
            return "";
        }

    }
}
