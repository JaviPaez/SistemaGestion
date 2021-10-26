using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class frmRptDiaMasVentas : Form
    {
        public frmRptDiaMasVentas()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmRptDiaMasVentas_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Format = DateTimePickerFormat.Short;

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
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today; 
            dtpFechaDesde.Focus();
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            ReporteDiaMasVentas venta = new ReporteDiaMasVentas();
            venta.FechaDesde = dtpFechaDesde.Value;
            venta.FechaHasta = dtpFechaHasta.Value;

            var met = new VentaNegocio();
            var dt = met.ReporteDiaMasVentas(venta);

            var reportPath = "Presentacion.Reportes.DiaMasVentas.rdlc";
            ReportDataSource sReportDataSource = new ReportDataSource();

            this.reportViewer.LocalReport.ReportEmbeddedResource = reportPath;
            sReportDataSource.Name = "DSDiaMasVentas";
            sReportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(sReportDataSource);
            reportViewer.RefreshReport();
        }
    }
}