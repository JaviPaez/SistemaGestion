using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class frmRptListaCompVta : Form
    {
        public frmRptListaCompVta()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRptListaCompVta_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Format = DateTimePickerFormat.Short;

            //Cargar Combo Categorias
            var dt = new DataTable();
            var cat = new UsuarioNegocio();
            dt = cat.CargarComboUsuarios();

            cboUsuario.DataSource = dt;
            cboUsuario.DisplayMember = "Apenom";
            cboUsuario.ValueMember = "Dni";

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
            cboUsuario.Text = "SELECCIONE";
            cboUsuario.Focus();
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            ReporteListaVentas venta = new ReporteListaVentas();
            venta.FechaDesde = dtpFechaDesde.Value;
            venta.FechaHasta = dtpFechaHasta.Value;
            venta.DniUsuario = Convert.ToInt32(cboUsuario.SelectedValue);

            var met = new VentaNegocio();
            var dt = met.ReporteListaVentas(venta);

            var reportPath = "Presentacion.Reportes.ListaCompVta.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSListaCompVta";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }
    }
}