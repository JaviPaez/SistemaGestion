using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Presentacion
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
        }
        //LOAD
        private void frmVenta_Load(object sender, EventArgs e)
        {
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.MaxDate = DateTime.Today;

            //Cargar Combo Usuarios
            //var dt = new DataTable();
            //var user = new UsuarioNegocio();
            //dt = user.CargarComboUsuarios();

            //cboUsuario.DataSource = dt;
            //cboUsuario.DisplayMember = "ApeNom";
            //cboUsuario.ValueMember = "Dni";

            //Cargar Combo Pacientes
            var dt2 = new DataTable();
            var pac = new PacienteNegocio();
            dt2 = pac.CargarComboPacientes();

            cboDniPaciente.DataSource = dt2;
            cboDniPaciente.DisplayMember = "Dni";
            cboDniPaciente.ValueMember = "Dni";

            dgvGrilla.Columns[0].Visible = false;

            ReiniciarCampos();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var venta = new Venta();
            var i = false;

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    //presupuesto.DniUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                    venta.DniUsuario = frmLogin.DniUsuario;
                    venta.DniPaciente = Convert.ToInt32(cboDniPaciente.SelectedValue);
                    venta.IdReceta = Convert.ToInt32(cboIdReceta.SelectedValue);
                    venta.Fecha = dtpFecha.Value;

                    var ventaNegocio = new VentaNegocio();
                    var maxId = ventaNegocio.GrabarVenta(venta);

                    if (maxId != 0)
                    {
                        var detalleVenta = new DetalleVenta();
                        var detalleVentaMetodo = new VentaNegocio();

                        //Recorro la grilla - Grabo DetallePresupuesto
                        foreach (DataGridViewRow fila in dgvGrilla.Rows)
                        {
                            detalleVenta.IdProducto = Convert.ToInt32(fila.Cells[0].Value);
                            detalleVenta.NroPresupuesto = maxId;
                            detalleVenta.Cantidad = Convert.ToInt32(fila.Cells[2].Value);
                            detalleVenta.PrecioUnitario = Convert.ToDecimal(fila.Cells[3].Value);
                            if (detalleVenta.Cantidad != 0)
                            {
                                i = detalleVentaMetodo.GrabarDetalleVenta(detalleVenta);
                            }
                        }

                        if (i == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        else
                        {
                            MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmRptCompVenta report = new frmRptCompVenta();
                            report.ShowDialog();
                        }
                    }

                    else MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //Cargar datos a partir del DNI
        private void cboDniPaciente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Label Nombre
                var reg = new PacienteNegocio();
                var registro = reg.CargarLabelNomPac(Convert.ToInt32(cboDniPaciente.SelectedValue));
                if (registro.Read())
                {
                    var apellido = registro["Apellido"].ToString();
                    var nombre = registro["Nombre"].ToString();

                    lblNombrePaciente.Text = apellido + ", " + nombre;
                }

                //Combo Receta
                var dt3 = new DataTable();
                var rec = new RecetaNegocio();
                dt3 = rec.CargarComboRecetas(Convert.ToInt32(cboDniPaciente.SelectedValue));

                cboIdReceta.DataSource = dt3;
                cboIdReceta.DisplayMember = "Fecha";
                cboIdReceta.ValueMember = "ID";

                cboIdReceta.Text = "SELECCIONE";
            }
            catch
            {
            }
        }

        //Cargar datos de Receta
        private void cboIdReceta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var recetaMetodo = new RecetaNegocio();
            var registro = recetaMetodo.CargarLabelReceta(Convert.ToInt32(cboIdReceta.SelectedValue));

            if (registro.Read())
            {
                lblMiopOI.Text = registro["Miop_OI"].ToString();
                lblMiopOD.Text = registro["Miop_OD"].ToString();
                lblAstigOI.Text = registro["Astig_OI"].ToString();
                lblAstigOD.Text = registro["Astig_OD"].ToString();
                lblObservaciones.Text = registro["Observaciones"].ToString();
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            cboDniPaciente.Text = "SELECCIONE";
            //cboUsuario.Text = "SELECCIONE";
            cboIdReceta.Text = "SELECCIONE";
            dtpFecha.Value = DateTime.Today;
            //cboProducto.Text = "SELECCIONE";
            cboDniPaciente.Focus();
            txtBuscarDescr.Clear();
            txtPrecio.Clear();
            txtCantidad.Value = 0;

            lblNombrePaciente.Text = "";
            lblMiopOI.Text = "";
            lblMiopOD.Text = "";
            lblAstigOI.Text = "";
            lblAstigOD.Text = "";
            lblObservaciones.Text = "";
            lblTotal.Text = "";
            lblTotals.Text = "";
            total = 0;

            dgvGrilla.Rows.Clear();
            dgvProd.Rows.Clear();
        }

        //BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecio.Text.Contains(".")) txtPrecio.Text = txtPrecio.Text.Replace(".", ",");
                var precio = Convert.ToDecimal(txtPrecio.Text);
                var cantidad = Convert.ToInt32(txtCantidad.Text);
                var subtotal = precio * cantidad;
                total += subtotal;

                var idProducto = Convert.ToInt32((dgvProd.CurrentRow.Cells["ID"].Value));
                string descripc = dgvProd.CurrentRow.Cells["Descripcion"].Value.ToString();

                dgvGrilla.Rows.Add(idProducto, descripc, txtCantidad.Text, txtPrecio.Text, subtotal);

                txtPrecio.Clear();
                txtCantidad.Value = 0;
                lblTotals.Text = "Total: $";
                lblTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar un producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BOTON QUITAR
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentRow == null) return;

            DialogResult respuesta = MessageBox.Show("¿Confirma eliminar el producto seleccionado?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                total -= Convert.ToDecimal(dgvGrilla.CurrentRow.Cells["Subtotal"].Value);
                lblTotal.Text = total.ToString();
                dgvGrilla.Rows.Remove(dgvGrilla.CurrentRow);
                if (dgvGrilla.Rows.Count < 1)
                {
                    lblTotal.Text = "";
                    lblTotals.Text = "";
                }
            }
        }

        //Variables
        decimal total = 0;

        //LISTAR PRODUCTOS
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new ProductoNegocio();
                dt = al.ListarProductos();
                if (dt.Rows.Count != 0)
                {
                    dgvProd.DataSource = dt;
                    dgvProd.Columns["ID"].Visible = false;
                    dgvProd.Columns["categoria"].Visible = false;
                    dgvProd.Columns["subcategoria"].Visible = false;
                    dgvProd.Columns["costo"].Visible = false;
                }
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscarDescr.Clear();
        }

        //Click para cargar producto a la venta
        private void dgvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPrecio.Text = dgvProd.CurrentRow.Cells["Precio"].Value.ToString();
            var stock = Convert.ToInt32(dgvProd.CurrentRow.Cells["Stock"].Value);

            if (stock > 0)
            {
                txtCantidad.Maximum = stock;
                txtCantidad.Text = "1";                
            }          
        }

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
                    dgvProd.DataSource = dt;
                    dgvProd.Columns["ID"].Visible = false;
                    dgvProd.Columns["idcategoria"].Visible = false;
                    dgvProd.Columns["idsubcategoria"].Visible = false;
                    dgvProd.Columns["idmarca"].Visible = false;
                }
            }
        }
    }
}