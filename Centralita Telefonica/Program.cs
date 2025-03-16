using System;

namespace Centralita_Telefonica
{
    internal class Practica2
    {
        static void Main(string[] args)
        {
            Centralita centralita = new Centralita();
            int opcion;

            do
            {
                Console.WriteLine("\n--- Menú ---\n1.Local\n2.Provincial\n3.Informe\n4.Salir");
                opcion = LeerEntero("Opción: ");

                switch (opcion)
                {
                    case 1:
                    case 2:
                        RegistrarLlamada(centralita, opcion == 1);
                        break;
                    case 3:
                        Console.WriteLine($"\nLlamadas: {centralita.ObtenerTotalLlamadas()}\nTotal: {centralita.ObtenerFacturacionTotal()}");
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 4);
        }

        static void RegistrarLlamada(Centralita centralita, bool esLocal)
        {
            try
            {
                Console.Write("Origen: ");
                string origen = Console.ReadLine();
                Console.Write("Destino: ");
                string destino = Console.ReadLine();
                int duracion = LeerEntero("Duración (s): ");

                if (esLocal)
                {
                    centralita.RegistrarLlamada(new LlamadaLocal(origen, destino, duracion));
                }
                else
                {
                    int franja = LeerFranja("Franja (1-3): ");
                    centralita.RegistrarLlamada(new LlamadaProvincial(origen, destino, duracion, franja));
                }
                Console.WriteLine("Llamada registrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
                Console.Write("Inválido. " + mensaje);
            return valor;
        }

        static int LeerFranja(string mensaje)
        {
            int franja;
            do
            {
                franja = LeerEntero(mensaje);
            } while (franja < 1 || franja > 3);
            return franja;
        }
    }
}
