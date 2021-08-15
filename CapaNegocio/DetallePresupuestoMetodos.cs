using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SistemaGestion
{
    public class DetallePresupuestoMetodos : Conexion
    {
        public int UltimoId()
        {
            try
            {
                var maxId = "SELECT max(ID) + 1 from DetallePresupuesto";
                //****************************************************
                SqlCommand com = new SqlCommand(maxId, Conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public bool GrabarDetallePresupuesto(DetallePresupuesto detallePresupuesto)
        {
            try
            {
                var maxId = UltimoId();

                var grabarDetallePresupuesto = "INSERT INTO DetallePresupuesto(ID, IdProducto, NroPresupuesto, Cantidad, PrecioUnitario) VALUES (@ID, @IdProducto, @NroPresupuesto, @Cantidad, @PrecioUnitario)";

                SqlCommand com = new SqlCommand(grabarDetallePresupuesto, Conectar());

                com.Parameters.AddWithValue("@ID", maxId);
                com.Parameters.AddWithValue("@IdProducto", detallePresupuesto.IdProducto);
                com.Parameters.AddWithValue("@NroPresupuesto", detallePresupuesto.NroPresupuesto);
                com.Parameters.AddWithValue("@Cantidad", detallePresupuesto.Cantidad);
                com.Parameters.AddWithValue("@PrecioUnitario", detallePresupuesto.PrecioUnitario);

                com.ExecuteNonQuery();

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}