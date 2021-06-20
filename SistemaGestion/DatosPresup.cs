using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    public class DatosPresup
    {
        public string Paciente { get; set; }
        public int Cantidad { get; set; }
        public int Dni { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
    }
}
