using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{
   public class AdmPago
    {
     
        public double calcularTotalPagar(List<double> precio)
        {
            double totalPagar = 0;
            foreach(double p in precio)
            {
                totalPagar += p;
            }
            return totalPagar;
        }
    }
}
