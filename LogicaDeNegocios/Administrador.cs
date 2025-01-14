﻿
using Datos;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{
  
    public class Administrador: Persona
    {
      
        private string _codigoAcceso;
        private double _sueldo;
        private CredencialUsuario _credencialUsuario;
 
        public Administrador(string cedula, string nombre, string sexo, string telefono, string codigoAcceso, double sueldo, CredencialUsuario credencialUsuario):base(cedula, nombre, sexo, telefono)
        {
            this._codigoAcceso = codigoAcceso;
            this._sueldo = sueldo;
            this._credencialUsuario = credencialUsuario;
        }
        public Administrador() { }
   
        public CredencialUsuario CredencialUsuario { get => _credencialUsuario; set => _credencialUsuario = value; }
        public string CodigoAcceso { get => _codigoAcceso; set => _codigoAcceso = value; }
        public double Sueldo { get => _sueldo; set => _sueldo = value; }

   
        public static Administrador ConsultarAdministrador(int id)
        {
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            Administrador admin = null;
            CredencialUsuario credencial = null;
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("BuscarAdministrador", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@IdPersona", id);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    credencial = new CredencialUsuario(lector["Correo"].ToString(), lector["Contrasena"].ToString(), 0);
                    admin = new Administrador(lector["Cedula"].ToString(), lector["Nombre"].ToString(), lector["Sexo"].ToString(), lector["Telefono"].ToString(), lector["CodAcceso"].ToString(), Convert.ToDouble(lector["Sueldo"].ToString()), credencial);                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            return admin;
        }
        
        public void InsertarAdministrador(Administrador admin)
        {
           
            Conexion con = new Conexion();
          
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                List<Administrador> listaNueva = new List<Administrador>();
                listaNueva.Add(admin);
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_insertarAdministrador", con.conectar());
                foreach (Administrador Admin in listaNueva)
                {
                    mySqlCommand.Parameters.AddWithValue("@CedulaFx", Admin.Cedula);
                    mySqlCommand.Parameters.AddWithValue("@NombreFx", Admin.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@SexoFx", Admin.Sexo);
                    mySqlCommand.Parameters.AddWithValue("@TelefonoFx", Admin.Telefono);
                    mySqlCommand.Parameters.AddWithValue("@CodAccesoFx", Admin.CodigoAcceso);
                    mySqlCommand.Parameters.AddWithValue("@SueldoFx", Admin.Sueldo);
                    mySqlCommand.Parameters.AddWithValue("@CorreoFx", Admin.CredencialUsuario.Correo);
                    mySqlCommand.Parameters.AddWithValue("@ContrasenaFx", Admin.CredencialUsuario.Contrasena);
                    mySqlCommand.Parameters.AddWithValue("@Foreking_RolesUsuarioFx", Admin.CredencialUsuario.Rol);

                }
                mySqlCommand.ExecuteReader();
                con.cerrar();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex);
            }

        }

     
        public string ActualizarAdministrador(string cedula, string telefono, string correo, string contrasena)
        {
            string mensaje = "";
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();

            try
            {
                MySqlCommand comando = conector.ConectarProcedimiento("spl_ModificarAdministrador", con.conectar());
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
