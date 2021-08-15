using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    public class UsuarioDireccion
    {
        int Id { get; set; }
        int Dni { get; set; }      
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        string Piso { get; set; }
        string Dpto { get; set; }
        string Manzana { get; set; }
        string Lote { get; set; }
        string Barrio { get; set; }
    }
}
