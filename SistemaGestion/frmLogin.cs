using System;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;

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
        //    var ds = new DataSet();
            var dt = new DataTable();
            var usu = new LoginMetodos();
            var usuario = txtUsuario.Text;
            var pas = txtPas.Text;
            dt = usu.ConsultarLogin(usuario, pas);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Ingreso correcto");
                var frm = new frmMenu();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("No se ha encontrado el usuario ingresado");
            }
        }

        //NUEVO USUARIO
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmUsuarios();
           // this.Hide();
            frm.Show();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
