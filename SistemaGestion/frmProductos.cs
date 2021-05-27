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
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var producto = new Producto();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    producto.Descripcion = txtDescripcion.Text;
                    producto.Precio = txtPrecio.Text;
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

                    var productoMetodo = new ProductoMetodos();
                    Boolean grabo = productoMetodo.grabarProducto(producto);
                    if (grabo == false)
                    {
                        MessageBox.Show("Error en Grabacion", "ERROR");
                    }
                    else
                    {
                        MessageBox.Show("Grabacion Correcta", "Grabar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnCancelar_Click(sender, e);
        }
    }
}