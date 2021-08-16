using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Presentacion
{
    public partial class frmRecetas : Form
    {
        public frmRecetas()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRecetas_Load(object sender, EventArgs e)
        {
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.MaxDate = DateTime.Today;
            ReiniciarCampos();

            //Cargar Combo Medicos
            CargarMedicos();

            //Cargar Combo Pacientes
            var dt2 = new DataTable();
            var pac = new PacienteMetodos();
            dt2 = pac.CargarComboPacientes();

            cboDni.DataSource = dt2;
            cboDni.DisplayMember = "Dni";
            cboDni.ValueMember = "Dni";


            ReiniciarCampos();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var receta = new Receta();
            if (respuesta == DialogResult.Yes)
            {
                List<decimal> valores;
                valores = VerificarDecimal();

                if (valores.Count != 0)
                {
                    var valoresCorrectos = VerificarValoresCorrectos(valores);
                    if (valoresCorrectos == true)
                    {
                        receta.Miop_OI = valores[0];
                        receta.Miop_OD = valores[1];
                        receta.Astig_OI = valores[2];
                        receta.Astig_OD = valores[3];

                        try
                        {
                            if (cboMedico.Text == "SELECCIONE" || cboMedico.SelectedValue == null)
                            {
                                receta.IdMedico = 0;
                            }
                            else
                            {
                                receta.IdMedico = Convert.ToInt32(cboMedico.SelectedValue);
                            }

                            receta.Dni = Convert.ToInt32(cboDni.SelectedValue);
                            receta.Fecha = dtpFecha.Value;
                            receta.Observaciones = txtObserv.Text;

                            var recetaMetodo = new RecetaNegocio();
                            Boolean grabo = recetaMetodo.GrabarReceta(receta);

                            if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else MessageBox.Show("Ingrese valores de graduación correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Ingrese valores de graduación correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private List<decimal> VerificarDecimal()
        {
            if (txtMiop_OI.Text == string.Empty) txtMiop_OI.Text = 0.ToString();
            if (txtMiop_OD.Text == string.Empty) txtMiop_OD.Text = 0.ToString();
            if (txtAstig_OI.Text == string.Empty) txtAstig_OI.Text = 0.ToString();
            if (txtAstig_OD.Text == string.Empty) txtAstig_OD.Text = 0.ToString();

            if (txtMiop_OI.Text.Contains(".")) txtMiop_OI.Text= txtMiop_OI.Text.Replace(".", ",");
            if (txtMiop_OD.Text.Contains(".")) txtMiop_OD.Text = txtMiop_OD.Text.Replace(".", ",");
            if (txtAstig_OI.Text.Contains(".")) txtAstig_OI.Text = txtAstig_OI.Text.Replace(".", ",");
            if (txtAstig_OD.Text.Contains(".")) txtAstig_OD.Text = txtAstig_OD.Text.Replace(".", ",");

            if (decimal.TryParse(txtMiop_OI.Text, out decimal miopOI) && decimal.TryParse(txtMiop_OD.Text, out decimal miopOD) && decimal.TryParse(txtAstig_OI.Text, out decimal astigOI) && decimal.TryParse(txtAstig_OD.Text, out decimal astigOD))
            {
                List<decimal> listValores = new List<decimal>
                {
                    miopOI,
                    miopOD,
                    astigOI,
                    astigOD
                };

                return listValores;
            }

            else
            {
                List<decimal> listVacia = new List<decimal>();
                return listVacia;
            }
        }

        private bool VerificarValoresCorrectos(List<decimal> listValores)
        {
            bool correcto;

            if ((listValores[0] <= 20 && listValores[0] >= -20) && (listValores[1] <= 20 && listValores[1] >= -20) && (listValores[2] <= 20 && listValores[2] >= -20) && (listValores[3] <= 20 && listValores[3] >= -20))
            {
                correcto = true;
            }
            else correcto = false;

            return correcto;
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //Cargar label Nombre Paciente
        private void cboDni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var pacienteMetodo = new PacienteMetodos();
                var registro = pacienteMetodo.CargarLabelNomPac(Convert.ToInt32(cboDni.SelectedValue));
                if (registro.Read())
                {
                    lblNombrePaciente.Text = registro["Apellido"].ToString() + ", " + registro["Nombre"].ToString();
                }
            }
            catch
            {
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            cboMedico.Text = "SELECCIONE";
            cboDni.Text = "SELECCIONE";
            txtMiop_OI.Clear();
            txtMiop_OD.Clear();
            txtAstig_OI.Clear();
            txtAstig_OD.Clear();
            dtpFecha.Value = DateTime.Today;
            txtObserv.Clear();
            lblNombrePaciente.Text = "";
            cboMedico.Focus();
        }

        //Nuevo Médico
        private void lblMedicos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmMedicos();
            frm.ShowDialog();
            CargarMedicos();
            cboMedico.Text = "SELECCIONE";
        }

        private void CargarMedicos()
        {
            //Cargar Combo Medicos
            var dt = new DataTable();
            var med = new MedicoMetodos();
            dt = med.CargarComboMedicos();

            cboMedico.DataSource = dt;
            cboMedico.DisplayMember = "Apenom";
            cboMedico.ValueMember = "ID";
        }
    }
}