using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using apiexamen;

namespace Examen_trabajo
{

    public partial class Form1 : Form
    {
        EntradaSalida procesos = new EntradaSalida();
        private string idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProdctos();
        }
        private void MostrarProdctos()
        {
            StoredProcedures objeto = new apiexamen.StoredProcedures();
            dataGridView1.DataSource = objeto.Mostrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    procesos.InsertarExamen(txtValor1.Text, txtValor2.Text);
                    MessageBox.Show("se inserto correctamente");
                    MostrarProdctos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    procesos.EditarExamen(txtValor1.Text, txtValor2.Text);
                    MessageBox.Show("se edito correctamente");
                    MostrarProdctos();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }

        private void txtValor1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtValor1.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtValor2.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                procesos.EliminarExamen(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}