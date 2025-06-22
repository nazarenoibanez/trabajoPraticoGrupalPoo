using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class Revista:Producto
    {
        public Revista(int codigo, string nombre, double precioBase, DateTime fechaIngreso, int stock, DateTime fechaVto, MarcaR marca, string? edicion, bool tienePoster)
            :base(codigo, nombre, precioBase, fechaIngreso, stock, fechaVto)
        {
            this.marca = marca;
            Edicion = edicion;
            TienePoster = tienePoster;
        }
        

        public MarcaR marca { get; set; }
        public string? Edicion { get; set; }
        public bool TienePoster { get; set; }
    

        public override double CalcularPrecioFinal()
        {
            if (TienePoster)
            {
                return (double)PrecioBase + 300;
            }
            else
            {
                return (double)PrecioBase;
            }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Codigo == 6)
            {
                yield return new ValidationResult("El código 6 está reservado para otro producto.");
            }
            if (PrecioBase < 0)
            {
                yield return new ValidationResult("El precio base no puede ser negativo.");
            }
            if (stock < 0)
            {
                yield return new ValidationResult("El Stock no puede ser negativo");
            }
            if (Nombre is not null)
            {
                yield return new ValidationResult("El nombre no puede ser nulo o vacío.");
            }
            DateTime fechaActual = DateTime.Now.Date;
            if (fechaVto.Date < fechaActual || fechaVto.Date > fechaActual.AddDays(180))
            {
                yield return new ValidationResult("La fecha de vencimiento debe ser igual o posterior a la actual y no superar los 180 días desde hoy.");
            }
        }
    }
}
