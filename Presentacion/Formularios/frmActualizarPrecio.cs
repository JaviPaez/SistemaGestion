using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Presentacion
{
    public partial class frmActualizarPrecio : Form
    {
        public frmActualizarPrecio()
        {
            InitializeComponent();
        }

        //LOAD
        #region
        private void frmActualizarPrecio_Load(object sender, EventArgs e)
        {
            //Cargar Combo Categorias
            var dt = new DataTable();
            var cat = new CategoriaNegocio();
            dt = cat.CargarComboCategorias();

            cboCategoria.DataSource = dt;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "ID";

            ReiniciarCampos();
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

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var medico = new Medico();
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    //medico.Matricula = txtMatricula.Text;
                    //medico.Apellido = txtApellido.Text;
                    //medico.Nombre = txtNombre.Text;                   

                    var medicoMetodo = new MedicoNegocio();
                    Boolean grabo = medicoMetodo.GrabarMedico(medico);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Grabación correcta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
            catch (Exception ex)
            {
                MessageBox.Show("Error en grabación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
         //Reiniciar campos
        private void ReiniciarCampos()
        {
            cboCategoria.Text = "SELECCIONE";
            cboSubCategoria.Text = "SELECCIONE";
            txtCF.ResetText();
            txtCV.ResetText();
            txtGanancia.ResetText();
            cboCategoria.Focus();
        }

        //BOTON CANCELAR    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
        }

        //BOTONES BARRA DE TITULO
        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Combo subcategorias
        private void cboCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dt2 = new DataTable();
            var subcat = new CategoriaNegocio();
            int idCat;
            idCat = Convert.ToInt32(cboCategoria.SelectedValue);
            dt2 = subcat.CargarComboSubCategorias(idCat);

            cboSubCategoria.DataSource = dt2;
            cboSubCategoria.DisplayMember = "Descripcion";
            cboSubCategoria.ValueMember = "ID";
        }
    }
}
