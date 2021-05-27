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
        public DataTable ConsultarLogin(string user, string pass)
        {
            string sqlStr = "select dni, contraseña from Usuarios where dni = '" + user + "' and contraseña = '" +
                            pass + "'";
                 
            //var c = AbrirConexion();


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }      
               
        public Boolean grabarUsuario(Usuario usu)
        {
            try
            {  
                var sel = "INSERT INTO Usuarios(Dni,IdRol,Apellido,Nombre,Contraseña)" + " VALUES(" + usu.Dni+ " ," + usu.IdRol + ",'" + usu.Apellido + "','" + usu.Nombre + "','" + usu.Contraseña + "')";

                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable Consultar()
        {
            string sqlStr = "select * from USUARIOS order by Dni";
            //var c = AbrirConexion();


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable buscarUsuario(int Dni)
        {
            string sqlStr = "select * from USUARIOS where Dni = " + Dni;


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
