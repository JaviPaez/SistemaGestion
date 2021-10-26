using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class frmRptListaProductos : Form
    {
        public frmRptListaProductos()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRptListaProductos_Load(object sender, EventArgs e)
        {
            var met = new ProductoNegocio();
            var dt = met.ListarProductos();

            var reportPath = "Presentacion.Reportes.ProductoLista.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSProductos";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }
    }
}