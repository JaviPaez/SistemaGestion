using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MarcaDatos : Conexion
    {
        public DataTable CargarComboMarcas()
        {
            string marcas = "select ID, Nombre from Marcas order by Nombre";

            //*****************************************************
            var da = new SqlDataAdapter(marcas, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
