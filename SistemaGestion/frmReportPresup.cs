using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestion
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
