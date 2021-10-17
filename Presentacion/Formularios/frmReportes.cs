using System;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using CapaNegocio;

namespace Presentacion
{
    public partial class frmReportes : Form
    {        
        public frmReportes()
        {
            InitializeComponent();
        }

        //Presupuestos
        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            var met = new PresupuestoNegocio();
            var dt = met.ConsultarPresupuestoReporte();

            var reportPath = "Presentacion.Reportes.Presupuesto.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSPresupuesto";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }

        private void btnListaUsuarios_Click(object sender, EventArgs e)
        {
            var met = new UsuarioListaNegocio();
            var dt = met.ReporteListaUsuarios();

            var reportPath = "Presentacion.Reportes.UsuarioLista.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSUsuarios";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }

        private void btnGraficoRolesUsuarios_Click(object sender, EventArgs e)
        {
            var met = new UsuarioListaNegocio();
            var dt = met.ReporteListaUsuarios();

            var reportPath = "Presentacion.Reportes.GraficoRolesUsuarios.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSUsuarios";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }

        private void btlListaProductos_Click(object sender, EventArgs e)
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
