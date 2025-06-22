using System.Text.RegularExpressions;

namespace utilidad
{
    public static class ExtensionUtlidades
    {
        public static string PedirString(string mensajePantalla, bool esRequerido = true)
        {
            string? texto;
            do
            {
                Console.Write(mensajePantalla);
                texto = Console.ReadLine();
                if (!string.IsNullOrEmpty(texto) && esRequerido)
                {
                    return texto;
                }
                Console.WriteLine("El dato es requerido...Reintentar");
                Console.ReadLine();
            } while (true);

        }

        public static int PedirEntero(string mensaje, int min = int.MinValue,
            int max = int.MaxValue)
        {
            string? textoEntero;
            do
            {
                textoEntero = PedirString(mensaje);
                if (int.TryParse(textoEntero, out int entero)
                    && entero >= min && entero <= max)
                {
                    return entero;
                }
                Console.WriteLine("No válido o fuera del rango permitido...Reintentar");
                Console.ReadLine();
            } while (true);

        }

        public static string PedirTextoConFormato(string mensaje,
            List<string> formatos, string error)
        {
            string? texto;
            do
            {
                texto = PedirString(mensaje);

                foreach (var formato in formatos)
                {
                    if (Regex.IsMatch(texto, formato))
                    {
                        return texto.Trim();
                    }
                }
                Console.WriteLine(error);
                Console.ReadLine();
            } while (true);

        }

        public static string PedirPatente(string mensaje)
        {
            string? patente;
            do
            {
                patente = PedirString(mensaje);
                string formato1 = @"^[A-Z]{3} \d{3}$";
                string formato2 = @"^[A-Z]{2} \d{3} [A-Z]{2}$";
                if (Regex.IsMatch(patente!, formato1) || Regex.IsMatch(patente!, formato2))
                {
                    return patente;
                }
                Console.WriteLine("Formato de patente no válido... Reintentar");
                Console.ReadLine();
            } while (true);

        }

        public static bool ConfirmarDatos(string mensaje)
        {
            string respuesta;
            do
            {
                respuesta = PedirString(mensaje);
                if (respuesta.Trim().ToLower() == "s")
                {
                    return true;
                }
                else if (respuesta.Trim().ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Opción ingresada no válida!!!");
                }
            } while (true);

        }
        public static T SeleccionarEnum<T>(string mensajeLista, string mensajePantalla)
        {
            do
            {
                Console.WriteLine(mensajeLista);
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }
                Console.Write(mensajePantalla);
                var input = Console.ReadLine();
                if (int.TryParse(input, out int valorEnum) && Enum.IsDefined(typeof(T), valorEnum))
                {
                    return (T)Enum.ToObject(typeof(T), valorEnum);
                }

                Console.WriteLine("Valor fuera del rango... Reintentar");
                Console.ReadLine();
            } while (true);

        }

        public static double PedirDouble(string mensaje, double min = double.MinValue,
            double max = double.MaxValue)
        {
            string? textoDouble;
            do
            {
                textoDouble = PedirString(mensaje);
                if (double.TryParse(textoDouble, out double doble)
                    && doble >= min && doble <= max)
                {
                    return doble;
                }
                Console.WriteLine("No válido o fuera del rango permitido...Reintentar");
                Console.ReadLine();
            } while (true);

        }
        public static bool PreguntarSiContinuar(string mensaje)
        {
            Console.Write(mensaje + " (s/n): ");
            string respuesta = Console.ReadLine()?.ToLower();
            return respuesta == "s";
        }
    }
}
