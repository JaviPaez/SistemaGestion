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
        //Cargar ComboRoles
        public DataTable cargarComboRoles()
        {
            string sqlStr = "select ID, NombreRol from ROLES order by Id";

            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public int ultimoId()
        {
            try
            {
                var selMax = "select max(ID) + 1 from ROLES";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        } 
    }
}