using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class ProductoDatos : Conexion
    {
        public Boolean GrabarProducto(Producto producto)
        {
            try
            {
                var idMax = UltimoId();

                var grabarProducto = "INSERT INTO PRODUCTOS(ID, Descripcion, Precio, Cantidad) VALUES(@ID, @Descripcion, @Precio, @Cantidad)";

                SqlCommand com = new SqlCommand(grabarProducto, Conectar());

                com.Parameters.AddWithValue("@ID", idMax);
                com.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                //com.Parameters.AddWithValue("@Precio", producto.Precio);
                com.Parameters.AddWithValue("@Cantidad", producto.Cantidad);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean ModificarProducto(Producto producto)
        {
            try
            {
                var modificarProducto = "UPDATE PRODUCTOS SET Descripcion=@Descripcion, Precio=@Precio, Cantidad=@Cantidad where ID=@ID";

                SqlCommand com = new SqlCommand(modificarProducto, Conectar());

                com.Parameters.AddWithValue("@ID", producto.Id);
                com.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                //com.Parameters.AddWithValue("@Precio", producto.Precio);
                com.Parameters.AddWithValue("@Cantidad", producto.Cantidad);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ConsultarProductos()
        {
            string productos = "select productos.ID, marcas.id idmarca, subcategorias.id idsubcategoria, categorias.id idcategoria, nombre Marca, productos.Descripcion, categorias.descripcion Categoria,  subcategorias.descripcion Subcategoria, Cantidad " +
            "from productos " +
            "join marcas on idmarca = marcas.id " +
            "join Subcategorias on IdSubCategoria = Subcategorias.id " +
            "join Categorias on Categorias.id = Subcategorias.IdCategoria";

            //*****************************************************
            var da = new SqlDataAdapter(productos, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarProductoDescripcion(string descripcion)
        {
            string producto = "select productos.ID, marcas.id idmarca, subcategorias.id idsubcategoria, categorias.id idcategoria, nombre Marca, productos.Descripcion, categorias.descripcion Categoria,  subcategorias.descripcion Subcategoria, Cantidad from productos join marcas on idmarca = marcas.id join Subcategorias on IdSubCategoria = Subcategorias.id join Categorias on Categorias.id = Subcategorias.IdCategoria where productos.Descripcion like '%" + descripcion + "%' order by productos.Descripcion";

            //*****************************************************
            var da = new SqlDataAdapter(producto, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarProductoId(Int64 id)
        {
            string producto = "select * from PRODUCTOS where Id = " + id;

            //*****************************************************
            var da = new SqlDataAdapter(producto, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataRow BuscarIdProducto(int idProducto)
        {
            var dt = new DataTable();
            var ds = new DataSet();
            DataRow dr;

            string producto = "select * from PRODUCTOS where ID = " + idProducto;
            var da = new SqlDataAdapter(producto, Conectar());

            da.Fill(ds);
            dt = ds.Tables["Descripcion"];

            dr = ds.Tables[0].Rows[0];

            return dr;
        }

        public DataTable CargarComboProductos()
        {
            string productos = "select ID, Descripcion from PRODUCTOS order by Descripcion";

            //*****************************************************
            var da = new SqlDataAdapter(productos, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public long UltimoId()
        {
            try
            {
                var maxId = "select max(ID) + 1 from PRODUCTOS";
                //*************************************************
                SqlCommand com = new SqlCommand(maxId, Conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }
    }
}
