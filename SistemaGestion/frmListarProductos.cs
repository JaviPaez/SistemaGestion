﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestion
{
    public partial class frmListarProductos : Form
    {
        public frmListarProductos ()
        {
            InitializeComponent();
        }

        //BOTON ARMAR LISTA 
        private void btnGrilla_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            var al = new ProductoMetodos();
            dt = al.consultarProductos();
            if (dt.Rows.Count != 0)
            {
                dgvLista.DataSource = dt;
                dgvLista.Columns["ID"].Visible = false;
            }
            else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtDescripcion.Clear();
        }

        //BOTON BUSCAR POR DESCRIPCION
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text != string.Empty)
            {
                try
                {
                    var ds = new DataSet();
                    var dt = new DataTable();
                    var al = new ProductoMetodos();

                    dt = al.buscarProducto(txtDescripcion.Text);

                    if (dt.Rows.Count != 0)
                    {
                        dgvLista.DataSource = dt;
                        dgvLista.Columns["ID"].Visible = false;
                    }
                    else MessageBox.Show("No hay registros en la selección", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {    
                    MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}