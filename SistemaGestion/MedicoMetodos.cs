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
        public int UltimoId()
        {
            try
            {
                var maxId = "select max(ID) + 1 from MEDICOS";

                //**************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public Boolean GrabarMedico(Medico medico)
        {
            try
            {
                var idMax = UltimoId();

                var grabarMedico = "INSERT INTO MEDICOS(ID,Apellido,Nombre,Matricula)" + " VALUES(" + idMax + ",'" + medico.Apellido + "','" + medico.Nombre + "','" + medico.Matricula + "')";

                SqlCommand com = new SqlCommand(grabarMedico, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean ModificarMedico(Medico medico)
        {
            try
            {
                var modificarMedico = "set dateformat dmy UPDATE MEDICOS SET Matricula=@Matricula, Apellido=@Apellido, Nombre=@Nombre where Id=@Id";

                SqlCommand com = new SqlCommand(modificarMedico, conectar());

                com.Parameters.AddWithValue("@Id", medico.Id);
                com.Parameters.AddWithValue("@Matricula", medico.Matricula);
                com.Parameters.AddWithValue("@Apellido", medico.Apellido);
                com.Parameters.AddWithValue("@Nombre", medico.Nombre);  

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //CONSULTAR MEDICOS
        public DataTable ConsultarMedicos()
        {
            string medicos = "select * from MEDICOS order by ID";

            //*****************************************************
            var da = new SqlDataAdapter(medicos, conectar());
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
            var da = new SqlDataAdapter(medicos, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
