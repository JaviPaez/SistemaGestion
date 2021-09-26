using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class UsuarioDatos : Conexion
    {
        //public DataTable ConsultarLogin(string dni, string contraseña)
        //{//Dni, Contraseña, Apellido, Nombre
        //    string login = "select * from USUARIOS where Dni = '" + dni + "' and Contraseña = '" + contraseña + "'";

        //    //*****************************************************
        //    var da = new SqlDataAdapter(login, Conectar());
        //    var ds = new DataSet();
        //    da.Fill(ds);
        //    DataTable dt = ds.Tables[0];

        //    return dt;
        //    //*****************************************************
        //}

        public SqlDataReader Login(string dni, string contraseña)
        {
            var cmd = new SqlCommand("SP_Login", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            var registro = cmd.ExecuteReader();

            return registro;
        }

        public Boolean GrabarUsuario(Usuario usuario)
        {
            try
            {
                var grabarUsuario = "INSERT INTO Usuarios(Dni, IdRol, Apellido, Nombre, Contraseña) VALUES(@Dni, @IdRol, @Apellido, @Nombre, @Contraseña)";

                SqlCommand com = new SqlCommand(grabarUsuario, Conectar());

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
            string usuarios = "select Apellido Apellidos, Nombre Nombres, Dni, NombreRol Rol from Usuarios join Roles on Usuarios.Idrol = Roles.Id order by Apellidos";

            //*****************************************************
            var da = new SqlDataAdapter(usuarios, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarUsuarioDni(int dni)
        {
            string usuario = "select Apellido Apellidos, Nombre Nombres, Dni, NombreRol Rol from Usuarios join Roles on Usuarios.Idrol = Roles.Id where Dni = " + dni;

            //*****************************************************
            var da = new SqlDataAdapter(usuario, Conectar());
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
            var da = new SqlDataAdapter(usuario, Conectar());
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
            var da = new SqlDataAdapter(usuarios, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
