
using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{
   
    public class AdmClienteProcedimiento
    {
     
        Cliente _procedimientos = new Cliente();
     
        public bool RegistrarCliente(Cliente cliente)
        {
            Cliente clienteregistrar = cliente;
            clienteregistrar.InsertarCliente(clienteregistrar);
            return true;
        }

 
        public string Modificar(string cedula, string telefono, string correo, string contrasena)
        {
            return _procedimientos.ActualizarCliente(cedula, telefono, correo, contrasena);
        }

     
       public List<Cliente> ConsultarCliente(string Dato )
        {
            List<Cliente> client = null;
            if (String.IsNullOrEmpty(Dato))
            {
                throw new ControlExcepcion("Campo vacio por favor rellenar");
            }
            else
            {
                if (Dato == "Iniciar_data_grid_datos")
                {
                    Dato = "";
                }
                client = _procedimientos.BuscarCliente(Dato);

                if (client.Count == 0)
                {
                    throw new ControlExcepcion("Cliente no encontrado");
                }
            }
            
            return client;
        }

        public List<Cliente> ConsultaClient(string cedula)
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente client = Cliente.BuscarClient(cedula);
            lista.Add(client);
            return lista;
        }

        public void EliminarCliente(string cedula)
        {
            if (!Cliente.EliminarCliente(cedula))
            {
                throw new ControlExcepcion("Error al eliminar intetar más tarde");
            }
        }
    }
}
