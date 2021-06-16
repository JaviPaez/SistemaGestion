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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }     

        #region LOAD
        //LOAD
        private void Menu_Load(object sender, EventArgs e)
        {          
            AbrirFormHijo(new frmInicio());
        }

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

        #region BOTONES
        //BOTONES DE BARRA DE TITULO

        //Posicion actual frm
        int lx, ly;
        int sw, sh;

        private void pbxMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            pbxMaximizar.Visible = false;
            pbxRestaurar.Visible = true;
        }

        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);

            this.WindowState = FormWindowState.Normal;
            pbxRestaurar.Visible = false;
            pbxMaximizar.Visible = true;
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //BOTONES DEL MENU    
        private void pbxLogo_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmInicio());
        }

        //Pacientes
        private void btnPacientes_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();            
            AbrirFormHijo(new frmPacientes());
        }  

        //Ventas
        private void btnVentas_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
        }

        //Recetas
        private void btnRecetas_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRecetasMedicos());
        }

        //Productos
        private void btnProductos_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmProductos());
        }               

        //Usuarios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmListarUsuarios());
        }

        //Presupuestos
        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            panelSubmenuPresupuestos.Visible = true;
        }

        private void btnGrabarPresupuestos_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmPresupuestos());
        }

        private void btnConsultarPresupuestos_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmListarPresupuestos());
        }

        //Reportes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            panelSubmenuReportes.Visible = true;
        }

        private void btnRptVenta_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
        }

        private void btnRptPagos_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
        }

        private void btnRptEstadisticas_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
        }    

        //Salir
        private void pbxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region METODOS
        //METODOS
        private void AbrirFormHijo(Form fh)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;

            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void CerrarSubpaneles()
        {
            panelSubmenuReportes.Visible = false;
            panelSubmenuPresupuestos.Visible = false;
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que quiere salir?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No) e.Cancel = true; 
        }
        #endregion
    }
}