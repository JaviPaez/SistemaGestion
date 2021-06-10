using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class RecetaMetodos : Conexion
    {    
        public int ultimoId()
        {
            try
            {
                var selMax = "select max(ID) + 1 from RECETAS";
                //***************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public Boolean grabarReceta(Receta receta)
        {
            try
            {
                var idMax = ultimoId();

                var sel = "set dateformat dmy INSERT INTO RECETAS(ID,IdMedico,Dni,Miop_OI,Miop_OD,Astig_OI,Astig_OD,Fecha,Observaciones)" + " VALUES(" + idMax + "," + receta.IdMedico + "," + receta.Dni + ",'" + receta.Miop_OI + "','" + receta.Miop_OD + "','" + receta.Astig_OI + "','" + receta.Astig_OD + "','" + receta.Fecha + "','" + receta.Observaciones + "')";

                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable Consultar()
        {
            string sqlStr = "select * from RECETAS";

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable cargarComboRecetas(int DniPaciente)
        {
            string sqlStr = "select ID from RECETAS where Dni = " + DniPaciente;

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public SqlDataReader cargarLabelReceta (int IdReceta)
        {
            string sqlStr = "select * from RECETAS where ID = " + IdReceta;

            //*****************************************************
            var comando = new SqlCommand(sqlStr, conectar());

            SqlDataReader registro = comando.ExecuteReader();

            return registro;
            //*****************************************************
        }
    }
}
