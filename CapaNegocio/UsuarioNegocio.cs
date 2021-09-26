using System;
using System.Data;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();

        public SqlDataReader Login(int dni, string contraseña)
        {
            return usuarioDatos.Login(dni,contraseña);
        }      
               
        public Boolean GrabarUsuario(Usuario usuario)
        {
            return usuarioDatos.GrabarUsuario(usuario);
        }

        public DataTable ConsultarUsuarios()
        {
            return usuarioDatos.ConsultarUsuarios();
        }

        public DataTable BuscarUsuarioDni(int dni)
        {
            return usuarioDatos.BuscarUsuarioDni(dni);
        }

        public DataTable BuscarUsuarioApeNom(string ApeNom)
        {
            return usuarioDatos.BuscarUsuarioApeNom(ApeNom);
        }

        public DataTable CargarComboUsuarios()
        {
            return usuarioDatos.CargarComboUsuarios();
        }
    }
}
