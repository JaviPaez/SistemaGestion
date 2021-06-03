using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class Presupuesto
    {
        public int Nro { get; set; }
        public int DniUsuario { get; set; }
        public int DniPaciente { get; set; }
        public int IdReceta { get; set; }
        public DateTime Fecha { get; set; }        
        public string Total { get; set; }
    }
}
