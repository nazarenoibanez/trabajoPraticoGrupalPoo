using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisoco.Datos
{
public enum MarcaG
    {
        Chocolate,
        Caramelo,
        Chicle,
 
    }
    internal class Golosina
    {
        public Golosina(string nombre, decimal precioBase, DateTime fechaIngreso, int stock, MarcaG marca, DateTime fechaVto, decimal metodoVirtual, decimal precioFinal)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
            FechaIngreso = fechaIngreso;
            Stock = stock;
            this.Marca = marca;
            FechaVto = fechaVto;
            MetodoVirtual = metodoVirtual;
            PrecioFinal = precioFinal;
        }

        //falta el codigo virtual
        public string Nombre { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Stock { get; set; }
        public MarcaG Marca { get; set; }
        public DateTime FechaVto { get; set; }
        public decimal MetodoVirtual { get; set; }
        public decimal PrecioFinal { get; set; }
        public decimal CalcularPrecioFinal()
        {
            if (Marca is MarcaG.Chocolate)
            {
                return PrecioBase + 200;
            }
            else
            {
                return PrecioBase;
            }
        }

    }
}
