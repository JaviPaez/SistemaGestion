using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class MarcaNegocio
    {
        MarcaDatos marcaDatos = new MarcaDatos();

        public DataTable CargarComboMarcas()
        {
            return marcaDatos.CargarComboMarcas();
        }
    }
}
