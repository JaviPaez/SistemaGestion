using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CategoriaDatos : Conexion
    {
        public DataTable CargarComboCategorias()
        {
            string categorias = "select ID, Descripcion from Categorias order by Descripcion";

            //*****************************************************
            var da = new SqlDataAdapter(categorias, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }

        public DataTable CargarComboSubCategorias(int idCat)
        {
            string subcategorias = "select ID, Descripcion from SubCategorias where IdCategoria = " + idCat + "order by Descripcion";

            //*****************************************************
            var da = new SqlDataAdapter(subcategorias, Conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
            //*****************************************************
        }
    }
}
