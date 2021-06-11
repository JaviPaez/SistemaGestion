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
    public partial class frmPacientes : Form
    {
        public frmPacientes()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmPacientes_Load(object sender, EventArgs e)
        {            
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.MaxDate = DateTime.Today;

            ReiniciarCampos();
            ArmarGrilla();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var paciente = new Paciente();
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    paciente.Dni = Convert.ToInt32(txtDni.Text);
                    paciente.Apellido = txtApellido.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.FechaNac = dtpFecha.Value;
                    paciente.ObraSocial = cboObraSocial.SelectedItem.ToString();
                    paciente.NroAfiliado = Convert.ToInt32(txtNroAfiliado.Text);

                    var pacienteMetodo = new PacienteMetodos();
                    Boolean grabo = pacienteMetodo.GrabarPaciente(paciente);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
            catch (Exception ex)
            {
                MessageBox.Show("Error en grabación: " + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ArmarGrilla();
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la modificación?", "Modificar", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);

            var paciente = new Paciente();
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    paciente.Dni = Convert.ToInt32(txtDni.Text);
                    paciente.Apellido = txtApellido.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.FechaNac = dtpFecha.Value;
                    paciente.ObraSocial = cboObraSocial.SelectedItem.ToString();
                    paciente.NroAfiliado = Convert.ToInt32(txtNroAfiliado.Text);

                    var pacienteMetodo = new PacienteMetodos();
                    Boolean modifico = pacienteMetodo.ModificarPaciente(paciente);

                    if (modifico == false) MessageBox.Show("Error en modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Modificación correcta", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ArmarGrilla();
        }

        //BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //BOTON ARMAR LISTA
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        //BOTON BUSCAR POR DNI O APELLIDO Y NOMBRE
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != string.Empty)
            {
                try
                {
                    var ds = new DataSet();
                    var dt = new DataTable();
                    var al = new PacienteMetodos();

                    int dni;
                    if (!int.TryParse(txtBuscar.Text, out dni))
                    {
                        dt = al.BuscarPacienteApeNom(txtBuscar.Text);
                    }
                    else dt = al.BuscarPacienteDni(dni);

                    if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese Dni o apellido y nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Ingrese Dni o apellido y nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ReiniciarCampos();
        }

        //CLICK EN CONTENIDO DE CELDA DGV
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDni.Text = dgvGrilla.CurrentRow.Cells[0].Value.ToString();
                txtApellido.Text = dgvGrilla.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvGrilla.CurrentRow.Cells[2].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvGrilla.CurrentRow.Cells[3].Value);
                cboObraSocial.SelectedItem = dgvGrilla.CurrentRow.Cells[4].Value.ToString();
                txtNroAfiliado.Text= dgvGrilla.CurrentRow.Cells[5].Value.ToString();
            }
            catch(Exception ex)
            {
            }
        }

        //Armar grilla
        private void ArmarGrilla()
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new PacienteMetodos();
            dt = al.ConsultarPacientes();

            if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
            else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtBuscar.Clear();
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtNroAfiliado.Clear();
            dtpFecha.Value = DateTime.Today;
            cboObraSocial.SelectedIndex = 0;
            txtDni.Focus();
        }
    }
}