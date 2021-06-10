﻿using System;
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
            ReiniciarCampos();
            ArmarGrilla();
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
                    Boolean grabo = medicoMetodo.GrabarMedico(medico);
                    
                    if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    else MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
            catch (Exception ex)
            {
                MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            ArmarGrilla();
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
                    int id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value);

                    medico.Id = id;
                    medico.Matricula = txtMatricula.Text;
                    medico.Apellido = txtApellido.Text;
                    medico.Nombre = txtNombre.Text;                    

                    var medicoMetodo = new MedicoMetodos();
                    Boolean modifico = medicoMetodo.ModificarMedico(medico);

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
            ArmarGrilla();
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            txtMatricula.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtMatricula.Focus();
        }

        //Armar grilla
        private void ArmarGrilla()
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new MedicoMetodos();
            dt = al.ConsultarMedicos();

            if (dt.Rows.Count != 0)
            {
                dgvLista.DataSource = dt;
                dgvLista.Columns["ID"].Visible = false;
            }
            else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
