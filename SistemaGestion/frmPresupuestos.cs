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
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.MaxDate = DateTime.Today;

            //Cargar Combo Usuarios
            var dt = new DataTable();
            var user = new LoginMetodos();
            dt = user.cargarComboUsuarios();

            cboUsuario.DataSource = dt;
            cboUsuario.DisplayMember = "ApeNom";
            cboUsuario.ValueMember = "Dni";

            //Cargar Combo Pacientes
            var dt2 = new DataTable();
            var pac = new PacienteMetodos();
            dt = pac.cargarComboPacientes();

            cboDniPaciente.DataSource = dt;
            cboDniPaciente.DisplayMember = "Dni";
            cboDniPaciente.ValueMember = "Dni";

            //Cargar Combo Receta
            var dt3 = new DataTable();
            var rec = new RecetaMetodos();
            dt = rec.cargarComboRecetas(Convert.ToInt32(cboDniPaciente.SelectedValue));

            cboIdReceta.DataSource = dt;
            cboIdReceta.DisplayMember = "Id";
            cboIdReceta.ValueMember = "Id";

            cboIdReceta.Text = "Seleccione";
            cboUsuario.Text = "Seleccione";
            cboDniPaciente.Text = "Seleccione";
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var presupuesto = new Presupuesto();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    presupuesto.DniUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                    presupuesto.DniPaciente = Convert.ToInt32(cboDniPaciente.SelectedValue);
                    presupuesto.IdReceta = Convert.ToInt32(cboIdReceta.SelectedValue);
                    presupuesto.Fecha = dtpFecha.Value;
                    presupuesto.Validez = txtValidez.Text;
                    presupuesto.Total = txtTotal.Text;

                    var presupuestoMetodo = new PresupuestoMetodos();
                    Boolean grabo = presupuestoMetodo.grabarPresupuesto(presupuesto);
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
            cboDniPaciente.Text = "Seleccione";
            cboUsuario.Text = "Seleccione";
            cboIdReceta.Text = "Seleccione";            
            txtValidez.Clear();
            txtTotal.Clear();
            dtpFecha.Value = DateTime.Now;            
        }
    }
}
