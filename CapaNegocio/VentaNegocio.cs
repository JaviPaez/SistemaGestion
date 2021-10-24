using CapaDatos;
using CapaEntidad;
using System;

namespace CapaNegocio
{
    public class VentaNegocio
    {
        VentaDatos ventaDatos = new VentaDatos();

        public int GrabarVenta(Venta venta)
        {
            return ventaDatos.GrabarVenta(venta);
        }

        public Boolean GrabarDetalleVenta(DetalleVenta detalleVenta)
        {
            return ventaDatos.GrabarDetalleVenta(detalleVenta);
        }

        //public DataTable ConsultarPresupuestoReporte()
        //{
        //    return ventaDatos.();
        //}
    }
}
