using System;

namespace CapaEntidad
{
    public class ReporteDiaMasVentas
    {
        public DateTime Fecha { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int Cantidad { get; set; }
    }
}
