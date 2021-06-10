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
            var user = new UsuarioMetodos();
            dt = user.CargarComboUsuarios();

            cboUsuario.DataSource = dt;
            cboUsuario.DisplayMember = "ApeNom";
            cboUsuario.ValueMember = "Dni";

            //Cargar Combo Pacientes
            var dt2 = new DataTable();
            var pac = new PacienteMetodos();
            dt2 = pac.CargarComboPacientes();

            cboDniPaciente.DataSource = dt2;
            cboDniPaciente.DisplayMember = "Dni";
            cboDniPaciente.ValueMember = "Dni";

            //Cargar Combo Productos
            var dt3 = new DataTable();
            var prod = new ProductoMetodos();
            dt3 = prod.CargarComboProductos();

            cboProducto.DataSource = dt3;
            cboProducto.DisplayMember = "Descripcion";
            cboProducto.ValueMember = "ID";

            ReiniciarCampos();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var presupuesto = new Presupuesto();
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    presupuesto.DniUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                    presupuesto.DniPaciente = Convert.ToInt32(cboDniPaciente.SelectedValue);
                    presupuesto.IdReceta = Convert.ToInt32(cboIdReceta.SelectedValue);
                    presupuesto.Fecha = dtpFecha.Value;    

                    var presupuestoMetodo = new PresupuestoMetodos();
                    Boolean grabo = presupuestoMetodo.GrabarPresupuesto(presupuesto);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Grabación correcta", "Grabar",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
            catch (Exception ex)
            {
                MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReiniciarCampos();
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //Cargar datos a partir del DNI
        private void cboDniPaciente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Label Nombre
                var reg = new PacienteMetodos();
                var registro = reg.CargarLabelNomPac(Convert.ToInt32(cboDniPaciente.SelectedValue));
                if (registro.Read())
                {
                    lblNombrePaciente.Text = registro["Apellido"].ToString() + ", " + registro["Nombre"].ToString();
                }

                //Combo Receta
                var dt3 = new DataTable();
                var rec = new RecetaMetodos();
                dt3 = rec.CargarComboRecetas(Convert.ToInt32(cboDniPaciente.SelectedValue));

                cboIdReceta.DataSource = dt3;
                cboIdReceta.DisplayMember = "ID";
                cboIdReceta.ValueMember = "ID";

                cboIdReceta.Text = "Seleccione";
            }
            catch (Exception ex)
            {
            }
        }

        //Cargar datos de Receta
        private void cboIdReceta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var recetaMetodo = new RecetaMetodos();
                var registro = recetaMetodo.CargarLabelReceta(Convert.ToInt32(cboIdReceta.SelectedValue));

                if (registro.Read())
                {
                    lblFecha.Text = registro["FechaOK"].ToString();
                    lblMiopOI.Text = registro["Miop_OI"].ToString();
                    lblMiopOD.Text = registro["Miop_OD"].ToString();
                    lblAstigOI.Text = registro["Astig_OI"].ToString();
                    lblAstigOD.Text = registro["Astig_OD"].ToString();
                    lblObservaciones.Text = registro["Observaciones"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            cboDniPaciente.Text = "Seleccione";
            cboUsuario.Text = "Seleccione";
            cboIdReceta.Text = "Seleccione";
            dtpFecha.Value = DateTime.Today;
            cboProducto.Text = "Seleccione";
            cboDniPaciente.Focus();

            lblNombrePaciente.Text = "";
            lblFecha.Text = "";
            lblMiopOI.Text = "";
            lblMiopOD.Text = "";
            lblAstigOI.Text = "";
            lblAstigOD.Text = "";
            lblObservaciones.Text = "";
        }
    }
}