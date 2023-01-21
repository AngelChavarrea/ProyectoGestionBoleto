
using Datos;
using Guna.UI2.WinForms;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{

    public class Cooperativa
    {

        private string propietario;

        private string nombreCooperativa;

        private string ruc;

        private string telefono;

        private CredencialUsuario credencialUsuario;

        public Cooperativa(string ruc, string propietario, string nombreCooperativa, string telefono, CredencialUsuario credencialUsuario)
        {
            this.propietario = propietario;
           this.nombreCooperativa = nombreCooperativa;
            this.ruc = ruc;
            this.telefono = telefono;
            this.credencialUsuario = credencialUsuario;
        }
        public Cooperativa() { }

        public string Propietario { get => propietario; set => propietario = value; }

        public string NombreCooperativa { get => nombreCooperativa; set => nombreCooperativa = value; }

        internal void LLenarCombos(int idCooperativa, Guna2ComboBox combo,int x)
        {
           Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            if (x != 0)
            {
                Console.WriteLine("KKKKK"+x);
                try
                {
                    Console.WriteLine(idCooperativa + "" + x);
                    MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_Buscarbus", con.conectar());
                    mySqlCommand.Parameters.AddWithValue("@idCooperativa", idCooperativa);
                    mySqlCommand.Parameters.AddWithValue("@idRuta", x);
                    MySqlDataReader lector = mySqlCommand.ExecuteReader();
                    while (lector.Read())
                    {
                        Console.WriteLine("jjjjjjjjjjjjjjjjjjjjjjjj");
                        string anexar = lector["Placa"].ToString();
                        combo.Items.Add(anexar);
                        ;
                        ;
                    }
                    con.cerrar();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error emitido por: " + ex);
                }
            }
            else
            {
                try
                {
                    MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_BuscarRutA", con.conectar());
                    mySqlCommand.Parameters.AddWithValue("@idCooperativa", idCooperativa);
                    MySqlDataReader lector = mySqlCommand.ExecuteReader();
                    while (lector.Read())
                    {
                        string anexar = lector["idRuta"].ToString() + ")  De: " + lector["Salida"].ToString() + "  A: " + lector["Destino"].ToString(); ;
                        combo.Items.Add(anexar);
                    }
                    con.cerrar();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error emitido por: " + ex);
                }
            }
            
            
        }
 
        internal static List<string> buscarCoop(string v)
        {
            List<string> lista = new List<string>();
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("BuscarCoop", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@Dato", v);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(lector["id"].ToString());
                    lista.Add(lector["cooperativa"].ToString());
                    lista.Add(lector["Nombre"].ToString());
                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {            
                Console.WriteLine(ex);
            }
            return lista;
        }

        internal bool GenerarBOleto(int first, string placaBus, string fecha, string hora, string precio)
        {
            bool validar = true;
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("InsertarRuta", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@idRuta", first) ;
                mySqlCommand.Parameters.AddWithValue("@placas", placaBus);
                mySqlCommand.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha));
                mySqlCommand.Parameters.AddWithValue("@hora",hora);
                mySqlCommand.Parameters.AddWithValue("@Precios", Convert.ToDouble(precio));
                mySqlCommand.ExecuteReader();
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                validar = false;
                Console.WriteLine(ex);
            }
            Conexion cone = new Conexion();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("IngresarAsientos", cone.conectar());
                mySqlCommand.Parameters.AddWithValue("@placas", placaBus);
                mySqlCommand.ExecuteReader();
                cone.cerrar();
            }
            catch (MySqlException ex)
            {
                validar = false;
                Console.WriteLine(ex);
            }
            return validar;
        }

        public string Ruc { get => ruc; set => ruc = value; }

        public string Telefono { get => telefono; set => telefono = value; }

        public CredencialUsuario CredencialUsuario { get => credencialUsuario; set => credencialUsuario = value; }

        public void InsertarCooperativa(Cooperativa cooperativa)
        {
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                List<Cooperativa> lista = new List<Cooperativa>();
                lista.Add(cooperativa);
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_insertarCooperativa", con.conectar());
                foreach (Cooperativa Coop in lista)
                {
                    mySqlCommand.Parameters.AddWithValue("@Ruc", Coop.Ruc);
                    mySqlCommand.Parameters.AddWithValue("@Propietario", Coop.Propietario);
                    mySqlCommand.Parameters.AddWithValue("@NombreCooperativa", Coop.NombreCooperativa);
                    mySqlCommand.Parameters.AddWithValue("@Telefono", Coop.Telefono);
                    mySqlCommand.Parameters.AddWithValue("@Correo", Coop.CredencialUsuario.Correo);
                    mySqlCommand.Parameters.AddWithValue("@Contrasena", Coop.CredencialUsuario.Contrasena);
                    mySqlCommand.Parameters.AddWithValue("@Foreking_RolesUsuario", Coop.CredencialUsuario.Rol);
                }
                mySqlCommand.ExecuteReader();
                con.cerrar();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex);
            }
        }


        public static Cooperativa BuscarCooperativa(int idCooperativa)
        {

            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            Cooperativa cooperativa = null;
            CredencialUsuario credencial = null;
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_BuscarCooperativa", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@idCooperativa", idCooperativa);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    credencial = new CredencialUsuario(lector["Correo"].ToString(), lector["Contrasena"].ToString(), 3);
                    cooperativa = new Cooperativa(lector["Ruc"].ToString(), lector["Propietario"].ToString(),  lector["NombreCooperativa"].ToString(), lector["Telefono"].ToString(), credencial);
                }
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: " + ex);
            }
            return cooperativa;
        }


        public string ActualizarCooperativa(string ruc, string telefono, string correo, string contrasena)
        {
            string mensaje = "";
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();

            try
            {
                MySqlCommand comando = conector.ConectarProcedimiento("spl_ModificarCooperativa", con.conectar());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Ruc", ruc);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Correo", correo);
                comando.Parameters.AddWithValue("@Contraseña", contrasena);
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
