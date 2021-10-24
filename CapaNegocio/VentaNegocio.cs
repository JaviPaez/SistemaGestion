using CapaDatos;
using CapaEntidad;
using System;
using System.Data;

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

        public DataTable ReporteVenta()
        {
            return ventaDatos.ReporteVenta();
        }
    }
}
