using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class DatosPresup
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Dni { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}
