using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaGestion
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

            //Cargar Combo Medicos
            var dt = new DataTable();
            var med = new MedicoMetodos();
            dt = med.cargarComboMedicos();

            cboMedico.DataSource = dt;
            cboMedico.DisplayMember = "Apenom";
            cboMedico.ValueMember = "ID";  

            //Cargar Combo Pacientes
            var dt2 = new DataTable();
            var pac = new PacienteMetodos();
            dt2 = pac.cargarComboPacientes();

            cboDni.DataSource = dt2;
            cboDni.DisplayMember = "Dni";
            cboDni.ValueMember = "Dni";


            lblNombrePaciente.Text = "";
            cboDni.Text = "Seleccione";
            cboMedico.Text = "Seleccione";
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var receta = new Receta();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    receta.IdMedico = Convert.ToInt32(cboMedico.SelectedValue);
                    receta.Dni = Convert.ToInt32(cboDni.SelectedValue);
                    receta.Miop_OI = txtMiop_OI.Text;
                    receta.Miop_OD = txtMiop_OD.Text;
                    receta.Astig_OI = txtAstig_OI.Text;
                    receta.Astig_OD = txtAstig_OD.Text;
                    receta.Fecha = dtpFecha.Value;
                    receta.Observaciones = txtObserv.Text;                    

                    var recetaMetodo = new RecetaMetodos();
                    Boolean grabo = recetaMetodo.grabarReceta(receta);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else MessageBox.Show("Grabación correcta", "Grabar",MessageBoxButtons.OK,MessageBoxIcon.Information);                  
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
            cboDni.Text = "Seleccione";
            cboMedico.Text = "Seleccione"; 
            txtMiop_OI.Clear();
            txtMiop_OD.Clear();
            txtAstig_OI.Clear();
            txtAstig_OD.Clear();
            dtpFecha.Value = DateTime.Today;
            txtObserv.Clear();
            lblNombrePaciente.Text = "";
        }

        private void cboDni_SelectedValueChanged(object sender, EventArgs e)
        {
            //Cargar label Nombre Paciente
            try
            {
                var reg = new PacienteMetodos();
                var registro = reg.cargarLabelNomPac(Convert.ToInt32(cboDni.SelectedValue));
                if (registro.Read())
                {
                    lblNombrePaciente.Text = registro["Apellido"].ToString() + ", " + registro["Nombre"].ToString();
                }                
            }
            catch(Exception ex)
            {                
            }
        }
    }
}