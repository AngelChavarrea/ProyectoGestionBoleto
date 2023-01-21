
using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{
  
    public class AdmAdministrador
    {
                Administrador _admin = new Administrador();
        public bool RegistrarAdministrador(Administrador admin)
        {
        Administrador registrar = admin;
        registrar.InsertarAdministrador(registrar);
        return true;
        }
      
        public List<Administrador> ConsultaAdmin(int id)
        {
        List<Administrador> newLista = new List<Administrador>();
         Administrador admin = null;
         admin = Administrador.ConsultarAdministrador(id);
         newLista.Add(admin);
         return newLista;
        }

        public string Modificar(string cedula, string telefono, string correo, string contrasena)
        {
        return _admin.ActualizarAdministrador(cedula, telefono, correo, contrasena);
        }
    }
}
