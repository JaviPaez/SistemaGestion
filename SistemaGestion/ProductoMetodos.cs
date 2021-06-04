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
        public long ultimoId()
        {
            try
            {
                var selMax = "select max(ID) + 1 from PRODUCTOS";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }
               
        public Boolean grabarProducto(Producto producto)
        {
            try
            {
                var idMax = ultimoId();

                var sel = "INSERT INTO PRODUCTOS(ID,Descripcion,Precio,Cantidad)" + " VALUES(" + idMax + ",'" + producto.Descripcion + "','" + producto.Precio + "'," + producto.Cantidad +  ")";

                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        //CONSULTAR PRODUCTOS
        public DataTable consultarProductos()
        {
            string sqlStr = "select * from PRODUCTOS";

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable buscarProducto(string sel)
        {
            string sqlStr = "select * from PRODUCTOS where Descripcion like '%" + sel + "%'";

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
