using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    internal class Cigarrillo : Producto
    {
        public Cigarrillo(MarcaC marca, bool esImportado): base(6, "Cigarrillo", 500, DateTime.Now, 20, DateTime.Now.AddDays(180))
        {
            this.marca = marca;
            EsImportado = esImportado;
        }

        public MarcaC marca { get; set; }

        public bool EsImportado { get; set; }


      
        

        public override double CalcularPrecioFinal()
        {
            if (EsImportado)
            {
                return (double)PrecioBase + 1000;
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
