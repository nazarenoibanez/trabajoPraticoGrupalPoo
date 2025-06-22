using Kisoco.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Kiosco
{
    public partial class FrmKioscoAE : Form
    {
        private Producto? producto = null!;

        public FrmKioscoAE()
        {
            InitializeComponent();
            this.Load += FrmKioscoAE_Load;
            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;

        }
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMarca.Items.Clear();

            switch (cboTipo.SelectedItem.ToString())
            {
                case "Golosina":
                    foreach (var marca in Enum.GetValues(typeof(MarcaG)))
                    {
                        cboMarca.Items.Add(marca);
                    }
                    break;
                case "Cigarrillo":
                    foreach (var marca in Enum.GetValues(typeof(MarcaC)))
                    {
                        cboMarca.Items.Add(marca);
                    }
                    break;
                case "Bebida":
                    foreach (var marca in Enum.GetValues(typeof(MarcaB)))
                    {
                        cboMarca.Items.Add(marca);
                    }
                    break;
            }

            if (cboMarca.Items.Count > 0)
                cboMarca.SelectedIndex = 0;
        }


        public FrmKioscoAE()
        {
            InitializeComponent();

            CargarComboTipo();

            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;
        }


        private void FrmKioscoAE_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            cboTipo.DataSource = Enum.GetValues(typeof(TipoGolosina));
            cboMarca.DataSource = Enum.GetValues(typeof(MarcaG));
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            string nombre = txtNombre.Text;
            double precioBase = double.Parse(txtPrecioBase.Text);
            int stock = int.Parse(txtStock.Text);
            DateTime fechaIngreso = dtpFechaIngreso.Value.Date;
            DateTime fechaVto = dtpFechaVto.Value.Date;

            string tipoSeleccionado = cboTipo.SelectedItem.ToString()!;

            if (tipoSeleccionado == "Golosina")
            {
                var tipoG = (TipoGolosina)cboTipo.SelectedItem!;
                var marcaG = (MarcaG)cboMarca.SelectedItem!;
                producto = new Golosina(tipoG, marcaG)
                {
                    Nombre = nombre,
                    PrecioBase = precioBase,
                    stock = stock,
                    fechaIngreso = fechaIngreso,
                    fechaVto = fechaVto
                };
            }
            else if (tipoSeleccionado == "Cigarrillo")
            {
                var marcaC = (MarcaC)cboMarca.SelectedItem!;
                producto = new Cigarrillo(marcaC, true) 
                {
                    Nombre = nombre,
                    PrecioBase = precioBase,
                    stock = stock,
                    fechaIngreso = fechaIngreso,
                    fechaVto = fechaVto
                };
            }
            else if (tipoSeleccionado == "Bebida")
            {
                var marcaB = (MarcaB)cboMarca.SelectedItem!;
                producto = new Bebida(marcaB, 1, false) 
                {
                    Nombre = nombre,
                    PrecioBase = precioBase,
                    stock = stock,
                    fechaIngreso = fechaIngreso,
                    fechaVto = fechaVto
                };
            }

            DialogResult = DialogResult.OK;
        }

        public Producto? GetProducto()
        {
            return producto;
        }


        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return false;
            }

            if (!double.TryParse(txtPrecioBase.Text, out _))
            {
                MessageBox.Show("Precio base inválido.");
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Stock inválido.");
                return false;
            }

            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de producto.");
                return false;
            }

            if (cboMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca.");
                return false;
            }

            return true;
        }

        private Producto? CrearProductoDesdeFormulario()
        {
            string nombre = txtNombre.Text.Trim();

            if (!double.TryParse(txtPrecioBase.Text, out double precioBase))
                throw new Exception("Precio base inválido.");

            if (!int.TryParse(txtStock.Text, out int stock))
                throw new Exception("Stock inválido.");

            DateTime fechaIngreso = dtpFechaIngreso.Value.Date;
            DateTime fechaVto = dtpFechaVto.Value.Date;

            string tipoSeleccionado = cboTipo.SelectedItem.ToString();
            object marcaSeleccionada = cboMarca.SelectedItem;

            if (string.IsNullOrEmpty(nombre))
                throw new Exception("El nombre es requerido.");

            if (marcaSeleccionada == null)
                throw new Exception("Debe seleccionar una marca.");

            switch (tipoSeleccionado)
            {
                case "Golosina":
                    MarcaG marcaG = (MarcaG)marcaSeleccionada;
                    return new Golosina((TipoGolosina)0, marcaG) 
                    {
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        stock = stock,
                        fechaIngreso = fechaIngreso,
                        fechaVto = fechaVto
                    };

                case "Cigarrillo":
                    MarcaC marcaC = (MarcaC)marcaSeleccionada;
                    return new Cigarrillo(marcaC, false) 
                    {
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        stock = stock,
                        fechaIngreso = fechaIngreso,
                        fechaVto = fechaVto
                    };

                case "Bebida":
                    MarcaB marcaB = (MarcaB)marcaSeleccionada;
                    return new Bebida(marcaB, 1, false) 
                    {
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        stock = stock,
                        fechaIngreso = fechaIngreso,
                        fechaVto = fechaVto
                    };

                default:
                    throw new Exception("Tipo de producto inválido");
            }
        }


    }
}
