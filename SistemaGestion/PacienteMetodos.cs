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
        //CREATE
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

        public Boolean GrabarTelefonoPaciente(PacienteTelefono telPaciente)
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

                var grabarPaciente = "INSERT INTO PacienteeMail (ID, Dni, eMail) VALUES(@ID, @Dni, @eMail)";

                SqlCommand com = new SqlCommand(grabarPaciente, conectar());

                com.Parameters.AddWithValue("@ID", maxId);
                com.Parameters.AddWithValue("@Dni", mailPaciente.Dni);
                com.Parameters.AddWithValue("@eMail", mailPaciente.eMail);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean GrabarDireccionPaciente(PacienteDireccion direccionPaciente)
        {
            try
            {
                var maxId = UltimoIdDireccion();

                var grabarPaciente = "INSERT INTO PacienteDireccion (ID, Dni, Provincia, Localidad, Calle, Nro, Piso, Dpto, Manzana, Lote, Barrio) VALUES(@ID, @Dni, @Provincia, @Localidad, @Calle, @Nro, @Piso, @Dpto, @Manzana, @Lote, @Barrio)";

                SqlCommand com = new SqlCommand(grabarPaciente, conectar());

                com.Parameters.AddWithValue("@ID", maxId);
                com.Parameters.AddWithValue("@Dni", direccionPaciente.Dni);
                com.Parameters.AddWithValue("@Provincia", direccionPaciente.Provincia);
                com.Parameters.AddWithValue("@Localidad", direccionPaciente.Localidad);
                com.Parameters.AddWithValue("@Calle", direccionPaciente.Calle);
                com.Parameters.AddWithValue("@Nro", direccionPaciente.Nro);
                com.Parameters.AddWithValue("@Piso", direccionPaciente.Piso);
                com.Parameters.AddWithValue("@Dpto", direccionPaciente.Dpto);
                com.Parameters.AddWithValue("@Manzana", direccionPaciente.Manzana);
                com.Parameters.AddWithValue("@Lote", direccionPaciente.Lote);
                com.Parameters.AddWithValue("@Barrio", direccionPaciente.Barrio);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //UPDATE
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

        public Boolean ModificarTelefonoPaciente(PacienteTelefono telPaciente)
        {
            try
            {
                var modificarPaciente = "UPDATE PacienteTelefono SET NroTelefono=@NroTelefono where Dni=@Dni";

                SqlCommand com = new SqlCommand(modificarPaciente, conectar());

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

        public Boolean ModificarDireccionPaciente(PacienteDireccion direccionPaciente)
        {
            try
            {
                var modificarPaciente = "UPDATE PacienteDireccion SET Provincia=@Provincia, Localidad=@Localidad, Calle=@Calle, Nro=@Nro, Piso=@Piso, Dpto=@Dpto, Manzana=@Manzana, Lote=@Lote, Barrio=@Barrio where Dni=@Dni";

                SqlCommand com = new SqlCommand(modificarPaciente, conectar());

                com.Parameters.AddWithValue("@Dni", direccionPaciente.Dni);
                com.Parameters.AddWithValue("@Provincia", direccionPaciente.Provincia);
                com.Parameters.AddWithValue("@Localidad", direccionPaciente.Localidad);
                com.Parameters.AddWithValue("@Calle", direccionPaciente.Calle);
                com.Parameters.AddWithValue("@Nro", direccionPaciente.Nro);
                com.Parameters.AddWithValue("@Piso", direccionPaciente.Piso);
                com.Parameters.AddWithValue("@Dpto", direccionPaciente.Dpto);
                com.Parameters.AddWithValue("@Manzana", direccionPaciente.Manzana);
                com.Parameters.AddWithValue("@Lote", direccionPaciente.Lote);
                com.Parameters.AddWithValue("@Barrio", direccionPaciente.Barrio);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean ModificarMailPaciente(PacienteeMail mailPaciente)
        {
            try
            {
                var modificarPaciente = "UPDATE PacienteeMail SET eMail=@eMail where Dni=@Dni";

                SqlCommand com = new SqlCommand(modificarPaciente, conectar());

                com.Parameters.AddWithValue("@Dni", mailPaciente.Dni);
                com.Parameters.AddWithValue("@eMail", mailPaciente.eMail);

                com.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //CONSULTAS
        public DataTable ConsultarPacientes()
        {
            string pacientes = "select Pacientes.Dni 'D.N.I.', Apellido Apellidos, Nombre Nombres, FechaNac 'Fecha de Nacimiento', ObraSocial 'Obra Social', NroAfiliado 'Nº Afiliado', NroTelefono Telefono, eMail 'e-Mail', Provincia, Localidad, Calle, nro Nº, Piso, Dpto, Manzana, Lote, Barrio from Pacientes left join PacienteTelefono on PacienteTelefono.Dni = Pacientes.Dni left join PacienteDireccion on PacienteDireccion.Dni = Pacientes.Dni left join PacienteeMail on PacienteeMail.Dni = Pacientes.Dni order by Pacientes.Dni";

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
            string paciente = "select Pacientes.Dni 'D.N.I.', Apellido Apellidos, Nombre Nombres, FechaNac 'Fecha de Nacimiento', ObraSocial 'Obra Social', NroAfiliado 'Nº Afiliado', NroTelefono Telefono, eMail 'e-Mail', Provincia, Localidad, Calle, nro Nº, Piso, Dpto, Manzana, Lote, Barrio from Pacientes left join PacienteTelefono on PacienteTelefono.Dni = Pacientes.Dni left join PacienteDireccion on PacienteDireccion.Dni = Pacientes.Dni left join PacienteeMail on PacienteeMail.Dni = Pacientes.Dni where Pacientes.Dni = " + dni;

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
            string paciente = "select Pacientes.Dni 'D.N.I.', Apellido Apellidos, Nombre Nombres, FechaNac 'Fecha de Nacimiento', ObraSocial 'Obra Social', NroAfiliado 'Nº Afiliado', NroTelefono Telefono, eMail 'e-Mail', Provincia, Localidad, Calle, nro Nº, Piso, Dpto, Manzana, Lote, Barrio from Pacientes left join PacienteTelefono on PacienteTelefono.Dni = Pacientes.Dni left join PacienteDireccion on PacienteDireccion.Dni = Pacientes.Dni left join PacienteeMail on PacienteeMail.Dni = Pacientes.Dni where Apellido + ' ' + Nombre like '%" + apeNom + "%'";

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
    }
}