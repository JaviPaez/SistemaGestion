using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class RecetaMetodos : Conexion
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
        public long ultimoId()
        {
                var selMax = "select max(id) + 1 from Recetas";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)(long)com.ExecuteScalar();
         }
               
        public Boolean grabarReceta(Receta receta)
        {
            try
            {
                //var idMax = ultimoId();

                //var sel = "INSERT INTO Recetas(Dni,IdRol,Apellido,Nombre,Contraseña)" + " VALUES(" + usu.Dni+ " ," + usu.IdRol + ",'" + usu.Apellido + "','" + usu.Nombre + "','" + usu.Contraseña + "')";

                //SqlCommand com = new SqlCommand(sel, conectar());

                //com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable Consultar()
        {
            string sqlStr = "select * from Usuarios";
            //var c = AbrirConexion();


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
