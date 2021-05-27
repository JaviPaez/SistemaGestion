using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestion
{
    public partial class frmPresupuestos : Form
    {
        public frmPresupuestos()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmPresupuestos_Load(object sender, EventArgs e)
        {
            cboObraSocial.SelectedIndex = 0;
            dtpFecha.Format = DateTimePickerFormat.Short;
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var paciente = new Paciente();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    paciente.Dni = Convert.ToInt32(txtDni.Text);
                    paciente.Apellido = txtApellido.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.FechaNac = dtpFecha.Value;
                    paciente.ObraSocial = cboObraSocial.SelectedItem.ToString();
                    paciente.NroAfiliado = Convert.ToInt32(txtNroAfiliado.Text);

                    var pacienteMetodo = new PacienteMetodos();
                    Boolean grabo = pacienteMetodo.grabarPaciente(paciente);
                    if (grabo == false)
                    {
                        MessageBox.Show("Error en Grabacion", "ERROR");
                    }
                    else
                    {
                        MessageBox.Show("Grabacion Correcta", "Grabar");
                    }
                }
            }     
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnCancelar_Click(sender, e);
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDni.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtNroAfiliado.Text = "";
            dtpFecha.Value = DateTime.Now;
            cboObraSocial.SelectedIndex = 0;
        }
    }
}
