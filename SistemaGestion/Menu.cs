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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbxMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pbxMaximizar.Visible = false;
            pbxRestaurar.Visible = true;
        }

        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pbxRestaurar.Visible = false;
            pbxMaximizar.Visible = true;
        }

        //LOAD
        private void Menu_Load(object sender, EventArgs e)
        {           
            AbrirFormHijo(new Inicio());
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

            
        //Botones
        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Productos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelSubmenuReportes.Visible = true;
        }

        private void btnRptVenta_Click(object sender, EventArgs e)
        {
            panelSubmenuReportes.Visible = false;
        }

        private void btnRptPagos_Click(object sender, EventArgs e)
        {
            panelSubmenuReportes.Visible = false;
        }

        private void btnRptEstadisticas_Click(object sender, EventArgs e)
        {
            panelSubmenuReportes.Visible = false;
        }

        private void pbxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormHijo(object formHijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);

            Form fh = formHijo as Form;

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;

            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void pbxLogo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Inicio());
        }
    }
}
