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
                var grabarPaciente = "set dateformat dmy INSERT INTO PACIENTES (Dni, Apellido, Nombre, FechaNac, ObraSocial, NroAfiliado) VALUES(@Dni, @Apellido, @Nombre, @FechaNac, @ObraSocial, @NroAfiliado)";

                SqlCommand com = new SqlCommand(grabarPaciente, conectar());

                com.Parameters.AddWithValue("@Dni", paciente.Dni);
                com.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                com.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                com.Parameters.AddWithValue("@FechaNac", paciente.FechaNac);
                com.Parameters.AddWithValue("@ObraSocial", paciente.ObraSocial);
                com.Parameters.AddWithValue("@NroAfiliado", paciente.NroAfiliado);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean GrabarTelPaciente(PacienteTelefono telPaciente)
        {
            try
            {
                var maxId = UltimoIdTelefono();

                var grabarPaciente = "INSERT INTO PacienteTelefono (ID, Dni, NroTelefono) VALUES(@ID, @Dni, @NroTelefono)";

                SqlCommand com = new SqlCommand(grabarPaciente, conectar());

                com.Parameters.AddWithValue("@ID", maxId);
                com.Parameters.AddWithValue("@Dni", telPaciente.Dni);
                com.Parameters.AddWithValue("@NroTelefono", telPaciente.NroTelefono);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean GrabarMailPaciente(PacienteeMail mailPaciente)
        {
            try
            {
                var maxId = UltimoIdMail();

                var grabarPaciente = "set dateformat dmy INSERT INTO PacienteTelefono (ID, Dni, NroTelefono) VALUES(@ID, @Dni, @NroTelefono)";

                SqlCommand com = new SqlCommand(grabarPaciente, conectar());

                com.Parameters.AddWithValue("@ID", maxId);
                com.Parameters.AddWithValue("@Dni", mailPaciente.Dni);
                com.Parameters.AddWithValue("@NroTelefono", telPaciente.NroTelefono);

                com.ExecuteNonQuery();

                return true;
            }
            catch
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
            catch
            {
                return false;
            }
        }

        public int UltimoIdTelefono()
        {
            try
            {
                var maxId = "select max(ID) + 1 from PacienteTelefono";

                //**************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public int UltimoIdDireccion()
        {
            try
            {
                var maxId = "select max(ID) + 1 from PacienteDireccion";

                //**************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public int UltimoIdMail()
        {
            try
            {
                var maxId = "select max(ID) + 1 from PacienteeMail";

                //**************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        //CONSULTAR PACIENTES
        public DataTable ConsultarPacientes()
        {
            string pacientes = "select Pacientes.Dni, Apellido, Nombre, FechaNac, ObraSocial, NroAfiliado ,(select NroTelefono where Pacientes.dni = PacienteTelefono.Dni) as Telefono from Pacientes, PacienteTelefono";

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
            string paciente = "select Pacientes.Dni, Apellido, Nombre, FechaNac, ObraSocial, NroAfiliado ,(select NroTelefono where Pacientes.dni = PacienteTelefono.Dni) as Telefono from Pacientes, PacienteTelefono where Pacientes.Dni = " + dni;

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
            string paciente = "select Pacientes.Dni, Apellido, Nombre, FechaNac, ObraSocial, NroAfiliado ,(select NroTelefono where Pacientes.dni = PacienteTelefono.Dni) as Telefono from Pacientes, PacienteTelefono where Apellido + ' ' + Nombre like '%" + apeNom + "%'";

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
            string pacientes = "select Dni, Apellido, Nombre from PACIENTES order by Dni";

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
            string paciente = "select Dni, Apellido, Nombre from PACIENTES where Dni = " + Dni;

            //*****************************************************
            var comando = new SqlCommand(paciente, conectar());

            SqlDataReader registro = comando.ExecuteReader();
                       
            return registro;
            //*****************************************************
        }
    }
}