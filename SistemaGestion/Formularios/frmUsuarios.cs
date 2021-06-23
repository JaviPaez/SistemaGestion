﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SistemaGestion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);

            var usuario = new Usuario();
            if (respuesta == DialogResult.Yes)
            {
                if (txtContraseña.Text == txtVerifContr.Text)
                {
                    try
                    {
                        usuario.Contraseña = txtContraseña.Text;
                        usuario.Dni = Convert.ToInt32(txtDni.Text);
                        usuario.IdRol = Convert.ToInt32(cboRol.SelectedValue);
                        usuario.Apellido = txtApellido.Text;
                        usuario.Nombre = txtNombre.Text;

                        var usuarioMetodo = new UsuarioMetodos();
                        Boolean grabo = usuarioMetodo.GrabarUsuario(usuario);

                        if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("La contraseña no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //LOAD
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            //Cargar Combo Roles
            var dt = new DataTable();
            var rol = new RolMetodos();
            dt = rol.CargarComboRoles();

            cboRol.DataSource = dt;
            cboRol.DisplayMember = "NombreRol";
            cboRol.ValueMember = "ID";

            ReiniciarCampos();
        }


        #region
        //ARRASTRAR EL FORMULARIO
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Botones
        //BOTONES DE BARRA DE TITULO 
        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion BOTONES

        //Reiniciar campos
        private void ReiniciarCampos()
        {
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtContraseña.Clear();
            txtVerifContr.Clear();
            cboRol.Text = "SELECCIONE";
            txtDni.Focus();
        }
    }
}