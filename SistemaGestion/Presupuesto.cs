using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class Presupuesto
    {
        int Nro { get; set; }
        int DniUsuario { get; set; }    
        int DniPaciente { get; set; }
        int IdReceta { get; set; }        
        DateTime Fecha { get; set; }       
        string Validez { get; set; }
        double Total { get; set; }
    }
}
