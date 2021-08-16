using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class PresupuestoNegocio
    {
        PresupuestoDatos presupuestoDatos = new PresupuestoDatos();       
        public int GrabarPresupuesto(Presupuesto presupuesto)
        {
            return presupuestoDatos.GrabarPresupuesto(presupuesto);
        }

        public DataTable ConsultarPresupuestos()
        {
            return presupuestoDatos.ConsultarPresupuestos();
        }

        public DataTable BuscarPresupuesto(int dni)
        {
            return presupuestoDatos.BuscarPresupuesto(dni);
        }
    }
}
