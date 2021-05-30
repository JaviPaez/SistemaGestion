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
    public partial class frmListarPresupuestos : Form
    {
        public frmListarPresupuestos()
        {
            InitializeComponent();
        }

        //BOTON ARMAR LISTA 
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new PresupuestoMetodos();
            dt = al.consultar();
            if (dt.Rows.Count != 0)
            {
                dgvLista.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No hay registros en la seleccion");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new PresupuestoMetodos();
                dt = al.buscarPresupuesto(Convert.ToInt32(txtNro.Text));
                if (dt.Rows.Count != 0)
                {
                    dgvLista.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No hay registros en la seleccion");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ingrese el Nro de Presupuesto");
            }
        }
    }
}