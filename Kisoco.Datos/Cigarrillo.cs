using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisoco.Datos
{
    public enum MarcaC
    {
        Marlboro,
        Camel,
        LuckyStrike,
        PallMall,
        Chesterfield
    }
    internal class Cigarrillo
    {
        public Cigarrillo(string nombre, decimal precioBase, DateTime fechaIngreso, int stock, MarcaC marca, DateTime fechaVto, decimal metodoVirtual, bool esImportado, decimal precioFinal)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
            FechaIngreso = fechaIngreso;
            Stock = stock;
            this.marca = marca;
            FechaVto = fechaVto;
            MetodoVirtual = metodoVirtual;
            EsImportado = esImportado;
            PrecioFinal = precioFinal;
        }

        //falta el codigo virtual
        public string Nombre { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Stock { get; set; }
        public MarcaC marca { get; set; }
        public DateTime FechaVto { get; set; }
        public decimal MetodoVirtual { get; set; }
        //Falta cantidadPorAtado
        public bool EsImportado { get; set; }
        public decimal PrecioFinal { get; set; }

        public decimal CalcularPrecioFinal()
        {
            if (EsImportado)
            {
                return PrecioBase + 1000;
            }
            else
            {
                return PrecioBase;
            }
        }
    }
}
