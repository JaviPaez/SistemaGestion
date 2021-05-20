using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class Receta
    {
        int Id { get; set; }
        int IdMedico { get; set; }
        int Dni { get; set; }      
        double OD { get; set; }
        double OI { get; set; }
        DateTime Fecha { get; set; }
        string Observaciones { get; set; }
    }
}
