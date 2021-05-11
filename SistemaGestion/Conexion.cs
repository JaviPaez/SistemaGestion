﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SistemaGestion
{
    public class Conexion
    {
        private SqlConnection sCon = new SqlConnection();
        private string con = "Data Source=JAVIER\\SQLSERVER;Integrated Security=SSPI;Initial Catalog=OPTICA";

        public SqlConnection conectar()
        {
            try
            {
                sCon = new SqlConnection(con);
                if (sCon.State.Equals(ConnectionState.Open))
                {
                    sCon.Close();
                }

                else sCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sCon;
        }
    }
}