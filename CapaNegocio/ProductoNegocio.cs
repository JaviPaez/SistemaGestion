using System;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        ProductoDatos productoDatos = new ProductoDatos();
               
        public Boolean GrabarProducto(Producto producto)
        {
            return productoDatos.GrabarProducto(producto);
        }

        public Boolean ModificarProducto(Producto producto)
        {
            return productoDatos.ModificarProducto(producto);
        }

        public DataTable ConsultarProductos()
        {
            return productoDatos.ConsultarProductos();
        }

        public DataTable BuscarProductoDescripcion(string descripcion)
        {
            return productoDatos.BuscarProductoDescripcion(descripcion);
        }

        public DataTable BuscarProductoxSubcategoria(int subcat)
        {
            return productoDatos.BuscarProductoxSubcategoria(subcat);
        }

        public DataTable BuscarProductoId(Int64 id)
        {
            return productoDatos.BuscarProductoId(id);
        }

        public DataRow BuscarIdProducto(int idProducto)
        {
            return productoDatos.BuscarIdProducto(idProducto);
        }

        public DataTable CargarComboProductos()
        {
            return productoDatos.CargarComboProductos();
        }

        public long UltimoId()
        {
            return productoDatos.UltimoId();
        }

        public DataTable ListarProductos()
        {
            return productoDatos.ListarProductos();
        }

        public DataTable GraficarPreciosHistoricos(PrecioHistorico prod)
        {
            return productoDatos.GraficarPreciosHistoricos(prod);
        }
    }
}
