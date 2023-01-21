
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace LogicaDeNegocios
{
  
    public class Validacion
    {

        public bool ValidarCedula(string cedula)
        {
            bool x = true;
            if (cedula.Length != 10)
            {
                x = false;
            }
            return x;
        }


        public bool ValidarTelefono(string telefono)
        {
            bool campo = true;
            if (telefono.Length != 10)
            {
                campo = false;
            }
            return campo;
        }

        public bool ValidarLicencia(string licencia)
        {
            bool campo = true;
            if (licencia.Length != 10)
            {
                campo = false;
            }
            return campo;
        }

        public bool ValidarCodAcceso(string codAcceso)
        {
            bool campo = true;
            if (codAcceso.Length != 10)
            {
                campo = false;
            }
            return campo;
        }

        public bool validarEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email) )
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool ValidarSueldo(string sueldo)
        {
            bool bandera = true;
            double valor = 0.0;
            try
            {
                valor = Double.Parse(sueldo);
                
            }catch(FormatException ex)
            {
                bandera = false;
                MessageBox.Show(ex.Message); 
            }
            return bandera;
        }
    }
}
