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
    public class Bebida
    {
        public Bebida(string nombre, decimal precioBase, DateTime fechaIngreso, int stock, MarcaB marca, DateTime fechaVto, decimal metodoVirtual, int litros, bool esAlcoholica, decimal precioFinal)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
            FechaIngreso = fechaIngreso;
            Stock = stock;
            this.marca = marca;
            MetodoVirtual= metodoVirtual;
            FechaVto = fechaVto;
            Litros = litros;
            EsAlcoholica = esAlcoholica;
            PrecioFinal = precioFinal;
        }

        //falta el codigo virtual
        public string Nombre { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Stock { get; set; }
        public MarcaB marca { get; set; }
        public DateTime FechaVto { get; set; }
        public decimal MetodoVirtual  { get; set; }
        public int Litros { get; set; }
        public bool EsAlcoholica { get; set; }
        public decimal PrecioFinal { get; set; }

        public decimal CalcularPrecioFinal()
        {
            if (EsAlcoholica)
            {
               return PrecioBase+200+(Litros*100)+500;
            }
            else
            {
                return PrecioBase + 200 + (Litros * 100);
            }
        }
    }
}
    