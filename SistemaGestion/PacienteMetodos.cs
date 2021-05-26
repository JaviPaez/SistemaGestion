﻿using System;
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
                //var idMax = ultimoId();
                
                var sel = "set dateformat dmy INSERT INTO Pacientes(Dni,Apellido,Nombre,FechaNac,ObraSocial,NroAfiliado)" + " VALUES(" + paciente.Dni + ",'" + paciente.Apellido + "','" + paciente.Nombre + "','" + paciente.FechaNac + "','" + paciente.ObraSocial + "'," + paciente.NroAfiliado + ")";

                SqlCommand com = new SqlCommand(sel, conectar());

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
            string sqlStr = "select * from PACIENTES";
            //var c = AbrirConexion();


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable cargarComboPacientes()
        {

            string sqlStr = "select Dni from Pacientes";

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
