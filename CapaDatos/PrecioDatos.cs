using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PrecioDatos : Conexion
    {
        public Boolean GrabarPrecio(Precio precio)
        {
            try
            {
                var grabarProducto = "SP_ActualizarPrecio";

                SqlCommand com = new SqlCommand(grabarProducto, Conectar());
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.AddWithValue("@porcentaje", precio.Porcentaje);
                com.Parameters.AddWithValue("@fecha", precio.Fecha);
                com.Parameters.AddWithValue("@idsubcat", precio.IdSubcategoria);

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
