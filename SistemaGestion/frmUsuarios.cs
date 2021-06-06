using System;
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);                      

            var user = new Usuario();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    user.Dni = Convert.ToInt32(txtDni.Text);
                    user.IdRol = Convert.ToInt32(cboRol.SelectedValue);
                    user.Apellido = txtApellido.Text;
                    user.Nombre = txtNombre.Text;
                    user.Contraseña = txtContraseña.Text;

                    var usuMetodo = new LoginMetodos();
                    Boolean grabo = usuMetodo.grabarUsuario(user);

                    if (grabo == false)  MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    else MessageBox.Show("Grabación correcta", "Grabar",MessageBoxButtons.OK,MessageBoxIcon.Information);                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Hide();
        }

        //BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtContraseña.Clear();
            cboRol.Text = "Seleccione";
        }

        //LOAD
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            //Cargar Combo Roles
            var dt = new DataTable();
            var rol = new RolMetodos();
            dt = rol.cargarComboRoles();

            cboRol.DataSource = dt;
            cboRol.DisplayMember = "NombreRol";
            cboRol.ValueMember = "ID";

            cboRol.Text = "Seleccione";
        }

        //Desplazar desde barra de titulo
        #region //
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //BOTONES DE BARRA DE TITULO 
        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
