using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    class Usuario
    {
        public Int32 Dni { get; set; }
        public Int32 IdRol { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
    }
}
