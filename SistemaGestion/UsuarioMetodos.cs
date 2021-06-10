using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class UsuarioMetodos : Conexion
    {
        public DataTable ConsultarLogin(string dni, string contraseña)
        {
            string login = "select Dni, Contraseña from USUARIOS where Dni = '" + dni + "' and Contraseña = '" + contraseña + "'";      

            //*****************************************************
            var da = new SqlDataAdapter(login, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }      
               
        public Boolean GrabarUsuario(Usuario usu)
        {
            try
            {  
                var grabarUsuario = "INSERT INTO Usuarios(Dni,IdRol,Apellido,Nombre,Contraseña)" + " VALUES(" + usu.Dni+ " ," + usu.IdRol + ",'" + usu.Apellido + "','" + usu.Nombre + "','" + usu.Contraseña + "')";

                SqlCommand com = new SqlCommand(grabarUsuario, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable ConsultarUsuarios()
        {
            string usuarios = "select * from USUARIOS order by Dni";

            //*****************************************************
            var da = new SqlDataAdapter(usuarios, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarUsuarioDni(int dni)
        {
            string usuario = "select * from USUARIOS where Dni = " + dni;

            //*****************************************************
            var da = new SqlDataAdapter(usuario, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarUsuarioApeNom(string ApeNom)
        {
            string usuario = "select * from USUARIOS where Apellido + ' ' + Nombre like '%" + ApeNom + "%'";

            //*****************************************************
            var da = new SqlDataAdapter(usuario, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable CargarComboUsuarios()
        {
            string usuarios = "select Dni, Apellido + ', ' + Nombre as ApeNom from USUARIOS order by ApeNom";

            //*****************************************************
            var da = new SqlDataAdapter(usuarios, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
