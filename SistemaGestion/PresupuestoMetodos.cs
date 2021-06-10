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
        public int UltimoId()
        {
            try
            {
                var maxId = "select max(Nro) + 1 from PRESUPUESTOS";
                //***************************************************
                SqlCommand com = new SqlCommand(maxId, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public Boolean GrabarPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                var idMax = UltimoId();

                var grabarPresupuesto = "set dateformat dmy INSERT INTO PRESUPUESTOS(Nro,DniUsuario,DniPaciente,IdReceta,Fecha,Total)" + " VALUES(" + idMax + "," + presupuesto.DniUsuario + "," + presupuesto.DniPaciente + "," + presupuesto.IdReceta + ",'" + presupuesto.Fecha + "','" + presupuesto.Total + "')";

                SqlCommand com = new SqlCommand(grabarPresupuesto, conectar());

                com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }

        public DataTable ConsultarPresupuestos()
        {
            string presupuestos = "select * from PRESUPUESTOS";    

            //*****************************************************
            var da = new SqlDataAdapter(presupuestos, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarPresupuesto(int nro)
        {
            string presupuesto = "select * from PRESUPUESTOS where Nro = " + nro;

            //*****************************************************
            var da = new SqlDataAdapter(presupuesto, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
