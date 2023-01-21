
using System;
using Datos;
using MySqlConnector;
using System.Collections.Generic;

namespace LogicaDeNegocios
{
   
    public class Chofer:Persona
    {
 
        private string licencia;

        private double sueldo;

        private CredencialUsuario credencialUsuario;


        public Chofer() { }

        public Chofer(string cedula, string nombre, string sexo, string telefono, string licencia, double sueldo, CredencialUsuario credencialUsuario)
            :base(cedula, nombre, sexo, telefono)
        {
            this.licencia = licencia;
            this.sueldo = sueldo;
            this.credencialUsuario = credencialUsuario;
        }

        public string Licencia { get => licencia; set => licencia = value; }

        public double Sueldo { get => sueldo; set => sueldo = value; }

        internal List<Chofer> ConsultarChofer(string datoVendedor)
        {
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            Chofer chofer = null;
            CredencialUsuario credencial = null;
            List<Chofer> ListChofer = new List<Chofer>();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("ConsultarChofer", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@DatoFx", datoVendedor);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    credencial = new CredencialUsuario(lector["Correo"].ToString(), lector["Contrasena"].ToString(), 0);
                    chofer = new Chofer(lector["Cedula"].ToString(), lector["Nombre"].ToString(), lector["Sexo"].ToString(), lector["Telefono"].ToString(),"A", 420, credencial);
                    ListChofer.Add(chofer);
                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: " + ex);
            }
            return ListChofer;
        }

        internal static bool EliminarChofer(string cedula)
        {
            bool x = false;
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("EliminarChofer", con.conectar());
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

        public CredencialUsuario CredencialUsuario { get => credencialUsuario; set => credencialUsuario = value; }

        public void InsertarChofer(Chofer chofer)
        {
           
            Conexion con = new Conexion();
           
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                List<Chofer> ListaNueva = new List<Chofer>();
                ListaNueva.Add(chofer);
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_insertarChofer", con.conectar());
                foreach (Chofer Chofer in ListaNueva)
                {
                    mySqlCommand.Parameters.AddWithValue("@CedulaFx", Chofer.Cedula);
                    mySqlCommand.Parameters.AddWithValue("@NombreFx", Chofer.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@SexoFx", Chofer.Sexo);
                    mySqlCommand.Parameters.AddWithValue("@TelefonoFx", Chofer.Telefono);
                    mySqlCommand.Parameters.AddWithValue("@Licencia", Chofer.Licencia);
                    mySqlCommand.Parameters.AddWithValue("@SueldoFx", Chofer.Sueldo);
                    mySqlCommand.Parameters.AddWithValue("@CorreoFx", Chofer.CredencialUsuario.Correo);
                    mySqlCommand.Parameters.AddWithValue("@ContrasenaFx", Chofer.CredencialUsuario.Contrasena);
                    mySqlCommand.Parameters.AddWithValue("@Foreking_RolesUsuarioFx", Chofer.CredencialUsuario.Rol);

                }
                mySqlCommand.ExecuteReader();
                con.cerrar();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex);
            }

        }


        public static Chofer BuscarChofer(string cedula)
        {

            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            Chofer chofer = null;
            CredencialUsuario credencial = null;
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_BuscarChofer", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@Cedula", cedula);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    credencial = new CredencialUsuario(lector["Correo"].ToString(), lector["Contrasena"].ToString(), 3);
                    chofer = new Chofer(lector["Cedula"].ToString(), lector["Nombre"].ToString(), lector["Sexo"].ToString(), lector["Telefono"].ToString(), lector["Licencia"].ToString(), Convert.ToDouble(lector["Sueldo"].ToString()), credencial);
                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: " + ex);
            }
            return chofer;
        }


        public string ActualizarChofer(string cedula, string telefono, string correo, string contrasena)
        {
            string mensaje = "";
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();

            try
            {
                MySqlCommand comando = conector.ConectarProcedimiento("spl_ModificarChofer", con.conectar());
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
