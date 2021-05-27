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
    public partial class frmListarMedicos : Form
    {
        public frmListarMedicos()
        {
            InitializeComponent();
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
                dgvLista.DataSource = dt; //ds.Tables[0];

            }
            else
            {
                MessageBox.Show("No hay registros en la seleccion");
            }
        }
    }
}
