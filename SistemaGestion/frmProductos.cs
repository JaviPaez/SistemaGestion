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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }
    }
}