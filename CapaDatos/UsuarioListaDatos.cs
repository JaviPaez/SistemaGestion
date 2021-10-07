using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioListaDatos : Conexion
    {
        public DataTable ReporteListaUsuarios()
        {
            string cmd = "select * from ListaUsuarios()";

            //*****************************************************
            var da = new SqlDataAdapter(cmd, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
