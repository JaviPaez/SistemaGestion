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
        private void btnGrilla_Click_1(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new PacienteMetodos();
            dt = al.ConsultarPacientes();
            if (dt.Rows.Count != 0)
            {
                dgvLista.DataSource = dt; //ds.Tables[0];

            }
            else
            {
                MessageBox.Show("No hay registros en la seleccion");
            }
        }
    }
}
