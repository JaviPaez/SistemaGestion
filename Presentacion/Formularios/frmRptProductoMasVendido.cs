using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class frmRptProductoMasVendido : Form
    {
        public frmRptProductoMasVendido()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRptProductoMasVendido_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Format = DateTimePickerFormat.Short;

            ReiniciarCampos();
        }

        //BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //Reiniciar campos
        private void ReiniciarCampos()
        {          
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today; 
            dtpFechaDesde.Focus();
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            ReporteProductoMasVendido prod = new ReporteProductoMasVendido();
            prod.FechaDesde = dtpFechaDesde.Value;
            prod.FechaHasta = dtpFechaHasta.Value;

            var met = new ProductoNegocio();
            var dt = met.ReporteProductoMasVendido(prod);

            var reportPath = "Presentacion.Reportes.ProductoMasVendido.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSProductoMasVendido";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }
    }
}