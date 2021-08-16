using System;
using System.Data;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();

        public DataTable Login(string dni, string contraseña)
        {
            return usuarioDatos.ConsultarLogin(dni,contraseña);
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
