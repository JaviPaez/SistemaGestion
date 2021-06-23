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
    public partial class frmListarUsuarios : Form
    {
        public frmListarUsuarios()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmListarUsuarios_Load(object sender, EventArgs e)
        {
            //ArmarGrilla();
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
                    var usuarioMetodo = new UsuarioMetodos();

                    int dni;
                    if (!int.TryParse(txtBuscar.Text, out dni))
                        dt = usuarioMetodo.BuscarUsuarioApeNom(txtBuscar.Text);
                    else dt = usuarioMetodo.BuscarUsuarioDni(dni);

                    if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ingrese Dni o apellido y nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Ingrese Dni o apellido y nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Armar grilla
        private void ArmarGrilla()
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new UsuarioMetodos();
                dt = al.ConsultarUsuarios();

                if (dt.Rows.Count != 0)
                {
                    dgvGrilla.DataSource = dt;
                }
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscar.Clear();
            txtBuscar.Focus();
        }
    }
}