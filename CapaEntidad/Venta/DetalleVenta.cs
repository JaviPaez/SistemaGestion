namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int NroPresupuesto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
