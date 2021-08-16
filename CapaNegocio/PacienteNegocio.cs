using System;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class PacienteNegocio
    {
        PacienteDatos pacienteDatos = new PacienteDatos();
        
        public Boolean GrabarPaciente(Paciente paciente)
        {
            return pacienteDatos.GrabarPaciente(paciente);
        }

        public Boolean GrabarTelefonoPaciente(PacienteTelefono telPaciente)
        {
            return pacienteDatos.GrabarTelefonoPaciente(telPaciente);
        }

        public Boolean GrabarMailPaciente(PacienteeMail mailPaciente)
        {
            return pacienteDatos.GrabarMailPaciente(mailPaciente);
        }

        public Boolean GrabarDireccionPaciente(PacienteDireccion direccionPaciente)
        {
            return pacienteDatos.GrabarDireccionPaciente(direccionPaciente);
        }

        public Boolean ModificarPaciente(Paciente paciente)
        {
            return pacienteDatos.ModificarPaciente(paciente);
        }

        public Boolean ModificarTelefonoPaciente(PacienteTelefono telPaciente)
        {
            return pacienteDatos.ModificarTelefonoPaciente(telPaciente);
        }

        public Boolean ModificarDireccionPaciente(PacienteDireccion direccionPaciente)
        {
            return pacienteDatos.ModificarDireccionPaciente(direccionPaciente);
        }

        public Boolean ModificarMailPaciente(PacienteeMail mailPaciente)
        {
            return pacienteDatos.ModificarMailPaciente(mailPaciente);
        }

        public DataTable ConsultarPacientes()
        {
            return pacienteDatos.ConsultarPacientes();
        }

        public DataTable BuscarPacienteDni(int dni)
        {
            return pacienteDatos.BuscarPacienteDni(dni);
        }

        public DataTable BuscarPacienteApeNom(string apeNom)
        {
            return pacienteDatos.BuscarPacienteApeNom(apeNom);
        }

        public DataTable CargarComboPacientes()
        {
            return pacienteDatos.CargarComboPacientes();
        }

        public SqlDataReader CargarLabelNomPac(int dni)
        {
            return pacienteDatos.CargarLabelNomPac(dni);
        }        
    }
}