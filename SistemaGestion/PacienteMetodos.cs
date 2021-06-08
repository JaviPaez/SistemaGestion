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
        public Boolean grabarPaciente(Paciente paciente)
        {
            try
            {     
                var sel = "set dateformat dmy INSERT INTO PACIENTES(Dni,Apellido,Nombre,FechaNac,ObraSocial,NroAfiliado)" + " VALUES(" + paciente.Dni + ",'" + paciente.Apellido + "','" + paciente.Nombre + "','" + paciente.FechaNac + "','" + paciente.ObraSocial + "'," + paciente.NroAfiliado + ")";

                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean modificarPaciente(Paciente paciente)
        {
            try
            {    
                var actualizar = "set dateformat dmy UPDATE PACIENTES SET Dni=@Dni, Apellido=@Apellido, Nombre=@Nombre, FechaNac=@FechaNac, ObraSocial=@ObraSocial ,NroAfiliado=@NroAfiliado where Dni=@Dni";                

                SqlCommand com = new SqlCommand(actualizar, conectar());

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
        public DataTable consultarPacientes()
        {
            string sqlStr = "select * from PACIENTES";
          
            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable buscarPacienteDni(int Dni)
        {
            string sqlStr = "select * from PACIENTES where Dni = " + Dni;

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable buscarPacienteApeNom(string ApeNom)
        {
            string sqlStr = "select * from PACIENTES where Apellido + ' ' + Nombre like '%" + ApeNom + "%'";

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable cargarComboPacientes()
        {
            string sqlStr = "select Dni,Apellido,Nombre from PACIENTES";

            //*****************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public SqlDataReader cargarLabelNomPac(int Dni)
        {
            string sqlStr = "select Dni,Apellido,Nombre from PACIENTES where Dni = " + Dni;

            //*****************************************************
            var comando = new SqlCommand(sqlStr, conectar());

            SqlDataReader registro = comando.ExecuteReader();
                       
            return registro;
            //*****************************************************
        }
    }
}