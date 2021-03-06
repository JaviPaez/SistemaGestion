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
            //Cargar Combo Categorias
            var dt = new DataTable();
            var cat = new CategoriaNegocio();
            dt = cat.CargarComboCategorias();

            cboCategoria.DataSource = dt;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "ID";

            //Cargar Combo Marcas
            var dt3 = new DataTable();
            var marca = new MarcaNegocio();
            dt3 = marca.CargarComboMarcas();

            cboMarca.DataSource = dt3;
            cboMarca.DisplayMember = "Nombre";
            cboMarca.ValueMember = "ID";

            ReiniciarCampos();
            btnBuscar.Visible = false;
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
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    producto.IdSubcategoria = Convert.ToInt32(cboSubCategoria.SelectedValue);
                    producto.IdMarca = Convert.ToInt32(cboMarca.SelectedValue);
                    producto.Costo = Convert.ToDecimal(txtCosto.Text);

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
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    producto.IdSubcategoria = Convert.ToInt32(cboSubCategoria.SelectedValue);
                    producto.IdMarca = Convert.ToInt32(cboMarca.SelectedValue);
                    producto.Id = Convert.ToInt32(dgvGrilla.CurrentRow.Cells[0].Value);
                    producto.Costo = Convert.ToDecimal(txtCosto.Text);

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
            this.Controls.Clear();
            InitializeComponent();
            frmProductos_Load(e, e);
        }

        //BUSCAR POR DESCRIPCION
        private void txtBuscarDescr_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarDescr.Text != string.Empty)
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var productoMetodo = new ProductoNegocio();

                dt = productoMetodo.BuscarProductoDescripcion(txtBuscarDescr.Text);

                if (dt.Rows.Count != 0)
                {
                    dgvGrilla.DataSource = dt;
                    dgvGrilla.Columns["ID"].Visible = false;
                    dgvGrilla.Columns["idcategoria"].Visible = false;
                    dgvGrilla.Columns["idsubcategoria"].Visible = false;
                    dgvGrilla.Columns["idmarca"].Visible = false;
                }
            }
        }

        //BOTON BUSCAR POR DESCRIPCION
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarDescr.Text != string.Empty)
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var productoMetodo = new ProductoNegocio();

                dt = productoMetodo.BuscarProductoDescripcion(txtBuscarDescr.Text);

                if (dt.Rows.Count != 0)
                {
                    dgvGrilla.DataSource = dt;
                    dgvGrilla.Columns["ID"].Visible = false;
                    dgvGrilla.Columns["idcategoria"].Visible = false;
                    dgvGrilla.Columns["idsubcategoria"].Visible = false;
                    dgvGrilla.Columns["idmarca"].Visible = false;
                }
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                txtDescripcion.Text = dgvGrilla.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtCantidad.Text = dgvGrilla.CurrentRow.Cells["Cantidad"].Value.ToString();
                txtCosto.Text = dgvGrilla.CurrentRow.Cells["Costo"].Value.ToString();

                cboCategoria.SelectedValue = dgvGrilla.CurrentRow.Cells["idcategoria"].Value;
                cboCategoria.Text = dgvGrilla.CurrentRow.Cells["Categoria"].Value.ToString();

                ComboSubCat();

                cboSubCategoria.SelectedValue = dgvGrilla.CurrentRow.Cells["idsubcategoria"].Value;
                cboSubCategoria.Text = dgvGrilla.CurrentRow.Cells["Subcategoria"].Value.ToString();

                cboMarca.SelectedValue = dgvGrilla.CurrentRow.Cells["idmarca"].Value;
                cboMarca.Text = dgvGrilla.CurrentRow.Cells["Marca"].Value.ToString();
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
                    dgvGrilla.Columns["idcategoria"].Visible = false;
                    dgvGrilla.Columns["idsubcategoria"].Visible = false;
                    dgvGrilla.Columns["idmarca"].Visible = false;
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

                if (dt.Rows.Count != 0)
                {
                    dgvGrilla.DataSource = dt;
                    dgvGrilla.Columns["ID"].Visible = false;
                    dgvGrilla.Columns["idcategoria"].Visible = false;
                    dgvGrilla.Columns["idsubcategoria"].Visible = false;
                    dgvGrilla.Columns["idmarca"].Visible = false;
                }

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

                if (dt.Rows.Count != 0)
                {
                    dgvGrilla.DataSource = dt;
                    dgvGrilla.Columns["ID"].Visible = false;
                    dgvGrilla.Columns["idcategoria"].Visible = false;
                    dgvGrilla.Columns["idsubcategoria"].Visible = false;
                    dgvGrilla.Columns["idmarca"].Visible = false;
                }
            }
            catch
            {
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            txtCantidad.Value = 0;
            txtCosto.Clear();
            txtDescripcion.Clear();

            cboSubCategoria.SelectedValue = 0;
            cboCategoria.SelectedValue = 0;
            cboMarca.SelectedValue = 0;

            cboMarca.Text = "SELECCIONE";
            cboSubCategoria.Text = "SELECCIONE";
            cboCategoria.Text = "SELECCIONE";

            txtDescripcion.Focus();
        }

        //Combo subcategorias
        private void cboCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboSubCat();
        }

        private void ComboSubCat()
        {
            //Cargar Combo Subcategorias
            var dt2 = new DataTable();
            var subcat = new CategoriaNegocio();
            int idCat;
            idCat = Convert.ToInt32(cboCategoria.SelectedValue);
            dt2 = subcat.CargarComboSubCategorias(idCat);

            cboSubCategoria.DataSource = dt2;
            cboSubCategoria.DisplayMember = "Descripcion";
            cboSubCategoria.ValueMember = "ID";
        }

        //ACTUALIZAR PRECIOS
        private void lblNvoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmActualizarPrecio();
            frm.Show();
        }
    }
}