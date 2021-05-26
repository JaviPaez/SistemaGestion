using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class MedicoMetodos : Conexion
    {
        public DataTable cargarComboMedicos()
        {

            string sqlStr = "select ID, Apellido + ', ' + Nombre as ApeNom from Medicos order by ApeNom";

            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
