using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Centralita_Telefonica
{
    public abstract class Llamada
    { 
        public string numOrigen { get; }
        public string numDestino { get; }
        public double Duracion { get; }

        protected Llamada(string origen, string destino, double duracion)
        {
            numOrigen = origen;
            numDestino = destino;
            Duracion = duracion;
        }

        public abstract double calcularPrecio();

        public override string ToString()
        {
            return $"De '{numOrigen}' al '{numDestino}', duraron {Duracion} segundos.";
        
        }
    }

    public class LlamadaLocal : Llamada 
    {
        private const double precioPorSegundo = 0.15;

        public LlamadaLocal(string origen, string destino, int duracion) : base(origen, destino, duracion)
        {
        //usar los elementos en base
        }

        public override double calcularPrecio()
        {
            return Duracion * precioPorSegundo;
        }

        public override string ToString()
        {
            return $"[Local] {base.ToString()}, costo:{calcularPrecio()}";
        }

    }

    public class LlamadaProvincial : Llamada 
    {
        private static readonly double[] precioPorFranja = { 0.20,0.25,0.30 };
               //readonly significa "solo leer"
        private readonly int Franja;

        public override double calcularPrecio()
        {
            return Duracion * precioPorFranja[Franja-1];
        }

        public LlamadaProvincial(string origen, string destino, int duracion, int franja) : base(origen, destino, duracion)
        {
            if (franja < 1 || franja > 3)
            {
                Console.WriteLine("La franja debe ser 1, 2 o 3");
            }
            Franja = franja;

        }

        public override string ToString()
        {
            return $"[Provincial] {base.ToString()}, Franja: {Franja}, costo:{calcularPrecio()}";
        }
    }



}
