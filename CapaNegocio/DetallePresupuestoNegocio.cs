using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class DetallePresupuestoNegocio
    {
        DetallePresupuestoDatos detallePresupuestoDatos = new DetallePresupuestoDatos();      

        public bool GrabarDetallePresupuesto(DetallePresupuesto detallePresupuesto)
        {
            return detallePresupuestoDatos.GrabarDetallePresupuesto(detallePresupuesto);
        }
    }
}