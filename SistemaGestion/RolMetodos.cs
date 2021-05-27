using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    class RolMetodos : Conexion
    {
        //Cargar ComboRoles
        public DataTable cargarComboRoles()
        {

            string sqlStr = "select ID, NombreRol from Roles order by Id";

            //********************************************************
            var da = new SqlDataAdapter(sqlStr, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public int ultimoId()
        {
            try
            {
                var selMax = "select max(ID) + 1 from Roles";
                //********************************************************
                SqlCommand com = new SqlCommand(selMax, conectar());
                return (int)com.ExecuteScalar();
            }
            catch
            {
                return 1;
            }
        }

        //public Boolean grabarReceta(Receta receta)
        //{
        //    try
        //    {
        //        var idMax = ultimoId();

        //        var sel = "set dateformat dmy INSERT INTO Recetas(ID,IdMedico,Dni,OI,OD,Fecha,Observaciones)" + " VALUES(" + idMax + "," + receta.IdMedico + "," + receta.Dni + ",'" + receta.OI + "','" + receta.OD + "','" + receta.Fecha + "','" + receta.Observaciones + "')";

        //        SqlCommand com = new SqlCommand(sel, conectar());

        //        com.ExecuteNonQuery();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;              
        //    }            
        //}

        //public DataTable Consultar()
        //{
        //    string sqlStr = "select * from Recetas";
        //    //var c = AbrirConexion();


        //    //********************************************************
        //    var da = new SqlDataAdapter(sqlStr, conectar());
        //    var ds = new DataSet();
        //    da.Fill(ds);
        //    DataTable dt = ds.Tables[0];

        //    return dt;
        //    //*****************************************************
        //}
    }
}