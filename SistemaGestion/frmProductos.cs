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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }          
        
        //LOAD
        private void frmProductos_Load(object sender, EventArgs e)
        {
            btnGrilla_Click(sender, e);
        }

        //BOTON GRABAR
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la grabación?", "Grabar", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            var producto = new Producto();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    producto.Descripcion = txtDescripcion.Text;
                    producto.Precio = txtPrecio.Text;
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

                    var productoMetodo = new ProductoMetodos();
                    Boolean grabo = productoMetodo.grabarProducto(producto);

                    if (grabo == false) MessageBox.Show("Error en grabación", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else MessageBox.Show("Grabación correcta", "Grabar",MessageBoxButtons.OK,MessageBoxIcon.Information);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnGrilla_Click(sender, e);
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Confirma la modificación?", "Modificar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            var producto = new Producto();
            try
            {
                if (resp == DialogResult.Yes)
                {
                    producto.Descripcion = txtDescripcion.Text;
                    producto.Precio = txtPrecio.Text;
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    producto.Id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value);

                    var productoMetodo = new ProductoMetodos();
                    Boolean modifico = productoMetodo.modificarProducto(producto);

                    if (modifico == false) MessageBox.Show("Error en modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Modificación correcta", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnGrilla_Click(sender, e);
        }

        //BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            txtDescripcion.Focus();
        }

        //BOTON BUSCAR POR DESCRIPCION
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarDescr.Text != string.Empty)
            {
                try
                {
                    var ds = new DataSet();
                    var dt = new DataTable();
                    var al = new ProductoMetodos();

                    dt = al.buscarProducto(txtBuscarDescr.Text);

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

            txtBuscarDescr.Clear();
        }

        //CLICK EN CONTENIDO DE CELDA DGV
        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDescripcion.Text = dgvLista.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dgvLista.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = dgvLista.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
    }
}