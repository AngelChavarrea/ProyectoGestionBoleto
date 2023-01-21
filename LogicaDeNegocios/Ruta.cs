
using Datos;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocios
{

    public class Ruta
    {

        int busId;

        string lugarSalida;

        string fechaSalida;

        string lugardestino;

       string horaSalida;

       string cooperativa;

         string asiento;

         string numerodico;

       string precio;
        int boletoID;

        
        public Ruta(int boletoID, int busId, string lugarSalida, string fechaSalida, string lugardestino, string horaSalida, string cooperativa, string numerodico, string asiento, string precio)
        {
            this.boletoID = boletoID;
            this.busId= busId;
            this.lugarSalida = lugarSalida;
            this.fechaSalida = fechaSalida;
            this.lugardestino = lugardestino;
            this.horaSalida = horaSalida;
            this.cooperativa = cooperativa;
            this.asiento = asiento;
            this.numerodico = numerodico;
            this.precio = precio;
        }
        public Ruta() { }

        public string LugarSalida { get => lugarSalida; set => lugarSalida = value; }

        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }

        public string Lugardestino { get => lugardestino; set => lugardestino = value; }

        public String HoraSalida { get => horaSalida; set => horaSalida = value; }

        public string Cooperativa { get => cooperativa; set => cooperativa = value; }

        public string Numerodico { get => numerodico; set => numerodico = value; }

        public String Precio { get => precio; set => precio = value; }

        public int BusId { get => busId; set => busId = value; }
        public string Asiento { get => asiento; set => asiento = value; }
        public int BoletoID { get => boletoID; set => boletoID = value; }
        Bus bus = new Bus();

        public void InsertarRuta(Ruta ruta)
        {
            Conexion con = new Conexion();
           
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                List<Ruta> Lista = new List<Ruta>();
                Lista.Add(ruta);
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_insertarRuta", con.conectar());
                foreach (Ruta Ruta in Lista)
                {
                    mySqlCommand.Parameters.AddWithValue("@Cooperativa", Ruta.Cooperativa);
                    mySqlCommand.Parameters.AddWithValue("@NumeroDisco", Ruta.Numerodico);
                    mySqlCommand.Parameters.AddWithValue("@lugarOrigen", Ruta.LugarSalida);
                    mySqlCommand.Parameters.AddWithValue("@lugarDestino", Ruta.Lugardestino);
                    mySqlCommand.Parameters.AddWithValue("@horaSalida", Ruta.HoraSalida);
                    mySqlCommand.Parameters.AddWithValue("@NumAsiento", Ruta.Asiento);
                    mySqlCommand.Parameters.AddWithValue("@Precio", Ruta.Precio);

                }
                mySqlCommand.ExecuteReader();
                con.cerrar();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex);
            }

        }
    }
}
