using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class MedicoDatos : Conexion
    {
        public Boolean GrabarMedico(Medico medico)
        {
            try
            {
                var idMax = UltimoId();

                var grabarMedico = "INSERT INTO MEDICOS(ID,Apellido,Nombre,Matricula) VALUES(@ID, @Apellido, @Nombre, @Matricula)";

                SqlCommand com = new SqlCommand(grabarMedico, Conectar());

                com.Parameters.AddWithValue("@ID", idMax);
                com.Parameters.AddWithValue("@Apellido", medico.Apellido);
                com.Parameters.AddWithValue("@Nombre", medico.Nombre);
                com.Parameters.AddWithValue("@Matricula", medico.Matricula);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean ModificarMedico(Medico medico)
        {
            try
            {
                var modificarMedico = "UPDATE MEDICOS SET Matricula=@Matricula, Apellido=@Apellido, Nombre=@Nombre where Id=@Id";

                SqlCommand com = new SqlCommand(modificarMedico, Conectar());

                com.Parameters.AddWithValue("@Id", medico.Id);
                com.Parameters.AddWithValue("@Matricula", medico.Matricula);
                com.Parameters.AddWithValue("@Apellido", medico.Apellido);
                com.Parameters.AddWithValue("@Nombre", medico.Nombre);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ConsultarMedicos()
        {
            string medicos = "select * from MEDICOS order by Apellido";

            //*****************************************************
            var da = new SqlDataAdapter(medicos, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable CargarComboMedicos()
        {
            string medicos = "select ID, Apellido + ', ' + Nombre as ApeNom from MEDICOS order by ApeNom";

            //*****************************************************
            var da = new SqlDataAdapter(medicos, Conectar());
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
                var maxId = "select max(ID) + 1 from MEDICOS";

                //**************************************************
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
