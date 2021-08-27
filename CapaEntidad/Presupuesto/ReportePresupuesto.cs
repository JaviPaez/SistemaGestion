using System;

namespace CapaEntidad
{
    public class ReportePresupuesto
    {
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }        
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime Fecha { get; set; }        
    }
}
