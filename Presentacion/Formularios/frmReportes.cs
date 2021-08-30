using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
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
        }
    }
}
