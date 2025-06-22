using Kisoco.Datos;
using Repositorio.Kiosco;
using System.Security.Cryptography.X509Certificates;

namespace ConsolaKiosco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool seguir = true;
            var servicio = new ProductoServicio();
            do
            {
                Console.Clear();
                Console.WriteLine("Manejo de productos");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Agregar");
                Console.WriteLine("2 - Borrar");
                Console.WriteLine("3 - Editar");
                Console.WriteLine("4 - Listar");
                Console.WriteLine("Ingrese una opcion");
                string? opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        AgregarProducto(servicio);
                        break;
                    case "4":
                        ListarProducto(servicio);
                        break;
                    default:
                        break;
                }
            } while (seguir);
        }

        private static void AgregarProducto(ProductoServicio servicio)
        {
            Console.WriteLine("\n=== AGREGAR NUEVO PRODUCTO ===");
            Console.Write("Seleccione el tipo de producto (1: Bebida, 2: Cigarrillo, 3: Golosina, 4: Revista): ");
            var tipo = Console.ReadLine();

            Producto producto = null;

            switch (tipo)
            {
                case "1":
                    // Agregar Bebida
                    Console.Write("Marca (CocaCola, Pepsi, Sprite, Fanta, AguaMineral, JugoNatural): ");
                    var marcaB = (MarcaB)Enum.Parse(typeof(MarcaB), Console.ReadLine());
                    Console.Write("Litros: ");
                    var litros = int.Parse(Console.ReadLine());
                    Console.Write("¿Es alcohólica? (true/false): ");
                    var esAlcoholica = bool.Parse(Console.ReadLine());
                    producto = new Bebida(marcaB, litros, esAlcoholica);
                    Console.Write("Ingrese el nombre:");
                    string? InputNombre = Console.ReadLine();
                    Console.Write("Ingrese el codigo");
                    string? InputCodigo = Console.ReadLine();
                    Console.Write("Ingrese el precio base");
                    string? InputPrecio = Console.ReadLine();
                    Console.Write("Ingrese la fecha de ingreso");
                    string? InputFecha = Console.ReadLine();
                    Console.Write("Ingrese el stock");
                    string? InputStock = Console.ReadLine();
                    Console.Write("Ingrese la fecha de vencimiento");
                    string? InputFechaVen = Console.ReadLine();
                    Console.Write("Confirma?(s/n)");
                    string? respuesta = Console.ReadLine();
                    if (respuesta?.ToUpper() == "S")
                    {
                        servicio.Guardar(producto);
                        Console.WriteLine("Registro agregado.");
                    }
                    break;

                case "2":
                    // Agregar Cigarrillo
                    Console.Write("Marca (Marlboro, Camel, LuckyStrike, PallMall, Chesterfield): ");
                    var marcaC = (MarcaC)Enum.Parse(typeof(MarcaC), Console.ReadLine());
                    Console.Write("¿Es importado? (true/false): ");
                    var esImportado = bool.Parse(Console.ReadLine());
                    producto = new Cigarrillo(marcaC, esImportado);
                    Console.Write("Ingrese el nombre:");
                    string? InputNombre = Console.ReadLine();
                    Console.Write("Ingrese el codigo");
                    string? InputCodigo = Console.ReadLine();
                    Console.Write("Ingrese el precio base");
                    string? InputPrecio = Console.ReadLine();
                    Console.Write("Ingrese la fecha de ingreso");
                    string? InputFecha = Console.ReadLine();
                    Console.Write("Ingrese el stock");
                    string? InputStock = Console.ReadLine();
                    Console.Write("Ingrese la fecha de vencimiento");
                    string? InputFechaVen = Console.ReadLine();
                    Console.Write("Confirma?(s/n)");
                    string? respuesta = Console.ReadLine();
                   
                    break;

                case "3":
                    // Agregar Golosina
                    Console.Write("Tipo (Caramelo, Chocolate, Galleta, Chicle, Regaliz): ");
                    var tipoG = (TipoGolosina)Enum.Parse(typeof(TipoGolosina), Console.ReadLine());
                    Console.Write("Marca (Chocolate, Caramelo, Chicle): ");
                    var marcaG = (MarcaG)Enum.Parse(typeof(MarcaG), Console.ReadLine());
                    producto = new Golosina(tipoG, marcaG);
                    break;

                case "4":
                    Console.Write("Marca (NationalGeographic, Time, Vogue, RollingStone, ScientificAmerican): ");
                    var marcaR = (MarcaR)Enum.Parse(typeof(MarcaR), Console.ReadLine());
                    Console.Write("Edición: ");
                    var edicion = Console.ReadLine();
                    Console.Write("¿Tiene poster? (true/false): ");
                    var tienePoster = bool.Parse(Console.ReadLine());
                    producto = new Revista(marcaR, edicion, tienePoster);
                    Console.Write("¿Confirma? (s/n): ");
                    var confirmar = Console.ReadLine();
                    if (confirmar?.ToLower() != "s")
                    {
                        servicio.Guardar(producto);
                        Console.WriteLine("Registro agregado.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Registro no agregado.");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("Tipo de producto no válido.");
                    return;
            }


        }

        private static void ListarProducto(ProductoServicio servicio)
        {
            Console.Clear();
            Console.WriteLine("Listado de productos");
            foreach (var producto in servicio.Getlista())
            {
                Console.WriteLine($"Codigo: {producto.Codigo}, Nombre: {producto.Nombre}, PrecioBase: {producto.PrecioBase}, Fecha de ingreso: {producto.fechaIngreso}, Stock: {producto.stock}, Fecha de vencimiento: {producto.fechaVto}");
            }
            Console.WriteLine("<ENTER> para continuar...");
            Console.ReadLine();
        }

        public class ProductoServicio
        {
            private readonly RepositorioProductos _repositorio;
            public ProductoServicio()
            {
                _repositorio = new RepositorioProductos();
            }
            public List<Producto> Getlista()
            {
                return _repositorio.Getlista();
            }
            public void Guardar(Producto producto)
            {
                if (producto.Codigo == 0)
                {
                    _repositorio.Agregar(producto);
                }
            }
        }
    }
}