﻿
using Datos;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogicaDeNegocios
{

    public class Cliente: Persona
    {

        private CredencialUsuario credencialUsuario;
        public Cliente() 
        { }

        public Cliente(string cedula, string nombre, string sexo, string telefono, CredencialUsuario credencialUsuario) : base(cedula, nombre, sexo, telefono)
        {         
            this.credencialUsuario = credencialUsuario;
        }


        public CredencialUsuario CredencialUsuario { get => credencialUsuario; set => credencialUsuario = value; }


        public void InsertarCliente(Cliente client)
            {
               
                Conexion con = new Conexion();
               
                ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
                try
                {
                    List<Cliente> ListaNueva = new List<Cliente>();
                    ListaNueva.Add(client);
                    MySqlCommand mySqlCommand = conector.ConectarProcedimiento("RegistroClienteGeneral", con.conectar());
                     foreach (Cliente Cliente in ListaNueva)
                     {
                        mySqlCommand.Parameters.AddWithValue("@CedulaFx", Cliente.Cedula);
                        mySqlCommand.Parameters.AddWithValue("@NombreFx", Cliente.Nombre);
                        mySqlCommand.Parameters.AddWithValue("@SexoFx", Cliente.Sexo);
                        mySqlCommand.Parameters.AddWithValue("@TelefonoFx", Cliente.Telefono);
                        mySqlCommand.Parameters.AddWithValue("@CorreoFx", Cliente.CredencialUsuario.Correo);
                        mySqlCommand.Parameters.AddWithValue("@ContrasenaFx", Cliente.CredencialUsuario.Contrasena);
                        mySqlCommand.Parameters.AddWithValue("@Foreking_RolesUsuarioFx", Cliente.CredencialUsuario.Rol);
                    }
                     mySqlCommand.ExecuteReader();
                     con.cerrar();
                }
                catch (MySqlException ex)
                {

                    Console.WriteLine(ex);
                }

            }

        internal static bool EliminarCliente(string cedula)
        {
            bool x = false;
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("EliminarCliente", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@CedulaFx", cedula);
                mySqlCommand.ExecuteNonQuery();
                x = true;
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: " + ex);
            }
            return x;
        }

   
        public static Cliente BuscarClient(string cedula)
        {

            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            Cliente client = null;
            CredencialUsuario credencial = null;
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_BuscarCliente", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@Cedula", cedula);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    credencial = new CredencialUsuario(lector["Correo"].ToString(), lector["Contrasena"].ToString(), 3);
                    client = new Cliente(lector["Cedula"].ToString(), lector["Nombre"].ToString(), lector["Sexo"].ToString(), lector["Telefono"].ToString(), credencial);
                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: " + ex);
            }
            return client;
        }

        public List<Cliente> BuscarCliente(string Dato)
        {
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            Cliente client = null;
            CredencialUsuario credencial = null;
            List<Cliente> ListCliente = new List<Cliente>();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("ConsultarCliente", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@DatoFx", Dato);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    credencial = new CredencialUsuario(lector["Correo"].ToString(), lector["Contrasena"].ToString(), 0);
                    client = new Cliente(lector["Cedula"].ToString(), lector["Nombre"].ToString(), lector["Sexo"].ToString(), lector["Telefono"].ToString(), credencial);
                    ListCliente.Add(client);
                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: "+ex);
            }
             return ListCliente;
        }
  
        public string ActualizarCliente(string cedula, string telefono, string correo, string contrasena)
        {
            string mensaje = "";
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();

            try
            {
                MySqlCommand comando = conector.ConectarProcedimiento("spl_ModificarCliente", con.conectar());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Cedula1", cedula);
                comando.Parameters.AddWithValue("@Telefono1", telefono);
                comando.Parameters.AddWithValue("@Correo1", correo);
                comando.Parameters.AddWithValue("@Contraseña1", contrasena);
                comando.ExecuteNonQuery();
                con.cerrar();
                mensaje = "Se actualizaron los campos correctamente";
            }
            catch (MySqlException ex)
            {

                mensaje = "Se ha producido un error al actualizar los datos" + ex;
            }
            return mensaje;
        }
    
    }
}
