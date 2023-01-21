using System;
using System.Collections.Generic;
namespace LogicaDeNegocios
{
    public class AdmRuta
    {
        Ruta procedimientos = new Ruta();
      
        public bool RegistrarRuta(Ruta ruta)
        {
            Ruta registrar = ruta;
            registrar.InsertarRuta(registrar);
            return true;
        }
    }
}
