using Kisoco.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Kiosco
{
    public class RepositorioSobrecargaProductos
    {
        private List<Producto> _productosSobrecarga = new();
        public static RepositorioSobrecargaProductos? Instancia = null!;

        public static RepositorioSobrecargaProductos GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new RepositorioSobrecargaProductos();
            }
            return Instancia;
        }
        public RepositorioSobrecargaProductos()
        {

        }
        public Producto this[int index]
        {
            get
            {
                if (index < 0 || index >= _productosSobrecarga.Count)
                {
                    return _productosSobrecarga[index];
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }

        }

        public static bool operator +(RepositorioSobrecargaProductos repo, Producto producto)
        {
            if (!repo._productosSobrecarga!.Contains(producto))
            {
                repo._productosSobrecarga.Add(producto);
                return true;
            }
            return false;
        }
        public static bool operator -(Producto producto, RepositorioSobrecargaProductos repo)
        {
            if (!repo._productosSobrecarga!.Contains(producto))
            {
                repo._productosSobrecarga.Remove(producto);
                return true;
            }
            return false;
        }
        public List<Producto> GetLista()
        {
            return _productosSobrecarga;
        }
        public static bool operator ==(RepositorioSobrecargaProductos repo, Producto producto)
        {
            return repo._productosSobrecarga.Contains(producto);
        }
        public static bool operator !=(RepositorioSobrecargaProductos repo, Producto producto)
        {
            return !(!repo._productosSobrecarga!.Contains(producto));
        }

        public static string mostrarTodo(RepositorioSobrecargaProductos repo)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in repo._productosSobrecarga)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }

}
