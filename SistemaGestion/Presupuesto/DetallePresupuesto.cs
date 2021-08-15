using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    public class DetallePresupuesto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int NroPresupuesto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
