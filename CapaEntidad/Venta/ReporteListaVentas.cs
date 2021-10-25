using System;

namespace CapaEntidad
{
    public class ReporteListaVentas
    {
        public int Nro { get; set; }
        public int DniUsuario { get; set; }
        public string Usu_ApeNom { get; set; }
        public int DniPaciente { get; set; }
        public string Pac_ApeNom { get; set; }    
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}