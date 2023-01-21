
using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{

    public class CredencialUsuario 
    {

        private string correo;

        private string contrasena;

        private int rol;

        public CredencialUsuario() { }

        public CredencialUsuario(string correo, string contrasena, int rol)
        {
            this.correo = correo;
            this.contrasena = contrasena;
            this.rol = rol;
        }

        public string Correo { get => correo; set => correo = value; }

        public string Contrasena { get => contrasena; set => contrasena = value; }

        public int Rol { get => rol; set => rol = value; }
    }
}
