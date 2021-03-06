using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class RolDatos : Conexion
    {
        public DataTable CargarComboRoles()
        {
            string roles = "select ID, NombreRol from ROLES order by NombreRol";

            //*****************************************************
            var da = new SqlDataAdapter(roles, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public int UltimoId()
        {
            try
            {
                var maxId = "select max(ID) + 1 from ROLES";
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
