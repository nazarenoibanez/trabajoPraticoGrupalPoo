using Kisoco.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Kiosco
{
    public class RepositorioProductos
    {
        private List<Producto> _productos;
        public static RepositorioProductos? Instancia = null!;

        public static RepositorioProductos GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new RepositorioProductos();
            }
            return Instancia;
        }
        public Producto this[int index]
        {
            get
            {
                if (index < 0 || index >= _productos.Count)
                {
                    return _productos[index];
                }
                throw new ArgumentOutOfRangeException(nameof(index), "Índice fuera de rango.");

            }
            set { _productos[index] = value; }
        }
        public RepositorioProductos()
        {
            _productos = new List<Producto>();
        }
        public bool Agregar(Producto producto)
        {
            if (_productos.Contains(producto))
            {
                _productos.Add(producto);
                return true;
            }
            return false;
        }
        public bool Eliminar(Producto producto)
        {
            if (_productos.Contains(producto))
            {
                _productos.Remove(producto);
                return true;
            }
            return false;
        }
        public bool BuscarporNombre(string nombre, out Producto producto)
        {
            producto = _productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return producto != null;
        }
        public bool OrdenarPorPrecioFinal()
        {
            if (_productos.Count > 0)
            {
                _productos = _productos.OrderBy(p => p.CalcularPrecioFinal()).ToList();
                return true;
            }
            return false;
        }
        public bool listarPorStockBajo(int stockMinimo)
        {
            var productosFiltrados = _productos.Where(p => p.stock < stockMinimo).ToList();
            if (productosFiltrados.Count > 0)
            {
                _productos = productosFiltrados;
                return true;
            }
            return false;
        }


        public List<Producto> Getlista()
        {
            return _productos;
        }
    }
}
