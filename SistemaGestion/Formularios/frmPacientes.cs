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
            //ArmarGrilla();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var paciente = new Paciente();
            var telPaciente = new PacienteTelefono();
            var mailPaciente = new PacienteeMail();
            var direccPaciente = new PacienteDireccion();

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    paciente.Dni = Convert.ToInt32(txtDni.Text);
                    paciente.Apellido = txtApellido.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.FechaNac = dtpFecha.Value;
                    if (cboObraSocial.Text == "SELECCIONE" || cboObraSocial.SelectedItem == null)
                    {
                        paciente.ObraSocial = "";
                    }
                    else paciente.ObraSocial = cboObraSocial.SelectedItem.ToString();

                    if (Int64.TryParse(txtNroAfiliado.Text, out Int64 nroAfiliado))
                    {
                        paciente.NroAfiliado = nroAfiliado;
                    }

                    //Telefono
                    telPaciente.Dni = Convert.ToInt32(txtDni.Text);
                    if (Int64.TryParse(txtTelefono.Text, out Int64 telefono))
                    {
                        telPaciente.NroTelefono = telefono;
                    }

                    //Mail
                    mailPaciente.Dni = Convert.ToInt32(txtDni.Text);
                    mailPaciente.eMail = txtMail.Text;

                    //Direccion
                    direccPaciente.Dni = Convert.ToInt32(txtDni.Text);
                    if (cboProvincia.Text == "SELECCIONE" || cboProvincia.SelectedItem == null)
                    {
                        direccPaciente.Provincia = "";
                    }
                    else direccPaciente.Provincia = cboProvincia.SelectedItem.ToString();


                    direccPaciente.Localidad = txtLocalidad.Text;
                    direccPaciente.Calle = txtCalle.Text;
                    if (Int32.TryParse(txtNro.Text, out Int32 nro))
                    {
                        direccPaciente.Nro = nro;
                    }
                    direccPaciente.Piso = txtPiso.Text;
                    direccPaciente.Dpto = txtDpto.Text;
                    direccPaciente.Manzana = txtManzana.Text;
                    direccPaciente.Lote = txtLote.Text;
                    direccPaciente.Barrio = txtBarrio.Text;

                    //Grabo
                    var pacienteMetodo = new PacienteMetodos();

                    Boolean grabo = pacienteMetodo.GrabarPaciente(paciente);
                    pacienteMetodo.GrabarTelefonoPaciente(telPaciente);
                    pacienteMetodo.GrabarMailPaciente(mailPaciente);
                    pacienteMetodo.GrabarDireccionPaciente(direccPaciente);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information); MostrarPacienteActual(Convert.ToInt32(txtDni.Text));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la modificación?", "Modificar", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);

            var paciente = new Paciente();
            var telPaciente = new PacienteTelefono();
            var mailPaciente = new PacienteeMail();
            var direccPaciente = new PacienteDireccion();

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    paciente.Dni = Convert.ToInt32(txtDni.Text);
                    paciente.Apellido = txtApellido.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.FechaNac = dtpFecha.Value;
                    if (cboObraSocial.Text == "SELECCIONE" || cboObraSocial.SelectedItem == null)
                    {
                        paciente.ObraSocial = "";
                    }
                    else paciente.ObraSocial = cboObraSocial.SelectedItem.ToString();

                    if (Int64.TryParse(txtNroAfiliado.Text, out Int64 nroAfiliado))
                    {
                        paciente.NroAfiliado = nroAfiliado;
                    }

                    //Telefono
                    telPaciente.Dni = Convert.ToInt32(txtDni.Text);
                    if (Int64.TryParse(txtTelefono.Text, out Int64 telefono))
                    {
                        telPaciente.NroTelefono = telefono;
                    }

                    //Mail
                    mailPaciente.Dni = Convert.ToInt32(txtDni.Text);
                    mailPaciente.eMail = txtMail.Text;

                    //Direccion
                    direccPaciente.Dni = Convert.ToInt32(txtDni.Text);
                    if (cboProvincia.Text == "SELECCIONE" || cboProvincia.SelectedItem == null)
                    {
                        direccPaciente.Provincia = "";
                    }
                    else direccPaciente.Provincia = cboProvincia.SelectedItem.ToString();


                    direccPaciente.Localidad = txtLocalidad.Text;
                    direccPaciente.Calle = txtCalle.Text;
                    if (Int32.TryParse(txtNro.Text, out Int32 nro))
                    {
                        direccPaciente.Nro = nro;
                    }
                    direccPaciente.Piso = txtPiso.Text;
                    direccPaciente.Dpto = txtDpto.Text;
                    direccPaciente.Manzana = txtManzana.Text;
                    direccPaciente.Lote = txtLote.Text;
                    direccPaciente.Barrio = txtBarrio.Text;

                    var pacienteMetodo = new PacienteMetodos();
                    Boolean modifico = pacienteMetodo.ModificarPaciente(paciente);
                    pacienteMetodo.ModificarMailPaciente(mailPaciente);
                    pacienteMetodo.ModificarTelefonoPaciente(telPaciente);
                    pacienteMetodo.ModificarDireccionPaciente(direccPaciente);

                    if (modifico == false) MessageBox.Show("Error en modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Modificación correcta", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        MostrarPacienteActual(Convert.ToInt32(txtDni.Text));
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error en modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

                    if (!int.TryParse(txtBuscar.Text, out int dni))
                    {
                        dt = al.BuscarPacienteApeNom(txtBuscar.Text);
                    }
                    else dt = al.BuscarPacienteDni(dni);

                    if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
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
                txtDni.Text = dgvGrilla.CurrentRow.Cells["D.N.I."].Value.ToString();
                txtApellido.Text = dgvGrilla.CurrentRow.Cells["Apellidos"].Value.ToString();
                txtNombre.Text = dgvGrilla.CurrentRow.Cells["Nombres"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvGrilla.CurrentRow.Cells[3].Value);
                cboObraSocial.Text = dgvGrilla.CurrentRow.Cells[4].Value.ToString();
                txtNroAfiliado.Text = dgvGrilla.CurrentRow.Cells[5].Value.ToString();

                //Telefono
                txtTelefono.Text = dgvGrilla.CurrentRow.Cells[6].Value.ToString();

                //Mail
                txtMail.Text = dgvGrilla.CurrentRow.Cells[7].Value.ToString();

                //Direccion
                cboProvincia.Text = dgvGrilla.CurrentRow.Cells[8].Value.ToString();
                txtLocalidad.Text = dgvGrilla.CurrentRow.Cells[9].Value.ToString();
                txtCalle.Text = dgvGrilla.CurrentRow.Cells[10].Value.ToString();
                txtNro.Text = dgvGrilla.CurrentRow.Cells[11].Value.ToString();
                txtPiso.Text = dgvGrilla.CurrentRow.Cells[12].Value.ToString();
                txtDpto.Text = dgvGrilla.CurrentRow.Cells[13].Value.ToString();
                txtManzana.Text = dgvGrilla.CurrentRow.Cells[14].Value.ToString();
                txtLote.Text = dgvGrilla.CurrentRow.Cells[15].Value.ToString();
                txtBarrio.Text = dgvGrilla.CurrentRow.Cells[16].Value.ToString();
        }

        //Armar grilla
        private void ArmarGrilla()
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new PacienteMetodos();
                dt = al.ConsultarPacientes();

                if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscar.Clear();
        }

        private void MostrarPacienteActual(int dni)
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new PacienteMetodos();

                dt = al.BuscarPacienteDni(dni);

                if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtNroAfiliado.Clear();
            dtpFecha.Value = DateTime.Today;
            cboObraSocial.Text = "SELECCIONE";

            txtTelefono.Clear();

            txtMail.Clear();

            cboProvincia.Text = "SELECCIONE";
            txtLocalidad.Clear();
            txtCalle.Clear();
            txtNro.Clear();
            txtPiso.Clear();
            txtDpto.Clear();
            txtManzana.Clear();
            txtLote.Clear();
            txtBarrio.Clear();

            txtDni.Focus();
        }
    }
}