namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int NroVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
