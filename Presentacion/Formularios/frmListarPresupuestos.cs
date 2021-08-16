using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace Presentacion
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
            ArmarGrilla();
        }

        //BOTON BUSCAR POR NRO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNro.Text != string.Empty)
            {
                try
                {
                    var ds = new DataSet();
                    var dt = new DataTable();
                    var al = new PresupuestoNegocio();
                    dt = al.BuscarPresupuesto(Convert.ToInt32(txtNro.Text));

                    if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Ingrese el número de presupuesto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Armar Grilla
        private void ArmarGrilla()
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new PresupuestoNegocio();
                dt = al.ConsultarPresupuestos();

                if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtNro.Clear();
            txtNro.Focus();
        }

        //LOAD
        private void frmListarPresupuestos_Load(object sender, EventArgs e)
        {
            //ArmarGrilla();
        }
    }
}