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
            btnNuevo_Click(sender, e);
            btnGrilla_Click(sender, e);
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
                    
                    if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    else MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
            catch (Exception ex)
            {
                MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            btnGrilla_Click(sender, e);
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la modificación?", "Modificar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            var medico = new Medico();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    medico.Matricula = txtMatricula.Text;
                    medico.Apellido = txtApellido.Text;
                    medico.Nombre = txtNombre.Text;
                    medico.Id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value);

                    var medicoMetodo = new MedicoMetodos();
                    Boolean modifico = medicoMetodo.modificarMedico(medico);

                    if (modifico == false) MessageBox.Show("Error en modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Modificación correcta", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnGrilla_Click(sender, e);
        }

        //BOTON NUEVO      
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtMatricula.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtMatricula.Focus();
        }

        //CLICK EN CONTENIDO DE CELDA DGV
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {               
                txtApellido.Text = dgvLista.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvLista.CurrentRow.Cells[2].Value.ToString(); 
                txtMatricula.Text = dgvLista.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        //BOTON ARMAR LISTA
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new MedicoMetodos();
            dt = al.consultarMedicos();

            if (dt.Rows.Count != 0)
            {
                dgvLista.DataSource = dt;
                dgvLista.Columns["ID"].Visible = false;
            }
            else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
