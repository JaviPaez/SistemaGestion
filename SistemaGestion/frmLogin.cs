using System;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace SistemaGestion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //BOTON INGRESAR
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            var usu = new LoginMetodos();
            var dni = txtUsuario.Text;
            var pas = txtPas.Text;
            dt = usu.ConsultarLogin(dni, pas);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Ingreso correcto", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                var frm = new frmMenu();
                this.Hide();
                frm.Show();
            }
            else MessageBox.Show("No se ha encontrado el usuario ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
        }

        //
        #region //
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        //NUEVO USUARIO
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
