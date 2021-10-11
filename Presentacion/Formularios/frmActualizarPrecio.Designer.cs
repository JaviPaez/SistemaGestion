namespace Presentacion
{
    partial class frmActualizarPrecio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarPrecio));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.pbxMinimizar = new System.Windows.Forms.PictureBox();
            this.pbxCerrar = new System.Windows.Forms.PictureBox();
            this.txtCF = new System.Windows.Forms.NumericUpDown();
            this.txtCV = new System.Windows.Forms.NumericUpDown();
            this.txtGanancia = new System.Windows.Forms.NumericUpDown();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSubCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGanancia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(254, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GANANCIA (%)";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(407, 457);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(188, 53);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(180, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "COSTO VARIABLE (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(237, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "COSTO FIJO (%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(230, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "ACTUALIZAR PRECIOS";
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BarraTitulo.Controls.Add(this.pbxMinimizar);
            this.BarraTitulo.Controls.Add(this.pbxCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(771, 38);
            this.BarraTitulo.TabIndex = 20;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // pbxMinimizar
            // 
            this.pbxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pbxMinimizar.Image")));
            this.pbxMinimizar.Location = new System.Drawing.Point(706, 7);
            this.pbxMinimizar.Name = "pbxMinimizar";
            this.pbxMinimizar.Size = new System.Drawing.Size(25, 25);
            this.pbxMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxMinimizar.TabIndex = 2;
            this.pbxMinimizar.TabStop = false;
            this.pbxMinimizar.Click += new System.EventHandler(this.pbxMinimizar_Click);
            // 
            // pbxCerrar
            // 
            this.pbxCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbxCerrar.Image")));
            this.pbxCerrar.Location = new System.Drawing.Point(743, 7);
            this.pbxCerrar.Name = "pbxCerrar";
            this.pbxCerrar.Size = new System.Drawing.Size(25, 25);
            this.pbxCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCerrar.TabIndex = 0;
            this.pbxCerrar.TabStop = false;
            this.pbxCerrar.Click += new System.EventHandler(this.pbxCerrar_Click);
            // 
            // txtCF
            // 
            this.txtCF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtCF.Location = new System.Drawing.Point(446, 278);
            this.txtCF.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(99, 31);
            this.txtCF.TabIndex = 3;
            // 
            // txtCV
            // 
            this.txtCV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtCV.Location = new System.Drawing.Point(446, 326);
            this.txtCV.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(99, 31);
            this.txtCV.TabIndex = 4;
            // 
            // txtGanancia
            // 
            this.txtGanancia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtGanancia.Location = new System.Drawing.Point(446, 229);
            this.txtGanancia.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.Size = new System.Drawing.Size(99, 31);
            this.txtGanancia.TabIndex = 2;
            // 
            // cboCategoria
            // 
            this.cboCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(219, 108);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(489, 33);
            this.cboCategoria.TabIndex = 0;
            this.cboCategoria.SelectionChangeCommitted += new System.EventHandler(this.cboCategoria_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(70, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "CATEGORIA";
            // 
            // cboSubCategoria
            // 
            this.cboSubCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboSubCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboSubCategoria.FormattingEnabled = true;
            this.cboSubCategoria.Location = new System.Drawing.Point(219, 158);
            this.cboSubCategoria.Name = "cboSubCategoria";
            this.cboSubCategoria.Size = new System.Drawing.Size(489, 33);
            this.cboSubCategoria.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(27, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 25);
            this.label6.TabIndex = 45;
            this.label6.Text = "SUBCATEGORIA";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(172, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 53);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmActualizarPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(771, 616);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSubCategoria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGanancia);
            this.Controls.Add(this.txtCV);
            this.Controls.Add(this.txtCF);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActualizarPrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Médicos";
            this.Load += new System.EventHandler(this.frmActualizarPrecio_Load);
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGanancia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox pbxMinimizar;
        private System.Windows.Forms.PictureBox pbxCerrar;
        private System.Windows.Forms.NumericUpDown txtCF;
        private System.Windows.Forms.NumericUpDown txtCV;
        private System.Windows.Forms.NumericUpDown txtGanancia;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSubCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
    }
}