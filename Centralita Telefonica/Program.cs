
using Centralita_Telefonica;
using System.Timers;

internal class Practica2
{

    static void Main(string[] args)
    { 
    
     Centralita centralita = new Centralita();

        Console.Write("Ingresa el numero de origen:");
        string origen = Console.ReadLine();
        Console.Write("Ingresa el numero de destino:");
        string destino = Console.ReadLine();
        Console.Write("Ingresa la duracion de la llamada(en segundos)");
        int duracion = int.Parse(Console.ReadLine());
        Console.Write("Ingresa 1 si la llamada es local o 2 si es provincial");
        int franja = int.Parse(Console.ReadLine());

        centralita.RegistrarLlamada(new LlamadaLocal(origen, destino, duracion));

        if (franja > 0 || franja < 4) 
        {
            centralita.RegistrarLlamada(new LlamadaProvincial(origen,destino,duracion,franja));

        }
        else
        {
            Console.WriteLine("La franja horaria ingresada no es valida");
        }

        Console.WriteLine("\n\n--- Reporte ---");
        Console.WriteLine($"Total de llamadas: {centralita.ObtenerTotalLlamadas()}");
        Console.WriteLine($"Facturacion total: {centralita.ObtenerFacturacionTotal()}");

    }






}