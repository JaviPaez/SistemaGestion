namespace CapaEntidad
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int IdSubcategoria { get; set; }
        public int IdMarca { get; set; }
        public decimal Costo { get; set; }
    }
}