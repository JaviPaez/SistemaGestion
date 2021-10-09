using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CategoriaNegocio
    {
        CategoriaDatos categoriaDatos = new CategoriaDatos();

        public DataTable CargarComboCategorias()
        {
            return categoriaDatos.CargarComboCategorias();
        }

        public DataTable CargarComboSubCategorias(int idCat)
        {
            return categoriaDatos.CargarComboSubCategorias(idCat);
        }
    }
}
