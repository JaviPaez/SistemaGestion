using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;

namespace Presentacion
{
    public partial class frmReportPresup : Form
    {
        public List<DatosPresup> Datos = new List<DatosPresup>();
        
        public frmReportPresup()
        {
            InitializeComponent();
        }

        private void frmReportPresup_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet", Datos));
            this.reportViewer.RefreshReport();
        }
    }
}
