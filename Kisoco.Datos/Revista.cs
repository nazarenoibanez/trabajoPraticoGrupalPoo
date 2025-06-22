using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisoco.Datos
{
    public enum MarcaR
    {
        NationalGeographic,
        Time,
        Vogue,
        RollingStone,
        ScientificAmerican
    }
    internal class Revista
    {
        public Revista(string nombre, decimal precioBase, DateTime fechaIngreso, int stock, MarcaR marca, DateTime fechaVto, decimal metodoVirtual, string? edicion, bool tienePoster, decimal precioFinal)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
            FechaIngreso = fechaIngreso;
            Stock = stock;
            this.marca = marca;
            FechaVto = fechaVto;
            MetodoVirtual = metodoVirtual;
            Edicion = edicion;
            TienePoster = tienePoster;
            PrecioFinal = precioFinal;
        }

        //falta el codigo virtual
        public string Nombre { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Stock { get; set; }
        public MarcaR marca { get; set; }
        public DateTime FechaVto { get; set; }
        public decimal MetodoVirtual { get; set; }
        public string? Edicion { get; set; }
        public bool TienePoster { get; set; }
        public decimal PrecioFinal { get; set; }
        public decimal CalcularPrecioFinal()
        {
            if (TienePoster)
            {
                return PrecioBase +300;
            }
            else
            {
                return PrecioBase;
            }
        }
    }
}
