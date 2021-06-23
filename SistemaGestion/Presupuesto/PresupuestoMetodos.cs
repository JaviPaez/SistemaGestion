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
                SqlCommand com = new SqlCommand(maxId, Conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        public int GrabarPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                var idMax = UltimoId();

                var grabarPresupuesto = "set dateformat dmy INSERT INTO PRESUPUESTOS(Nro, DniUsuario, DniPaciente, IdReceta, Fecha) VALUES (@Nro, @DniUsuario, @DniPaciente, @IdReceta, @Fecha)";

                SqlCommand com = new SqlCommand(grabarPresupuesto, Conectar());

                com.Parameters.AddWithValue("@Nro", idMax);
                com.Parameters.AddWithValue("@DniUsuario", presupuesto.DniUsuario);
                com.Parameters.AddWithValue("@DniPaciente", presupuesto.DniPaciente);
                com.Parameters.AddWithValue("@IdReceta", presupuesto.IdReceta);
                com.Parameters.AddWithValue("@Fecha", presupuesto.Fecha);

                com.ExecuteNonQuery();

                return idMax;
            }
            catch
            {
                return 0;              
            }            
        }

        public DataTable ConsultarPresupuestos()
        {
            string presupuestos = "select * from PRESUPUESTOS order by Fecha desc";    

            //*****************************************************
            var da = new SqlDataAdapter(presupuestos, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable BuscarPresupuesto(int dni)
        {
            string presupuesto = "select Nro as 'Nº Presupuesto', Dni, Apellido + ', ' + Nombre as 'Apellido, Nombre', Fecha, Descripcion, PrecioUnitario, DetallePresupuesto.Cantidad from Presupuestos, DetallePresupuesto, Productos, Pacientes where DetallePresupuesto.NroPresupuesto = Presupuestos.Nro and DetallePresupuesto.IdProducto = Productos.ID and Dni = " + dni + "order by Fecha desc";

            //*****************************************************
            var da = new SqlDataAdapter(presupuesto, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
