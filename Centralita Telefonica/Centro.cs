using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralita_Telefonica
{
    public class Centralita
    {

        private int _totalLlamadas = 0;
        private double _totalFacturacion = 0;

        public void RegistrarLlamada(Llamada llamada)
        {

            _totalLlamadas++;
            _totalFacturacion += llamada.calcularPrecio();
            Console.WriteLine(llamada.ToString());

        }

        public int ObtenerTotalLlamadas() 
        {

            return _totalLlamadas;
        
        }

        public double ObtenerFacturacionTotal()
        {
            return _totalFacturacion;

        }
    }

    
   

}
