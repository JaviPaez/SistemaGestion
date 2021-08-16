using System;

namespace CapaEntidad
{
    public class Paciente
    {
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string ObraSocial { get; set; }
        public Int64 NroAfiliado { get; set; }
    }
}
