using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public enum TipoGolosina
    {
        Caramelo,
        Chocolate,
        Galleta,
        Chicle,
        Regaliz
    }
    public class Golosina: Producto
    {
        public Golosina(TipoGolosina tipo, MarcaG marca): base(6, "Golosina", 500, DateTime.Now, 50, DateTime.Now.AddDays(180))
        {
            Tipo = tipo;
            Marca = marca;
        }

        public TipoGolosina Tipo { get; set; }
        public MarcaG Marca { get; set; }
        
        

        public override double CalcularPrecioFinal()
        {
            if (Marca is MarcaG.Chocolate)
            {
                return (double)PrecioBase + 200;
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
