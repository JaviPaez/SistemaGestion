using CapaEntidad;
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

                var grabarVenta = "set dateformat dmy INSERT INTO PRESUPUESTOS(Nro, DniUsuario, DniPaciente, IdReceta, Fecha) VALUES (@Nro, @DniUsuario, @DniPaciente, @IdReceta, @Fecha)";

                SqlCommand sqlCom = new SqlCommand(grabarVenta, Conectar());

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

        //DETALLE VENTA
        public bool GrabarDetalleVenta(DetalleVenta detalleVenta)
        {
            try
            {
                var maxId = DetalleUltimoId();

                var grabarDetalleVenta = "INSERT INTO DetallePresupuesto(ID, IdProducto, NroPresupuesto, Cantidad, PrecioUnitario) VALUES (@ID, @IdProducto, @NroPresupuesto, @Cantidad, @PrecioUnitario)";

                SqlCommand sqlCom = new SqlCommand(grabarDetalleVenta, Conectar());

                sqlCom.Parameters.AddWithValue("@ID", maxId);
                sqlCom.Parameters.AddWithValue("@IdProducto", detalleVenta.IdProducto);
                sqlCom.Parameters.AddWithValue("@NroPresupuesto", detalleVenta.NroPresupuesto);
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
