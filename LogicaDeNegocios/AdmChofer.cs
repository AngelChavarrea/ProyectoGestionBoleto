﻿

using System.Collections.Generic;
using System;

namespace LogicaDeNegocios
{
   
    public class AdmChofer
    {
        Chofer procedimientos = new Chofer();
     
        public bool RegistrarChofer(Chofer chofer)
        {
         Chofer registrar = chofer;
         registrar.InsertarChofer(registrar);
         return true;
        }
   

        public List<Chofer> ConsularChofer(string cedula)
        {
         List<Chofer> lista = new List<Chofer>();
         Chofer chofer = null;
        chofer = Chofer.BuscarChofer(cedula);
         lista.Add(chofer);
           return lista;
        }

        public string Modificar(string cedula, string telefono, string correo, string contrasena)
        {
         return procedimientos.ActualizarChofer(cedula, telefono, correo, contrasena);
        }

        public List<Chofer> ConsultarChofer(string datoVendedor)
        {
            List<Chofer> chofer = null;
            if (String.IsNullOrEmpty(datoVendedor))
            {
                throw new ControlExcepcion("Campo vacio por favor rellenar");
            }
            else
            {
                if (datoVendedor == "Iniciar_data_grid_datos")
                {
                    datoVendedor = "";
                }
                chofer = procedimientos.ConsultarChofer(datoVendedor);

                if (chofer.Count == 0)
                {
                    throw new ControlExcepcion("Vendedor no encontrado");
                }
            }

            return chofer;
        }

        public void EliminarChofer(string cedula)
        {
            if (!Chofer.EliminarChofer(cedula))
            {
                throw new ControlExcepcion("Error al eliminar intetar más tarde");
            }
        }
    }
}
