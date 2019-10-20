using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudBd_Logica;
using ClassLibrary1;

namespace CrudBd_Presentacion
{
    public partial class Form1 : Form
    {
        Logica log = new Logica();
        Datos dat = new Datos();
        public Form1()
        {
            InitializeComponent();
            LlenarGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtNumero.Text == "")
                {
                    MessageBox.Show("Ingrese un numero");
                }else if(txtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese un nombre");
                }else if(txtCategoria.Text == "")
                {
                    MessageBox.Show("Ingrese una categoria");
                }else if(dtpC.Value.Date.ToShortDateString() == "")
                {
                    MessageBox.Show("Ingrese una fecha");
                }
                else { 
                log.numProducto = int.Parse(txtNumero.Text);
                log.nombre = txtNombre.Text;
                log.categoria = txtCategoria.Text;
                log.creacion = dtpC.Value.Date.ToShortDateString();

                dat.Agregar(log.numProducto, log.nombre, log.categoria, log.creacion);
                LlenarGrid();
                    Limpiar();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                dat.Cancelar();
            }
        }
        public void LlenarGrid()
        {
            gridProductos.DataSource = dat.LlenarGrid();
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
        
            try
            {

                if(txtNumero.Text == "") {
                    MessageBox.Show("Debes escribir el numero del producto a borrar");
                }
                else {
                    log.numProducto = int.Parse(txtNumero.Text);
                    dat.Borrar(log.numProducto);

                LlenarGrid();
                    MessageBox.Show("Los productos se borran en base al numero ingresado");
                    MessageBox.Show("Producto Borrado");
                    Limpiar();
                }

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text == "")
                {
                    MessageBox.Show("Ingrese el numero del producto a actualizar");
                }
                else if (txtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese el nuevo nombre");
                }
                else if (txtCategoria.Text == "")
                {
                    MessageBox.Show("Ingrese la nueva categoria");
                }
                else
                {
                    MessageBox.Show("Los productos se actualizan en base al numero ingresado");
                    log.numProducto = int.Parse(txtNumero.Text);
                    log.nombre = txtNombre.Text;
                    log.categoria = txtCategoria.Text;
                    log.creacion = dtpC.Value.Date.ToShortDateString();

                    dat.Actualizar(log.numProducto, log.nombre, log.categoria, log.creacion);
                    LlenarGrid();

                    LlenarGrid();

                    MessageBox.Show("Producto actualizado");
                    Limpiar();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar()
        {
            foreach (Control erase in Controls)
            {
                if (erase is TextBox)
                {
                    erase.Text = "";
                }
            }
            LlenarGrid();
        }
    }
}
