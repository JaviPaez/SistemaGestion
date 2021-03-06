using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class RecetaDatos : Conexion
    {
        public Boolean GrabarReceta(Receta receta)
        {
            try
            {
                var idMax = UltimoId();

                var grabarReceta = "set dateformat dmy INSERT INTO RECETAS(ID, IdMedico, Dni, Miop_OI, Miop_OD, Astig_OI, Astig_OD, Fecha, Observaciones) VALUES(@ID, @IdMedico, @Dni, @Miop_OI, @Miop_OD, @Astig_OI, @Astig_OD, @Fecha, @Observaciones)";

                SqlCommand com = new SqlCommand(grabarReceta, Conectar());

                com.Parameters.AddWithValue("@ID", idMax);
                com.Parameters.AddWithValue("@IdMedico", receta.IdMedico);
                com.Parameters.AddWithValue("@Dni", receta.Dni);
                com.Parameters.AddWithValue("@Miop_OI", receta.Miop_OI);
                com.Parameters.AddWithValue("@Miop_OD", receta.Miop_OD);
                com.Parameters.AddWithValue("@Astig_OI", receta.Astig_OI);
                com.Parameters.AddWithValue("@Astig_OD", receta.Astig_OD);
                com.Parameters.AddWithValue("@Fecha", receta.Fecha);
                com.Parameters.AddWithValue("@Observaciones", receta.Observaciones);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ConsultarRecetas(int dni)
        {
            string recetas = "SP_ConsultarRecetas";

            //*****************************************************
            var com = new SqlCommand(recetas, Conectar());
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@dniPac", dni);

            SqlDataReader dr = com.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            return dt;
            //*****************************************************
        }

        public DataTable CargarComboRecetas(int dniPaciente)
        {
            string recetas = "select ID,Fecha from RECETAS where Dni = " + dniPaciente + " order by Fecha desc";

            //*****************************************************
            var da = new SqlDataAdapter(recetas, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public SqlDataReader CargarLabelReceta(int idReceta)
        {
            string receta = "select * from RECETAS where ID = " + idReceta;

            //*****************************************************
            var comando = new SqlCommand(receta, Conectar());

            SqlDataReader registro = comando.ExecuteReader();

            return registro;
            //*****************************************************
        }

        public int UltimoId()
        {
            try
            {
                var maxId = "select max(ID) + 1 from RECETAS";
                //***************************************************
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
