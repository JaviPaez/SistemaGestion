using System;

namespace CapaEntidad
{
    public class Usuario
    {
        public Int32 Dni { get; set; }
        public Int32 IdRol { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string email { get; set; }
    }
}
