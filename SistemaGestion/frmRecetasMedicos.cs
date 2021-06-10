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
    public partial class frmRecetasMedicos : Form
    {
        public frmRecetasMedicos()
        {
            InitializeComponent();
        }

        private void recetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmRecetas());
        }

        private void medicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmMedicos());
        }

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
    }
}
