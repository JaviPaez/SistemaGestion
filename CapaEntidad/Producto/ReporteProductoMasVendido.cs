using System;

namespace CapaEntidad
{
    public class ReporteProductoMasVendido
    {
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}
