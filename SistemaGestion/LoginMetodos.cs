using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class LoginMetodos : Conexion
    {
        public DataTable ConsultarLogin(string usu, string pas)
        {
            string sqlStr = "select usuario, contrasenia from login where usuario = '" + usu + "' and contrasenia = '" +
                            pas + "'";
                 
            //var c = AbrirConexion();


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
        public long ultimoId()
        {
                var selMax = "select max(id) + 1 from Login";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)(long)com.ExecuteScalar();
         }
               
        public Boolean grabarUsuario(LoginEn usu)
        {
            try
            {
                var idMax = ultimoId();

                var sel = "set dateformat dmy INSERT INTO Login(id,Usuario, Contrasenia, Permisos)" +
                    " VALUES (" + idMax + ",'" + usu.usuario + "','" + usu.contrasenia + "'," + usu.permisos + ")";
                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

    }
}
