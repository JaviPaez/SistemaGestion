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
            var dt = new DataTable();
            var al = new LoginMetodos();
            txtBuscar.Focus();
        }

        //BOTON ARMAR LISTA
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new LoginMetodos();
            dt = al.Consultar();

            if (dt.Rows.Count != 0)
            {
                dgvLista.DataSource = dt;
                dgvLista.Columns["Contraseña"].Visible = false;
            }
            else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtBuscar.Clear();
        }

        //BOTON BUSCAR POR DNI O APELLIDO Y NOMBRE
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text != string.Empty)
            {
                try
                {
                    var ds = new DataSet();
                    var dt = new DataTable();
                    var al = new LoginMetodos();                

                    int dni;
                    if (!int.TryParse(txtBuscar.Text, out dni))
                        dt = al.buscarUsuarioApeNom(txtBuscar.Text);
                    else dt = al.buscarUsuarioDni(dni);                  

                    if (dt.Rows.Count != 0) dgvLista.DataSource = dt;
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("Ingrese Dni o apellido y nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Ingrese Dni o apellido y nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}