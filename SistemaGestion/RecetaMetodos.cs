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
        public int UltimoId()
        {
            try
            {
                var maxId = "select max(ID) + 1 from RECETAS";
                //***************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public Boolean GrabarReceta(Receta receta)
        {
            try
            {
                var idMax = UltimoId();

                var grabarReceta = "set dateformat dmy INSERT INTO RECETAS(ID,IdMedico,Dni,Miop_OI,Miop_OD,Astig_OI,Astig_OD,Fecha,Observaciones)" + " VALUES(" + idMax + "," + receta.IdMedico + "," + receta.Dni + ",'" + receta.Miop_OI + "','" + receta.Miop_OD + "','" + receta.Astig_OI + "','" + receta.Astig_OD + "','" + receta.Fecha + "','" + receta.Observaciones + "')";

                SqlCommand com = new SqlCommand(grabarReceta, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable ConsultarRecetas()
        {
            string recetas = "select * from RECETAS";

            //*****************************************************
            var da = new SqlDataAdapter(recetas, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable CargarComboRecetas(int dniPaciente)
        {
            string recetas = "select ID,Fecha from RECETAS where Dni = " + dniPaciente + " order by Fecha desc";

            //*****************************************************
            var da = new SqlDataAdapter(recetas, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public SqlDataReader CargarLabelReceta (int idReceta)
        {
            //string receta = "select *,convert (varchar(10),Fecha,103) as FechaOK from RECETAS where ID = " + idReceta;
            string receta = "select * from RECETAS where ID = " + idReceta;

            //*****************************************************
            var comando = new SqlCommand(receta, conectar());

            SqlDataReader registro = comando.ExecuteReader();

            return registro;
            //*****************************************************
        }
    }
}
