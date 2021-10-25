using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class VentaDatos : Conexion
    {
        public int GrabarVenta(Venta venta)
        {
            try
            {
                var idMax = UltimoId();

                var grabarVenta = "SP_GrabarVenta";

                SqlCommand sqlCom = new SqlCommand(grabarVenta, Conectar());
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.AddWithValue("@Nro", idMax);
                sqlCom.Parameters.AddWithValue("@DniUsuario", venta.DniUsuario);
                sqlCom.Parameters.AddWithValue("@DniPaciente", venta.DniPaciente);
                sqlCom.Parameters.AddWithValue("@IdReceta", venta.IdReceta);
                sqlCom.Parameters.AddWithValue("@Fecha", venta.Fecha);

                sqlCom.ExecuteNonQuery();

                return idMax;
            }
            catch
            {
                return 0;
            }
        }

        public int UltimoId()
        {
            try
            {
                var maxId = "select max(Nro) + 1 from VENTAS";
                //***************************************************
                SqlCommand com = new SqlCommand(maxId, Conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public DataTable ReporteVenta()
        {
            var dt = new DataTable();
            try
            {
                string sqlStr = "SP_ReporteVenta";

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlStr, Conectar());
                ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

                return dt;
            }
            catch
            {
                return dt;
            }
        }

        public DataTable ReporteListaVentas(ReporteListaVentas venta)
        {
            string listaVentas = "SP_ReporteListaVentas";

            //*****************************************************
            var com = new SqlCommand(listaVentas, Conectar());
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@dniUsu", venta.DniUsuario);
            com.Parameters.AddWithValue("@fecha1", venta.FechaDesde);
            com.Parameters.AddWithValue("@fecha2", venta.FechaHasta);

            SqlDataReader dr = com.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            return dt;
            //*****************************************************
        }

        //DETALLE VENTA
        public bool GrabarDetalleVenta(DetalleVenta detalleVenta)
        {
            try
            {
                var maxId = DetalleUltimoId();

                var grabarDetalleVenta = "SP_GrabarDetalleVenta";

                SqlCommand sqlCom = new SqlCommand(grabarDetalleVenta, Conectar());
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.AddWithValue("@ID", maxId);
                sqlCom.Parameters.AddWithValue("@IdProducto", detalleVenta.IdProducto);
                sqlCom.Parameters.AddWithValue("@NroVenta", detalleVenta.NroVenta);
                sqlCom.Parameters.AddWithValue("@Cantidad", detalleVenta.Cantidad);
                sqlCom.Parameters.AddWithValue("@PrecioUnitario", detalleVenta.PrecioUnitario);

                sqlCom.ExecuteNonQuery();

                return true;
            }

            catch
            {
                return false;
            }
        }

        public int DetalleUltimoId()
        {
            try
            {
                var maxId = "SELECT max(ID) + 1 from DetalleVenta";
                //****************************************************
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
