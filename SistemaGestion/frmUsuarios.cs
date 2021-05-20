using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

                    switch (cboRol.SelectedItem)
                    {
                        case "Administrador":
                            user.IdRol = 1;
                            break;

                        case "Vendedor":
                            user.IdRol = 2;
                            break;

                        case "Gerente":
                            user.IdRol = 3;
                            break;

                        default:
                            user.IdRol = 0;
                            break;
                    }

                    user.Apellido = txtApellido.Text;
                    user.Nombre = txtNombre.Text;
                    user.Contraseña = txtContraseña.Text;

                    var usuMetodo = new LoginMetodos();
                    Boolean grabo = usuMetodo.grabarUsuario(user);
                    if (grabo == false)
                    {
                        MessageBox.Show("Error en Grabacion", "ERROR");
                    }
                    else
                    {
                        MessageBox.Show("Grabacion Correcta", "Grabar");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Hide();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cboRol.SelectedIndex = 0;
        }
    }
}
