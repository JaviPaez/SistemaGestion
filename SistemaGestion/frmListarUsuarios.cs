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

        private void frmListarUsuarios_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            var al = new LoginMetodos();
        }

        private void btnGrilla_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new LoginMetodos();
            dt = al.Consultar();
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
