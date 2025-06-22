using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisoco.Datos
{
    public abstract class Producto : IValidatableObject
    {
        protected Producto(int codigo, string nombre, double precioBase, DateTime fechaIngreso, int stock, DateTime fechaVto)
        {
            if (codigo == 0)
            {
                throw new ArgumentException("El código no puede ser cero.", nameof(codigo));
            }
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            }
            if (precioBase < 0)
            {
                throw new ArgumentException("El precio base no puede ser negativo.", nameof(precioBase));
            }
            if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.", nameof(stock));
            }
            if (fechaVto < DateTime.Now.Date || fechaVto > DateTime.Now.AddDays(180).Date)
            {
                throw new ArgumentException("La fecha de vencimiento debe estar entre hoy y 180 días a partir de hoy.",nameof(fechaVto));
            }
            Codigo = codigo;
            Nombre = nombre;
            PrecioBase = precioBase;
            this.fechaIngreso = fechaIngreso;
            this.stock = stock;
            this.fechaVto = fechaVto;
        }
        public int Codigo { get; protected set; }
        public string Nombre { get; protected set; } = null!;
        public double PrecioBase { get; protected set; }
        public DateTime fechaIngreso { get; protected set; }
        public int stock { get; protected set; }
        public DateTime fechaVto { get; protected set; }

        public abstract double CalcularPrecioFinal();

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
       
    }
}
