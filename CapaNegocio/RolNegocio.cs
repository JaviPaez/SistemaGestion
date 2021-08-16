using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class RolNegocio
    {
        RolDatos rolDatos = new RolDatos();

        public DataTable CargarComboRoles()
        {
            return rolDatos.CargarComboRoles();
        }       
    }
}