using System;

namespace CapaEntidad
{
    public class PrecioHistorico
    {
        public int Idprod { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
