using System;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Presentacion
{
    public partial class frmRptCompVenta : Form
    {        
        public frmRptCompVenta()
        {
            InitializeComponent();
        }       

        private void frmRptCompVenta_Load(object sender, EventArgs e)
        {
            var met = new PresupuestoNegocio();
            //var dt = met.ConsultarVentaReporte();

            var reportPath = "Presentacion.Reportes.Venta.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSVenta";
            //sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();

            this.reportViewer.RefreshReport();
        }
    }
}