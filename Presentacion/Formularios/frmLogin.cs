using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;

namespace Presentacion
{
    public partial class frmLogin : Form
    {
        public static int RolUsuario;
        public static int DniUsuario;

        public frmLogin()
        {
            InitializeComponent();
        }

        //LOAD
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        //BOTON INGRESAR
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuario = new UsuarioNegocio();
            if (int.TryParse(txtUsuario.Text, out int dni))
            {
            }
            else dni = Convert.ToInt32(txtUsuario.Text);

            var contraseña = txtPas.Text;

            if (txtUsuario.Text != "")
            {
                if (txtPas.Text != "")
                {
                    var dr = usuario.Login(dni, contraseña);

                    if (dr.Read())
                    {
                        DniUsuario = Convert.ToInt32(dr["Dni"]);

                        var nombreApellido = dr["Nombre"] + " " + dr["Apellido"];

                        string rol = "";

                        switch (dr["IdRol"])
                        {
                            case 1:
                                rol = "Cajero";
                                RolUsuario = 1; break;

                            case 2:
                                rol = "Óptico";
                                RolUsuario = 2; break;

                            case 3:
                                rol = "Depósito";
                                RolUsuario = 3; break;

                            case 4:
                                rol = "Administrativo";
                                RolUsuario = 4; break;

                            case 5:
                                rol = "Gerente";
                                RolUsuario = 5; break;
                        }

                        MessageBox.Show("Bienvenido\n" + nombreApellido + "\nRol: " + rol, "Ingreso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var frm = new frmMenu();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblError.Visible = false;
                        txtPas.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                    }
                }
                else MensajeError("Ingrese contraseña");
            }
            else MensajeError("Ingrese usuario");
        }

        private void MensajeError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        //BOTON NUEVO USUARIO
        private void lblNvoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmUsuarios();
            frm.Show();
        }

        //BOTONES DE BARRA DE TITULO
        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //
        #region //
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
    }
}