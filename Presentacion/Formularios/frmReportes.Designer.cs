using CapaEntidad;

namespace Presentacion
{
    partial class frmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            this.DatosPresupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportePresupuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DatosPresupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportePresupuestoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DatosPresupBindingSource
            // 
            this.DatosPresupBindingSource.DataSource = typeof(CapaEntidad.ReportePresupuesto);
            // 
            // ReportePresupuestoBindingSource
            // 
            this.ReportePresupuestoBindingSource.DataSource = typeof(CapaEntidad.ReportePresupuesto);
            // 
            // btnPresupuestos
            // 
            this.btnPresupuestos.Location = new System.Drawing.Point(30, 9);
            this.btnPresupuestos.Name = "btnPresupuestos";
            this.btnPresupuestos.Size = new System.Drawing.Size(75, 23);
            this.btnPresupuestos.TabIndex = 1;
            this.btnPresupuestos.Text = "Presupuestos";
            this.btnPresupuestos.UseVisualStyleBackColor = true;
            this.btnPresupuestos.Click += new System.EventHandler(this.btnPresupuestos_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(278, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // reportViewer
            // 
            this.reportViewer.Location = new System.Drawing.Point(0, 38);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(988, 966);
            this.reportViewer.TabIndex = 4;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 1003);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPresupuestos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportes";
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosPresupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportePresupuestoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource DatosPresupBindingSource;
        private System.Windows.Forms.BindingSource ReportePresupuestoBindingSource;
        private System.Windows.Forms.Button btnPresupuestos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}