using Kisoco.Datos;
using Repositorio.Kiosco;
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
    public partial class FrmKiosco : Form
    {
        public FrmKiosco()
        {
            InitializeComponent();
            TsbNuevo.Click += TsbNuevo_Click;
            Load += FrmKiosco_Load;
            TsbEliminar.Click += TsbEliminar_Click;
            TsbEditar.Click += TsbEditar_Click;
            TsbSalir.Click += TsbSalir_Click;

        }

        private List<Producto> lista = null!;
        private RepositorioProductos _repositorio = null!;

        private void FrmKiosco_Load(object? sender, EventArgs e)
        {
            try
            {
                _repositorio = RepositorioProductos.GetInstancia();
                lista = _repositorio.Getlista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvdatos.Rows.Clear();

            foreach (var producto in lista)
            {
                DataGridViewRow fila = new();
                fila.CreateCells(dgvdatos);
                fila.Cells[0].Value = producto.Codigo;
                fila.Cells[1].Value = producto.Nombre;
                fila.Tag = producto;
                dgvdatos.Rows.Add(fila);
            }
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmKioscoAE frm = new FrmKioscoAE() { Text = "Agregar Producto" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            Producto? producto = frm.GetProducto();
            if (producto is null) return;

            try
            {
                if (!_repositorio.Existe(producto))
                {
                    _repositorio.Agregar(producto);
                    AgregarFila(producto);
                    MessageBox.Show("Producto agregado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto duplicado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarFila(Producto producto)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvdatos);
            r.Cells[0].Value = producto.Codigo;
            r.Cells[1].Value = producto.Nombre;
            r.Tag = producto;
            dgvdatos.Rows.Add(r);
        }

        public Producto? GetProducto()
        {
            return producto;
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvdatos.SelectedRows.Count == 0) return;

            DataGridViewRow r = dgvdatos.SelectedRows[0];
            Producto? producto = r.Tag as Producto;
            if (producto is null) return;

            DialogResult dr = MessageBox.Show(
                $"¿Desea borrar el producto {producto.Nombre}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No) return;

            try
            {
                _repositorio.Borrar(producto.Codigo);
                dgvdatos.Rows.Remove(r);

                MessageBox.Show("Producto eliminado", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvdatos.SelectedRows.Count == 0) return;

            DataGridViewRow r = dgvdatos.SelectedRows[0];
            Producto? producto = r.Tag as Producto;
            if (producto == null) return;

            Producto productoEditar = producto.Clonar();
            FrmKioscoAE frm = new FrmKioscoAE() { Text = "Editar Producto" };
            frm.SetProducto(productoEditar);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            productoEditar = frm.GetProducto();
            if (productoEditar == null) return;

            try
            {
                if (!_repositorio.Existe(productoEditar))
                {
                    _repositorio.Guardar(productoEditar);
                    GridHelper.SetearFila(r, productoEditar);
                    MessageBox.Show("Producto editado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto duplicado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
