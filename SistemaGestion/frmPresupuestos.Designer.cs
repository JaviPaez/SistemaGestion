namespace SistemaGestion
{
    partial class frmPresupuestos
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
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboIdReceta = new System.Windows.Forms.ComboBox();
            this.cboDniPaciente = new System.Windows.Forms.ComboBox();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblAstigOD = new System.Windows.Forms.Label();
            this.lblMiopOD = new System.Windows.Forms.Label();
            this.lblAstigOI = new System.Windows.Forms.Label();
            this.lblMiopOI = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(1328, 924);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(188, 53);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1086, 924);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 53);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1248, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "USUARIO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(102, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "DNI PACIENTE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(696, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "PRESUPUESTOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(765, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "RECETA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.dtpFecha.Location = new System.Drawing.Point(1392, 165);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 31);
            this.dtpFecha.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1248, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "FECHA";
            // 
            // cboIdReceta
            // 
            this.cboIdReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboIdReceta.FormattingEnabled = true;
            this.cboIdReceta.Items.AddRange(new object[] {
            "Seleccione",
            "Apross",
            "OSDE",
            "Prevencion Salud",
            "SIPSSA"});
            this.cboIdReceta.Location = new System.Drawing.Point(916, 115);
            this.cboIdReceta.Name = "cboIdReceta";
            this.cboIdReceta.Size = new System.Drawing.Size(200, 33);
            this.cboIdReceta.TabIndex = 2;
            this.cboIdReceta.SelectionChangeCommitted += new System.EventHandler(this.cboIdReceta_SelectionChangeCommitted);
            // 
            // cboDniPaciente
            // 
            this.cboDniPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboDniPaciente.FormattingEnabled = true;
            this.cboDniPaciente.Items.AddRange(new object[] {
            "Seleccione",
            "Apross",
            "OSDE",
            "Prevencion Salud",
            "SIPSSA"});
            this.cboDniPaciente.Location = new System.Drawing.Point(358, 115);
            this.cboDniPaciente.Name = "cboDniPaciente";
            this.cboDniPaciente.Size = new System.Drawing.Size(200, 33);
            this.cboDniPaciente.TabIndex = 1;
            this.cboDniPaciente.SelectionChangeCommitted += new System.EventHandler(this.cboDniPaciente_SelectionChangeCommitted);
            // 
            // cboUsuario
            // 
            this.cboUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Items.AddRange(new object[] {
            "Seleccione",
            "Apross",
            "OSDE",
            "Prevencion Salud",
            "SIPSSA"});
            this.cboUsuario.Location = new System.Drawing.Point(1392, 107);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(200, 33);
            this.cboUsuario.TabIndex = 0;
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblNombrePaciente.ForeColor = System.Drawing.Color.White;
            this.lblNombrePaciente.Location = new System.Drawing.Point(232, 154);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(110, 31);
            this.lblNombrePaciente.TabIndex = 34;
            this.lblNombrePaciente.Text = "Nombre";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Location = new System.Drawing.Point(972, 497);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(153, 30);
            this.btnQuitar.TabIndex = 35;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(972, 461);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(153, 30);
            this.btnAgregar.TabIndex = 36;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // cboProducto
            // 
            this.cboProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(743, 477);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(200, 33);
            this.cboProducto.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(487, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "PRODUCTO";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(492, 546);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(647, 228);
            this.dgvLista.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(588, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 40;
            this.label7.Text = "Miopia O.I.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(588, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 25);
            this.label8.TabIndex = 41;
            this.label8.Text = "Astigmatismo O.I.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(896, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 25);
            this.label9.TabIndex = 42;
            this.label9.Text = "Miopia O.D.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(896, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 25);
            this.label10.TabIndex = 43;
            this.label10.Text = "Astigmatismo O.D.";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(843, 160);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(72, 25);
            this.lblFecha.TabIndex = 49;
            this.lblFecha.Text = "Fecha";
            // 
            // lblAstigOD
            // 
            this.lblAstigOD.AutoSize = true;
            this.lblAstigOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblAstigOD.ForeColor = System.Drawing.Color.White;
            this.lblAstigOD.Location = new System.Drawing.Point(1095, 228);
            this.lblAstigOD.Name = "lblAstigOD";
            this.lblAstigOD.Size = new System.Drawing.Size(91, 25);
            this.lblAstigOD.TabIndex = 48;
            this.lblAstigOD.Text = "AstigOD";
            // 
            // lblMiopOD
            // 
            this.lblMiopOD.AutoSize = true;
            this.lblMiopOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblMiopOD.ForeColor = System.Drawing.Color.White;
            this.lblMiopOD.Location = new System.Drawing.Point(1095, 193);
            this.lblMiopOD.Name = "lblMiopOD";
            this.lblMiopOD.Size = new System.Drawing.Size(90, 25);
            this.lblMiopOD.TabIndex = 47;
            this.lblMiopOD.Text = "MiopOD";
            // 
            // lblAstigOI
            // 
            this.lblAstigOI.AutoSize = true;
            this.lblAstigOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblAstigOI.ForeColor = System.Drawing.Color.White;
            this.lblAstigOI.Location = new System.Drawing.Point(782, 228);
            this.lblAstigOI.Name = "lblAstigOI";
            this.lblAstigOI.Size = new System.Drawing.Size(81, 25);
            this.lblAstigOI.TabIndex = 46;
            this.lblAstigOI.Text = "AstigOI";
            // 
            // lblMiopOI
            // 
            this.lblMiopOI.AutoSize = true;
            this.lblMiopOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblMiopOI.ForeColor = System.Drawing.Color.White;
            this.lblMiopOI.Location = new System.Drawing.Point(782, 193);
            this.lblMiopOI.Name = "lblMiopOI";
            this.lblMiopOI.Size = new System.Drawing.Size(80, 25);
            this.lblMiopOI.TabIndex = 45;
            this.lblMiopOI.Text = "MiopOI";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.White;
            this.lblObservaciones.Location = new System.Drawing.Point(697, 267);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(81, 25);
            this.lblObservaciones.TabIndex = 50;
            this.lblObservaciones.Text = "Observ";
            // 
            // frmPresupuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1720, 1042);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblAstigOD);
            this.Controls.Add(this.lblMiopOD);
            this.Controls.Add(this.lblAstigOI);
            this.Controls.Add(this.lblMiopOI);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.cboUsuario);
            this.Controls.Add(this.cboDniPaciente);
            this.Controls.Add(this.cboIdReceta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPresupuestos";
            this.Text = "frmPresupuestos";
            this.Load += new System.EventHandler(this.frmPresupuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboIdReceta;
        private System.Windows.Forms.ComboBox cboDniPaciente;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblAstigOD;
        private System.Windows.Forms.Label lblMiopOD;
        private System.Windows.Forms.Label lblAstigOI;
        private System.Windows.Forms.Label lblMiopOI;
        private System.Windows.Forms.Label lblObservaciones;
    }
}