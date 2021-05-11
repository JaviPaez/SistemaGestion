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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Confirma la Grabación...", "Grabar", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
            var usu = new LoginEn();
            if ((resp == DialogResult.Yes))
            {
                usu.usuario = txtUsuario.Text;
                usu.contrasenia = txtPass.Text;
                usu.permisos = Convert.ToInt32(txtNivel.Text);
                var usuMetodo = new LoginMetodos();
                Boolean grabo = usuMetodo.grabarUsuario(usu);
                if (grabo == false)
                {
                    MessageBox.Show("Error en Grabacion...", "Verifique");
                }
                else
                {
                    MessageBox.Show("Grabacion Correcta...", "Grabar");
                    
                }
                
            }
            this.Hide();
        }
    }
}
