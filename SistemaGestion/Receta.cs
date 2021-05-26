using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class Receta
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public int Dni { get; set; }
        public double OD { get; set; }
        public double OI { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}
