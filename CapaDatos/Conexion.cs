using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public abstract class Conexion
    {
        private SqlConnection sCon = new SqlConnection();
        private readonly string con = "Data Source=JAVIER;Integrated Security=SSPI;Initial Catalog=OPTICA";

        public SqlConnection Conectar()
        {
            try
            {
                sCon = new SqlConnection(con);
                if (sCon.State.Equals(ConnectionState.Open))
                {
                    sCon.Close();
                }

                else sCon.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return sCon;
        }
    }
}