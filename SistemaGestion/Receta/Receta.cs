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
        public decimal Miop_OI { get; set; }
        public decimal Miop_OD { get; set; }
        public decimal Astig_OI { get; set; }
        public decimal Astig_OD { get; set; }     
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}
