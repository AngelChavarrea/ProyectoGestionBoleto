
using System;
namespace LogicaDeNegocios
{

    public class ControlExcepcion : Exception
    {

        String message =null;

        public ControlExcepcion(String message) : base(message)
        {
            Console.WriteLine(this.message);
        }
    }
}
