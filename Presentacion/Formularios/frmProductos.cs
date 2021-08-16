using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Presentacion
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmProductos_Load(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var producto = new Producto();
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    producto.Descripcion = txtDescripcion.Text;
                    if (txtPrecio.Text.Contains(".")) txtPrecio.Text = txtPrecio.Text.Replace(".", ",");
                    producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

                    var productoMetodo = new ProductoNegocio();
                    Boolean grabo = productoMetodo.GrabarProducto(producto);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information); MostrarProductoActual();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la modificación?", "Modificar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            var producto = new Producto();
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    producto.Descripcion = txtDescripcion.Text;
                    if (txtPrecio.Text.Contains(".")) txtPrecio.Text = txtPrecio.Text.Replace(".", ",");
                    producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    producto.Id = Convert.ToInt32(dgvGrilla.CurrentRow.Cells[0].Value);

                    var productoMetodo = new ProductoNegocio();
                    Boolean modifico = productoMetodo.ModificarProducto(producto);

                    if (modifico == false) MessageBox.Show("Error en modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Modificación correcta", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProductoModificado(Convert.ToInt64(dgvGrilla.CurrentRow.Cells["ID"].Value));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //BOTON BUSCAR POR DESCRIPCION
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarDescr.Text != string.Empty)
            {
                try
                {
                    var ds = new DataSet();
                    var dt = new DataTable();
                    var productoMetodo = new ProductoNegocio();

                    dt = productoMetodo.BuscarProductoDescripcion(txtBuscarDescr.Text);

                    if (dt.Rows.Count != 0)
                    {
                        dgvGrilla.DataSource = dt;
                        dgvGrilla.Columns["ID"].Visible = false;
                    }
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //BOTON ARMAR LISTA
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        //CLICK EN CONTENIDO DE CELDA DGV
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDescripcion.Text = dgvGrilla.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dgvGrilla.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = dgvGrilla.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
            }
        }

        //Armar grilla
        private void ArmarGrilla()
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new ProductoNegocio();
                dt = al.ConsultarProductos();
                if (dt.Rows.Count != 0)
                {
                    dgvGrilla.DataSource = dt;
                    dgvGrilla.Columns["ID"].Visible = false;
                }
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscarDescr.Clear();
        }

        private void MostrarProductoActual()
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new ProductoNegocio();

                var id = al.UltimoId() - 1;

                dt = al.BuscarProductoId(id);

                if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
            }
            catch
            {
            }
        }

        private void MostrarProductoModificado(Int64 id)
        {
            try
            {

                var ds = new DataSet();
                var dt = new DataTable();
                var al = new ProductoNegocio();

                dt = al.BuscarProductoId(id);

                if (dt.Rows.Count != 0) dgvGrilla.DataSource = dt;
            }
            catch
            {
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            txtCantidad.Value = 0;
            txtPrecio.Clear();
            txtDescripcion.Clear();
            txtDescripcion.Focus();
        }
    }
}