//using CapaEntidad;

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
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.btnListaUsuarios = new System.Windows.Forms.Button();
            this.btnGraficoRolesUsuarios = new System.Windows.Forms.Button();
            this.btlListaProductos = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosPresupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportePresupuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DatosPresupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportePresupuestoBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // btnListaUsuarios
            // 
            this.btnListaUsuarios.Location = new System.Drawing.Point(111, 9);
            this.btnListaUsuarios.Name = "btnListaUsuarios";
            this.btnListaUsuarios.Size = new System.Drawing.Size(96, 23);
            this.btnListaUsuarios.TabIndex = 2;
            this.btnListaUsuarios.Text = "Lista de Usuarios";
            this.btnListaUsuarios.UseVisualStyleBackColor = true;
            this.btnListaUsuarios.Click += new System.EventHandler(this.btnListaUsuarios_Click);
            // 
            // btnGraficoRolesUsuarios
            // 
            this.btnGraficoRolesUsuarios.Location = new System.Drawing.Point(213, 9);
            this.btnGraficoRolesUsuarios.Name = "btnGraficoRolesUsuarios";
            this.btnGraficoRolesUsuarios.Size = new System.Drawing.Size(145, 23);
            this.btnGraficoRolesUsuarios.TabIndex = 3;
            this.btnGraficoRolesUsuarios.Text = "Gráfico Roles de Usuarios";
            this.btnGraficoRolesUsuarios.UseVisualStyleBackColor = true;
            this.btnGraficoRolesUsuarios.Click += new System.EventHandler(this.btnGraficoRolesUsuarios_Click);
            // 
            // btlListaProductos
            // 
            this.btlListaProductos.Location = new System.Drawing.Point(364, 9);
            this.btlListaProductos.Name = "btlListaProductos";
            this.btlListaProductos.Size = new System.Drawing.Size(108, 23);
            this.btlListaProductos.TabIndex = 4;
            this.btlListaProductos.Text = "Lista de Productos";
            this.btlListaProductos.UseVisualStyleBackColor = true;
            this.btlListaProductos.Click += new System.EventHandler(this.btlListaProductos_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Location = new System.Drawing.Point(1, 38);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(984, 963);
            this.reportViewer.TabIndex = 5;
            // 
            // DatosPresupBindingSource
            // 
            this.DatosPresupBindingSource.DataSource = typeof(CapaEntidad.ReportePresupuesto);
            // 
            // ReportePresupuestoBindingSource
            // 
            this.ReportePresupuestoBindingSource.DataSource = typeof(CapaEntidad.ReportePresupuesto);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 1003);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.btlListaProductos);
            this.Controls.Add(this.btnGraficoRolesUsuarios);
            this.Controls.Add(this.btnListaUsuarios);
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
        private System.Windows.Forms.Button btnListaUsuarios;
        private System.Windows.Forms.Button btnGraficoRolesUsuarios;
        private System.Windows.Forms.Button btlListaProductos;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}