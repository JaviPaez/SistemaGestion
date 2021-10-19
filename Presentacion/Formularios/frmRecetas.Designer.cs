
namespace Presentacion
{
    partial class frmRecetas
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
            this.txtObserv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMiop_OD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMiop_OI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.cboDni = new System.Windows.Forms.ComboBox();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.txtAstig_OI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAstig_OD = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMedicos = new System.Windows.Forms.LinkLabel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // txtObserv
            // 
            this.txtObserv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtObserv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtObserv.Location = new System.Drawing.Point(555, 285);
            this.txtObserv.Multiline = true;
            this.txtObserv.Name = "txtObserv";
            this.txtObserv.Size = new System.Drawing.Size(528, 190);
            this.txtObserv.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(299, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 25);
            this.label7.TabIndex = 28;
            this.label7.Text = "OBSERVACIONES";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(740, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 31);
            this.label4.TabIndex = 23;
            this.label4.Text = "RECETAS";
            // 
            // txtMiop_OD
            // 
            this.txtMiop_OD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMiop_OD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiop_OD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtMiop_OD.Location = new System.Drawing.Point(1006, 152);
            this.txtMiop_OD.Name = "txtMiop_OD";
            this.txtMiop_OD.Size = new System.Drawing.Size(77, 31);
            this.txtMiop_OD.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(750, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "MIOPIA O.D.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(299, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "DNI";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(587, 515);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 53);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGrabar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(891, 515);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(188, 53);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(299, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "MEDICO";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(299, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 25);
            this.label5.TabIndex = 32;
            this.label5.Text = "FECHA";
            // 
            // txtMiop_OI
            // 
            this.txtMiop_OI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMiop_OI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiop_OI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtMiop_OI.Location = new System.Drawing.Point(555, 152);
            this.txtMiop_OI.Name = "txtMiop_OI";
            this.txtMiop_OI.Size = new System.Drawing.Size(77, 31);
            this.txtMiop_OI.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(299, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "MIOPIA O.I.";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.dtpFecha.Location = new System.Drawing.Point(555, 239);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(208, 31);
            this.dtpFecha.TabIndex = 6;
            // 
            // cboMedico
            // 
            this.cboMedico.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Items.AddRange(new object[] {
            "Seleccione"});
            this.cboMedico.Location = new System.Drawing.Point(555, 64);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(528, 33);
            this.cboMedico.TabIndex = 0;
            // 
            // cboDni
            // 
            this.cboDni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboDni.FormattingEnabled = true;
            this.cboDni.Items.AddRange(new object[] {
            "Seleccione"});
            this.cboDni.Location = new System.Drawing.Point(555, 108);
            this.cboDni.Name = "cboDni";
            this.cboDni.Size = new System.Drawing.Size(271, 33);
            this.cboDni.TabIndex = 1;
            this.cboDni.SelectionChangeCommitted += new System.EventHandler(this.cboDni_SelectionChangeCommitted);
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblNombrePaciente.ForeColor = System.Drawing.Color.White;
            this.lblNombrePaciente.Location = new System.Drawing.Point(832, 108);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(277, 31);
            this.lblNombrePaciente.TabIndex = 33;
            this.lblNombrePaciente.Text = "NOMBRE PACIENTE";
            // 
            // txtAstig_OI
            // 
            this.txtAstig_OI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAstig_OI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAstig_OI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtAstig_OI.Location = new System.Drawing.Point(555, 195);
            this.txtAstig_OI.Name = "txtAstig_OI";
            this.txtAstig_OI.Size = new System.Drawing.Size(77, 31);
            this.txtAstig_OI.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(299, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 25);
            this.label8.TabIndex = 37;
            this.label8.Text = "ASTIGMATISMO O.I.";
            // 
            // txtAstig_OD
            // 
            this.txtAstig_OD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAstig_OD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAstig_OD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtAstig_OD.Location = new System.Drawing.Point(1006, 195);
            this.txtAstig_OD.Name = "txtAstig_OD";
            this.txtAstig_OD.Size = new System.Drawing.Size(77, 31);
            this.txtAstig_OD.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(750, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(221, 25);
            this.label9.TabIndex = 36;
            this.label9.Text = "ASTIGMATISMO O.D.";
            // 
            // lblMedicos
            // 
            this.lblMedicos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMedicos.AutoSize = true;
            this.lblMedicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblMedicos.ForeColor = System.Drawing.Color.White;
            this.lblMedicos.LinkColor = System.Drawing.Color.White;
            this.lblMedicos.Location = new System.Drawing.Point(1090, 67);
            this.lblMedicos.Name = "lblMedicos";
            this.lblMedicos.Size = new System.Drawing.Size(150, 25);
            this.lblMedicos.TabIndex = 38;
            this.lblMedicos.TabStop = true;
            this.lblMedicos.Text = "Nuevo Médico";
            this.lblMedicos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMedicos_LinkClicked);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtBuscar.Location = new System.Drawing.Point(397, 602);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(225, 31);
            this.txtBuscar.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(317, 605);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 25);
            this.label10.TabIndex = 39;
            this.label10.Text = "DNI";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(653, 598);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 38);
            this.btnBuscar.TabIndex = 41;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.dgvGrilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(322, 656);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(870, 272);
            this.dgvGrilla.TabIndex = 43;
            // 
            // frmRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1720, 1042);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.lblMedicos);
            this.Controls.Add(this.txtAstig_OI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAstig_OD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.cboDni);
            this.Controls.Add(this.cboMedico);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMiop_OI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObserv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMiop_OD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecetas";
            this.Text = "Recetas";
            this.Load += new System.EventHandler(this.frmRecetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtObserv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMiop_OD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMiop_OI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.ComboBox cboDni;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.TextBox txtAstig_OI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAstig_OD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lblMedicos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvGrilla;
    }
}