using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class frmRptPrecioHistorico : Form
    {
        public frmRptPrecioHistorico()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRptPrecioHistorico_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Format = DateTimePickerFormat.Short;

            //Cargar Combo Categorias
            var dt = new DataTable();
            var cat = new CategoriaNegocio();
            dt = cat.CargarComboCategorias();

            cboCategoria.DataSource = dt;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "ID";

            ReiniciarCampos();
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        //BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            cboCategoria.Text = "SELECCIONE";
            cboSubCategoria.Text = "SELECCIONE";
            cboCategoria.Focus();
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
        }

        private void cboCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dt2 = new DataTable();
            var subcat = new CategoriaNegocio();
            int idCat;
            idCat = Convert.ToInt32(cboCategoria.SelectedValue);
            dt2 = subcat.CargarComboSubCategorias(idCat);

            cboSubCategoria.DataSource = dt2;
            cboSubCategoria.DisplayMember = "Descripcion";
            cboSubCategoria.ValueMember = "ID";
        }

        //BOTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int Idprod = 0;

            if (dgvProd.RowCount != 0)
            {
                Idprod = Convert.ToInt32(dgvProd.CurrentRow.Cells["ID"].Value);
            }

            PrecioHistorico prod = new PrecioHistorico();
            prod.FechaInicio = dtpFechaDesde.Value;
            prod.FechaFin = dtpFechaHasta.Value;
            prod.Idprod = Idprod;

            var met = new ProductoNegocio();
            var dt = met.GraficarPreciosHistoricos(prod);

            var reportPath = "Presentacion.Reportes.GraficoPreciosHistoricos.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSPrecioHistorico";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }

        //Buscar por descripc
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
                    dgvProd.Columns["categoria"].Visible = false;
                    dgvProd.Columns["subcategoria"].Visible = false;
                    dgvProd.Columns["costo"].Visible = false;
                    dgvProd.Columns["precio"].Visible = false;
                    dgvProd.Columns["stock"].Visible = false;
                }
            }
        }

        //Listar todos los productos
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
                    dgvProd.Columns["precio"].Visible = false;
                    dgvProd.Columns["stock"].Visible = false;
                }
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscarDescr.Clear();
        }

        //Buscar productos por subcategoria
        private void cboSubCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable();
                var al = new ProductoNegocio();
                dt = al.BuscarProductoxSubcategoria(Convert.ToInt32(cboSubCategoria.SelectedValue));
                if (dt.Rows.Count != 0)
                {
                    dgvProd.DataSource = dt;
                    dgvProd.Columns["ID"].Visible = false; 
                }
                else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscarDescr.Clear();
        }
    }
}