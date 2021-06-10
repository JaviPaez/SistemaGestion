using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class ProductoMetodos : Conexion
    {        
        public long UltimoId()
        {
            try
            {
                var maxId = "select max(ID) + 1 from PRODUCTOS";
                //*************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }
               
        public Boolean GrabarProducto(Producto producto)
        {
            try
            {
                var idMax = UltimoId();

                var grabarProducto = "INSERT INTO PRODUCTOS(ID,Descripcion,Precio,Cantidad)" + " VALUES(" + idMax + ",'" + producto.Descripcion + "','" + producto.Precio + "'," + producto.Cantidad +  ")";

                SqlCommand com = new SqlCommand(grabarProducto, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public Boolean ModificarProducto(Producto producto)
        {
            try
            {
                var modificarProducto = "UPDATE PRODUCTOS SET Descripcion=@Descripcion, Precio=@Precio, Cantidad=@Cantidad where Id=@Id";

                SqlCommand com = new SqlCommand(modificarProducto, conectar());

                com.Parameters.AddWithValue("@Id", producto.Id);
                com.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                com.Parameters.AddWithValue("@Precio", producto.Precio);
                com.Parameters.AddWithValue("@Cantidad", producto.Cantidad);

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //CONSULTAR PRODUCTOS
        public DataTable ConsultarProductos()
        {
            string productos = "select * from PRODUCTOS";

            //*****************************************************
            var da = new SqlDataAdapter(productos, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarProductoDescripcion(string descripcion)
        {
            string producto = "select * from PRODUCTOS where Descripcion like '%" + descripcion + "%'";

            //*****************************************************
            var da = new SqlDataAdapter(producto, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataRow BuscarProductoId(int idProducto)
        {
            var dt = new DataTable();
            var ds = new DataSet();
            DataRow dr;

            string producto = "select * from PRODUCTOS where ID = " + idProducto;
            var da = new SqlDataAdapter(producto, conectar());

            da.Fill(ds);
            dt = ds.Tables["Descripcion"];

            dr = ds.Tables[0].Rows[0];

            return dr;
        }

        public DataTable CargarComboProductos()
        {
            string productos = "select ID, Descripcion from PRODUCTOS order by ID";

            //*****************************************************
            var da = new SqlDataAdapter(productos, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
