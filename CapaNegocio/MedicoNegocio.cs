using System;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class MedicoNegocio
    {
        MedicoDatos medicoDatos = new MedicoDatos();

        public Boolean GrabarMedico(Medico medico)
        {
            return medicoDatos.GrabarMedico(medico);
        }

        public Boolean ModificarMedico(Medico medico)
        {
            return medicoDatos.ModificarMedico(medico);
        }

        public DataTable ConsultarMedicos()
        {
            return medicoDatos.ConsultarMedicos();
        }

        public DataTable CargarComboMedicos()
        {
            return medicoDatos.CargarComboMedicos();
        }
    }
}
