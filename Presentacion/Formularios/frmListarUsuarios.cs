using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
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
                    var usuarioNegocio = new UsuarioNegocio();

                    int dni;
                    if (!int.TryParse(txtBuscar.Text, out dni))
                        dt = usuarioNegocio.BuscarUsuarioApeNom(txtBuscar.Text);
                    else dt = usuarioNegocio.BuscarUsuarioDni(dni);

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
                var al = new UsuarioNegocio();
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