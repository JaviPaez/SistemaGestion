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
        public int ultimoId()
        {
            try
            {
                var selMax = "select max(ID) + 1 from MEDICOS";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }
        public Boolean grabarMedico(Medico medico)
        {
            try
            {
                var idMax = ultimoId();

                var sel = "INSERT INTO MEDICOS(ID,Apellido,Nombre,Matricula)" + " VALUES(" + idMax + ",'" + medico.Apellido + "','" + medico.Nombre + "','" + medico.Matricula + "')";

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
        public DataTable consultarMedicos()
        {
            string sqlStr = "select * from MEDICOS order by ID";
            //var c = AbrirConexion();


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable cargarComboMedicos()
        {

            string sqlStr = "select ID, Apellido + ', ' + Nombre as ApeNom from MEDICOS order by ApeNom";

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
