using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class Paciente
    {
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string ObraSocial { get; set; }
        public int NroAfiliado { get; set; }
    }
}
