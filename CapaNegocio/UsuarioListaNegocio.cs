using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class UsuarioListaNegocio
    {
        UsuarioListaDatos usuarioLista = new UsuarioListaDatos();

        public DataTable ReporteListaUsuarios()
        {
            return usuarioLista.ReporteListaUsuarios();
        }
    }
}
