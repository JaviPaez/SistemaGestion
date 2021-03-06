using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        #region LOAD
        private void Menu_Load(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmInicio());

            switch (frmLogin.RolUsuario)
            {
                //Cajero
                case 1:
                    Cajero(); break;

                //Óptico
                case 2:
                    Optico(); break;

                //Depósito
                case 3:
                    Deposito(); break;

                //Administrativo
                case 4:
                    Administrativo(); break;

                //Gerente
                case 5:
                    Gerente(); break;
            }
        }

        private void Gerente()
        {
            btnRpt1.Text = "Listar comprobantes";
            btnRpt2.Text = "Día con más ventas";
            btnRpt3.Text = "Producto mas vendido";
            btnRpt4.Text = "Precios históricos";
            btnRpt5.Text = "Listar productos";
            btnRpt6.Text = "Listar usuarios";
            btnRpt7.Text = "Roles de usuarios";

            btnRpt1.Size = new Size(300, 28);
            btnRpt2.Size = new Size(300, 28);
            btnRpt3.Size = new Size(300, 28);
            btnRpt4.Size = new Size(300, 28);
            btnRpt5.Size = new Size(300, 28);
            btnRpt6.Size = new Size(300, 28);
            btnRpt7.Size = new Size(300, 28);

            panelSubmenuReportes.Location = new Point(2, 459);
        }

        private void Cajero()
        {
            btnProductos.Visible = false;
            panelProducto.Visible = false;
            btnPacientes.Visible = false;
            panelPaciente.Visible = false;
            btnRecetas.Visible = false;
            panelReceta.Visible = false;
            btnUsuarios.Visible = false;
            panelUsuario.Visible = false;
            panelReportes.Visible = false;
            btnReportes.Visible = false;
            panelPresup.Location = new Point(0, 103);
            btnPresupuestos.Location = new Point(12, 103);
            panelSubmenuPresupuestos.Location = new Point(57, 157);
            panelVenta.Location = new Point(0, 154);
            btnVentas.Location = new Point(12, 154);
        }

        private void Optico()
        {
            btnProductos.Visible = false;
            panelProducto.Visible = false;
            btnVentas.Visible = false;
            panelVenta.Visible = false;
            btnUsuarios.Visible = false;
            panelUsuario.Visible = false;
            btnPresupuestos.Visible = false;
            panelPresup.Visible = false;
            panelReportes.Visible = false;
            btnReportes.Visible = false;
        }

        private void Deposito()
        {
            btnPacientes.Visible = false;
            panelPaciente.Visible = false;
            btnRecetas.Visible = false;
            panelReceta.Visible = false;
            btnVentas.Visible = false;
            panelVenta.Visible = false;
            btnUsuarios.Visible = false;
            panelUsuario.Visible = false;
            btnPresupuestos.Visible = false;
            panelPresup.Visible = false;
            panelProducto.Location = new Point(0, 103);
            btnProductos.Location = new Point(0, 103);
            panelReportes.Location = new Point(0, 154);
            btnReportes.Location = new Point(12, 154);
            panelSubmenuReportes.Location = new Point(30, 208);

            btnRpt1.Text = "Listar productos";
            btnRpt2.Text = "Precio histórico";
            btnRpt1.Size = new Size(200, 28);
            btnRpt2.Size = new Size(200, 28);
           
            btnRpt3.Visible = false;
            subpanelRpt3.Visible = false;
            btnRpt4.Visible = false;
            subpanelRpt4.Visible = false;
            btnRpt5.Visible = false;
            subpanelRpt5.Visible = false;
            btnRpt6.Visible = false;
            subpanelRpt6.Visible = false;
            btnRpt7.Visible = false;
            subpanelRpt7.Visible = false;
        }

        private void Administrativo()
        {
            btnVentas.Visible = false;
            panelVenta.Visible = false;
            btnProductos.Visible = false;
            panelProducto.Visible = false;
            btnUsuarios.Visible = false;
            panelUsuario.Visible = false;
            btnPresupuestos.Visible = false;
            panelPresup.Visible = false;
            panelReportes.Location = new Point(0, 204);
            btnReportes.Location = new Point(12, 204);
            panelSubmenuReportes.Location = new Point(2, 258);

            btnRpt1.Text = "Listar comprobantes";
            btnRpt2.Text = "Día con más ventas";
            btnRpt3.Text = "Producto mas vendido";
            btnRpt1.Size = new Size(300, 28);
            btnRpt2.Size = new Size(300, 28);
            btnRpt3.Size = new Size(300, 28);

            btnRpt4.Visible = false;
            subpanelRpt4.Visible = false;
            btnRpt5.Visible = false;
            subpanelRpt5.Visible = false;
            btnRpt6.Visible = false;
            subpanelRpt6.Visible = false;
            btnRpt7.Visible = false;
            subpanelRpt7.Visible = false;
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
            AbrirFormHijo(new frmVenta());
        }

        //Recetas
        private void btnRecetas_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRecetas());
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

            //AbrirFormHijo(new frmReportes());
        }

        private void btnRpt1_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptListaCompVta());

        }

        private void btnRpt2_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptDiaMasVentas());
        }

        private void btnRpt3_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptProductoMasVendido());
        }

        private void btnRpt4_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptPrecioHistorico());
        }

        private void btnRpt5_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptListaProductos());
        }

        private void btnRpt6_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptListaUsuarios());
        }

        private void btnRpt7_Click(object sender, EventArgs e)
        {
            CerrarSubpaneles();
            AbrirFormHijo(new frmRptRolesUsuarios());
        }

        //Salir
        private void pbxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region METODOS        
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

        //RESIZE / REDIMENSIONAR / CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/document/d/16XK2o_n4YYpi9ljQT-JTVrFONeq7xUQr097Z1maNuVA/edit");
        }

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case WM_NCHITTEST:
        //            base.WndProc(ref m);
        //            var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
        //            if (sizeGripRectangle.Contains(hitPoint))
        //                m.Result = new IntPtr(HTBOTTOMRIGHT);
        //            break;
        //        default:
        //            base.WndProc(ref m);
        //            break;
        //    }
        //}

        //DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelPrincipal.Region = region;
            this.Invalidate();
        }

        //COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(49, 66, 82));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.White, sizeGripRectangle);
        }
        #endregion
    }
}