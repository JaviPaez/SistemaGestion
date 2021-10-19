using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class RecetaNegocio
    {
        RecetaDatos recetaDatos = new RecetaDatos();

        public Boolean GrabarReceta(Receta receta)
        {
            return recetaDatos.GrabarReceta(receta);
        }

        public DataTable ConsultarRecetas(int dni)
        {
            return recetaDatos.ConsultarRecetas(dni);
        }

        public DataTable CargarComboRecetas(int dniPaciente)
        {
            return recetaDatos.CargarComboRecetas(dniPaciente);
        }

        public SqlDataReader CargarLabelReceta (int idReceta)
        {
            return recetaDatos.CargarLabelReceta(idReceta);
        }
    }
}
