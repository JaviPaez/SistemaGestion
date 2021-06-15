using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class PacienteDireccion
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public string Piso { get; set; }
        public string Dpto { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Barrio { get; set; }
    }
}
