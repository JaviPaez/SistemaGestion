using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class PresupuestoMetodos : Conexion
    {
        public int ultimoId()
        {
            try
            {
                var selMax = "select max(Nro) + 1 from PRESUPUESTOS";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public Boolean grabarPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                var idMax = ultimoId();

                var sel = "set dateformat dmy INSERT INTO PRESUPUESTOS(Nro,DniUsuario,DniPaciente,IdReceta,Fecha,Validez,Total)" + " VALUES(" + idMax + "," + presupuesto.DniUsuario + "," + presupuesto.DniPaciente + "," + presupuesto.IdReceta + ",'" + presupuesto.Fecha + "','" + presupuesto.Validez + "','" + presupuesto.Total + "')";

                SqlCommand com = new SqlCommand(sel, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable consultar()
        {
            string sqlStr = "select * from PRESUPUESTOS";    


            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable buscarPresupuesto(int Nro)
        {
            string sqlStr = "select * from PRESUPUESTOS where Nro = " + Nro;


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
