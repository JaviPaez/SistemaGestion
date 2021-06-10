using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class RolMetodos : Conexion
    {
        public DataTable CargarComboRoles()
        {
            string roles = "select ID, NombreRol from ROLES order by ID";

            //*****************************************************
            var da = new SqlDataAdapter(roles, conectar());
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
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        } 
    }
}