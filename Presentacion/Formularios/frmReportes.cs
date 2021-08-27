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
        //public List<ReportePresupuesto> Datos = new List<ReportePresupuesto>();
        
        public frmReportes()
        {
            InitializeComponent();
        }

        //Presupuestos
        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            //Codigo anterior
            //reportViewer.LocalReport.DataSources.Clear();
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet", Datos));
            //this.reportViewer.RefreshReport();

            var met = new PresupuestoNegocio();
            var dt = met.ConsultarPresupuestoReporte();

            var reportPath = "Presentacion.Reportes.Presupuesto.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSPresupuesto";
            sReportDataSource.Value = dt; //.Tables[0];
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
