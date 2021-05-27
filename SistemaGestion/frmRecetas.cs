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
            dt = pac.cargarComboPacientes();

            cboDni.DataSource = dt;
            cboDni.DisplayMember = "Dni";
            cboDni.ValueMember = "Dni";

            cboDni.Text = "";
            cboMedico.Text = "";           
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
                    //receta.OD = Convert.ToDouble(txtOD.Text);
                    //receta.OI = Convert.ToDouble(txtOI.Text);
                    receta.OI = txtOI.Text;
                    receta.OD = txtOD.Text;
                    receta.Fecha = dtpFecha.Value;
                    receta.Observaciones = txtObserv.Text;                    

                    var recetaMetodo = new RecetaMetodos();
                    Boolean grabo = recetaMetodo.grabarReceta(receta);
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
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboDni.Text = "";
            cboMedico.Text = "";
            txtOD.Text = "";
            txtOI.Text = "";
            dtpFecha.Value = DateTime.Today;
            txtObserv.Text = "";
        }       
    }
}