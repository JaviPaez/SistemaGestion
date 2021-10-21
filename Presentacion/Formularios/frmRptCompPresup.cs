using System;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Presentacion
{
    public partial class frmRptCompPresup : Form
    {        
        public frmRptCompPresup()
        {
            InitializeComponent();
        }       

        private void frmRptCompPresup_Load(object sender, EventArgs e)
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

            this.reportViewer.RefreshReport();
        }
    }
}