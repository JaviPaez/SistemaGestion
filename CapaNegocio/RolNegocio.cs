using System.Data;
using System.Data.SqlClient;
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