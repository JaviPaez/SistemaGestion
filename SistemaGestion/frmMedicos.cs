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
    public partial class frmMedicos : Form
    {
        public frmMedicos()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmMedicos_Load(object sender, EventArgs e)
        {            
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var medico = new Medico();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    medico.Matricula = txtMatricula.Text;
                    medico.Apellido = txtApellido.Text;
                    medico.Nombre = txtNombre.Text;                    

                    var medicoMetodo = new MedicoMetodos();
                    Boolean grabo = medicoMetodo.grabarMedico(medico);
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
            txtMatricula.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
        }
    }
}
