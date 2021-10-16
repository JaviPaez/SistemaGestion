using System;

namespace CapaEntidad
{
    public class Precio
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdSubcategoria { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
