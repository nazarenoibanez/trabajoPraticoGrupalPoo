using System.ComponentModel.DataAnnotations;

namespace Kisoco.Datos
{
    public enum MarcaB
    {
        CocaCola,
        Pepsi,
        Sprite,
        Fanta,
        AguaMineral,
        JugoNatural
    }
    public class Bebida: Producto
    {
        public Bebida(MarcaB marca, int litros, bool esAlcoholica):base(6, "Bebida", 1000, DateTime.Now, 10, DateTime.Now.AddDays(180))
        {
            this.marca = marca;
            Litros = litros;
            EsAlcoholica = esAlcoholica;
        }

        public MarcaB marca { get; set; }
  
        public int Litros { get; set; }
        public bool EsAlcoholica { get; set; }

        
        public override double CalcularPrecioFinal()
        {
            if (EsAlcoholica)
            {
                return (double)PrecioBase + 200 + (Litros * 100) + 500;
            }
            else
            {
                return (double)PrecioBase + 200 + (Litros * 100);
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
    