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
            string login = "select Dni, Contraseña, Apellido, Nombre from USUARIOS where Dni = '" + dni + "' and Contraseña = '" + contraseña + "'";      

            //*****************************************************
            var da = new SqlDataAdapter(login, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }      
               
        public Boolean GrabarUsuario(Usuario usuario)
        {
            try
            {  
                var grabarUsuario = "INSERT INTO Usuarios(Dni, IdRol, Apellido, Nombre, Contraseña) VALUES(@Dni, @IdRol, @Apellido, @Nombre, @Contraseña)";

                SqlCommand com = new SqlCommand(grabarUsuario, conectar());

                com.Parameters.AddWithValue("@Dni", usuario.Dni);
                com.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                com.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                com.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                com.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;              
            }            
        }

        public DataTable ConsultarUsuarios()
        {
            string usuarios = "select Dni,Apellido Apellidos, Nombre Nombres,NombreRol Rol from Usuarios join Roles on Usuarios.Idrol = Roles.Id order by Dni";

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
            string usuario = "select Dni,Apellido Apellidos, Nombre Nombres,NombreRol Rol from Usuarios join Roles on Usuarios.Idrol = Roles.Id where Dni = " + dni;

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
            string usuario = "select Dni,Apellido Apellidos, Nombre Nombres,NombreRol Rol from Usuarios join Roles on Usuarios.Idrol = Roles.Id where Apellido + ' ' + Nombre like '%" + ApeNom + "%'";

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
