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
    public partial class frmListarPacientes : Form
    {
        public frmListarPacientes()
        {
            InitializeComponent();
        }

        //BOTON ARMAR LISTA 
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new PacienteMetodos();
            dt = al.consultarPacientes();

            if (dt.Rows.Count != 0) dgvLista.DataSource = dt;          
            else MessageBox.Show("No hay registros en la seleccion");    

            txtBuscar.Clear();
        }

        //BOTON BUSCAR POR DNI O APELLIDO Y NOMBRE
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new PacienteMetodos();

                int dni;
                if (!int.TryParse(txtBuscar.Text, out dni))
                {
                    dt = al.buscarPacienteApeNom(txtBuscar.Text);
                }
                else dt = al.buscarPacienteDni(dni);

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
                MessageBox.Show("Ingrese Dni o Apellido y Nombre");
            }
        }
    }
}
