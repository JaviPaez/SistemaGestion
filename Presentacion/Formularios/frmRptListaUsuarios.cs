using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class frmRptListaUsuarios : Form
    {
        public frmRptListaUsuarios()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRptListaUsuarios_Load(object sender, EventArgs e)
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
    }
}