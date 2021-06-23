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
    public partial class frmPresupuestos : Form
    {
        public frmPresupuestos()
        {
            InitializeComponent();
        }        
        //LOAD
        private void frmPresupuestos_Load(object sender, EventArgs e)
        {
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.MaxDate = DateTime.Today;
            

            //Cargar Combo Usuarios
            var dt = new DataTable();
            var user = new UsuarioMetodos();
            dt = user.CargarComboUsuarios();

            cboUsuario.DataSource = dt;
            cboUsuario.DisplayMember = "ApeNom";
            cboUsuario.ValueMember = "Dni";

            //Cargar Combo Pacientes
            var dt2 = new DataTable();
            var pac = new PacienteMetodos();
            dt2 = pac.CargarComboPacientes();

            cboDniPaciente.DataSource = dt2;
            cboDniPaciente.DisplayMember = "Dni";
            cboDniPaciente.ValueMember = "Dni";

            //Cargar Combo Productos
            var dt3 = new DataTable();
            var prod = new ProductoMetodos();
            dt3 = prod.CargarComboProductos();

            cboProducto.DataSource = dt3;
            cboProducto.DisplayMember = "Descripcion";
            cboProducto.ValueMember = "ID";

            dgvGrilla.Columns[0].Visible = false;

            ReiniciarCampos();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var presupuesto = new Presupuesto();
            var i = false;

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    presupuesto.DniUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                    presupuesto.DniPaciente = Convert.ToInt32(cboDniPaciente.SelectedValue);
                    presupuesto.IdReceta = Convert.ToInt32(cboIdReceta.SelectedValue);
                    presupuesto.Fecha = dtpFecha.Value;

                    var presupuestoMetodo = new PresupuestoMetodos();
                    var maxId = presupuestoMetodo.GrabarPresupuesto(presupuesto);

                    if (maxId != 0)
                    {
                        var detallePresupuesto = new DetallePresupuesto();
                        var detallePresupuestoMetodo = new DetallePresupuestoMetodos();

                        //Recorro la grilla - Grabo DetallePresupuesto
                        foreach (DataGridViewRow fila in dgvGrilla.Rows)
                        {
                            detallePresupuesto.IdProducto = Convert.ToInt32(fila.Cells[0].Value);
                            detallePresupuesto.NroPresupuesto = maxId;
                            detallePresupuesto.Cantidad = Convert.ToInt32(fila.Cells[2].Value);
                            detallePresupuesto.PrecioUnitario = Convert.ToDecimal(fila.Cells[3].Value);
                            if (detallePresupuesto.Cantidad != 0)
                            {
                                i = detallePresupuestoMetodo.GrabarDetallePresupuesto(detallePresupuesto);
                            }
                        }

                        if (i == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        else MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //ReiniciarCampos();
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
                var reg = new PacienteMetodos();
                var registro = reg.CargarLabelNomPac(Convert.ToInt32(cboDniPaciente.SelectedValue));
                if (registro.Read())
                {
                    var apellido = registro["Apellido"].ToString();
                    var nombre = registro["Nombre"].ToString();

                    lblNombrePaciente.Text = apellido + ", " + nombre;
                }

                //Combo Receta
                var dt3 = new DataTable();
                var rec = new RecetaMetodos();
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
            try
            {
                var recetaMetodo = new RecetaMetodos();
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
            catch
            {
            }
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            cboDniPaciente.Text = "SELECCIONE";
            cboUsuario.Text = "SELECCIONE";
            cboIdReceta.Text = "SELECCIONE";
            dtpFecha.Value = DateTime.Today;
            cboProducto.Text = "SELECCIONE";
            cboDniPaciente.Focus();
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

                var idProducto = Convert.ToInt32(cboProducto.SelectedValue.ToString());

                dgvGrilla.Rows.Add(idProducto, cboProducto.Text, txtCantidad.Text, txtPrecio.Text, subtotal);

                cboProducto.Text = "SELECCIONE";
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

        //Seleccion del Combo Producto
        private void cboProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idProducto = Convert.ToInt32(cboProducto.SelectedValue);

            var productoMetodo = new ProductoMetodos();

            var dr = productoMetodo.BuscarIdProducto(idProducto);

            if (dr["Descripcion"] != null)
            {
                txtPrecio.Text = Convert.ToString(dr["Precio"]);
                txtCantidad.Text = "1";
            }
        }

        //BOTON GENERAR PRESUPUESTO
        private void btnReportPresup_Click(object sender, EventArgs e)
        {
            var frm = new frmReportPresup();         

            for (int i = 0; i < dgvGrilla.Rows.Count; i++)
            {
                var variables = new DatosPresup();

                variables.Nombre = lblNombrePaciente.Text;
                if(cboDniPaciente.Text =="SELECCIONE" || cboDniPaciente.SelectedValue == null)
                {
                    variables.Dni = 0;
                }
                else variables.Dni = Convert.ToInt32(cboDniPaciente.Text);

                variables.Fecha = dtpFecha.Value;
                variables.Descripcion = dgvGrilla.Rows[i].Cells[1].Value.ToString();
                variables.Cantidad = Convert.ToInt32(dgvGrilla.Rows[i].Cells[2].Value);
                variables.PrecioUnitario = Convert.ToDecimal(dgvGrilla.Rows[i].Cells[3].Value);
                variables.Subtotal = Convert.ToDecimal(dgvGrilla.Rows[i].Cells[4].Value);              

                frm.Datos.Add(variables);
            }            

            frm.ShowDialog();
        }

        //Variables
        decimal total = 0;
    }
}