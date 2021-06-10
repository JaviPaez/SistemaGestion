using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class PacienteMetodos : Conexion
    {
        public Boolean GrabarPaciente(Paciente paciente)
        {
            try
            {     
                var grabarPaciente = "set dateformat dmy INSERT INTO PACIENTES(Dni,Apellido,Nombre,FechaNac,ObraSocial,NroAfiliado)" + " VALUES(" + paciente.Dni + ",'" + paciente.Apellido + "','" + paciente.Nombre + "','" + paciente.FechaNac + "','" + paciente.ObraSocial + "'," + paciente.NroAfiliado + ")";

                SqlCommand com = new SqlCommand(grabarPaciente, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean ModificarPaciente(Paciente paciente)
        {
            try
            {    
                var modificarPaciente = "set dateformat dmy UPDATE PACIENTES SET Dni=@Dni, Apellido=@Apellido, Nombre=@Nombre, FechaNac=@FechaNac, ObraSocial=@ObraSocial ,NroAfiliado=@NroAfiliado where Dni=@Dni";                

                SqlCommand com = new SqlCommand(modificarPaciente, conectar());

                com.Parameters.AddWithValue("@Dni", paciente.Dni);
                com.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                com.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                com.Parameters.AddWithValue("@FechaNac", paciente.FechaNac);
                com.Parameters.AddWithValue("@ObraSocial", paciente.ObraSocial); 
                com.Parameters.AddWithValue("@NroAfiliado", paciente.NroAfiliado);

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //CONSULTAR PACIENTES
        public DataTable ConsultarPacientes()
        {
            string pacientes = "select * from PACIENTES";
          
            //*****************************************************
            var da = new SqlDataAdapter(pacientes, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarPacienteDni(int dni)
        {
            string paciente = "select * from PACIENTES where Dni = " + dni;

            //*****************************************************
            var da = new SqlDataAdapter(paciente, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarPacienteApeNom(string apeNom)
        {
            string paciente = "select * from PACIENTES where Apellido + ' ' + Nombre like '%" + apeNom + "%'";

            //*****************************************************
            var da = new SqlDataAdapter(paciente, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable CargarComboPacientes()
        {
            string pacientes = "select Dni,Apellido,Nombre from PACIENTES";

            //*****************************************************
            var da = new SqlDataAdapter(pacientes, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public SqlDataReader CargarLabelNomPac(int Dni)
        {
            string paciente = "select Dni,Apellido,Nombre from PACIENTES where Dni = " + Dni;

            //*****************************************************
            var comando = new SqlCommand(paciente, conectar());

            SqlDataReader registro = comando.ExecuteReader();
                       
            return registro;
            //*****************************************************
        }
    }
}