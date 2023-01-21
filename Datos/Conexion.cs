
using MySqlConnector;
using System;
using System.Windows.Forms;
namespace Datos
{

    public class Conexion
    {

 
        private static string conexion_DB_externa = "Server=MYSQL5040.site4now.net;Database=db_a83d0f_a7eb45;Uid=a83d0f_a7eb45;Pwd=1234emelec";


        private MySqlConnection sqlconnection = null;


        public MySqlConnection Connection { get => sqlconnection; set => sqlconnection = value; }


        public MySqlConnection conectar()
        {
            try
            {
                Connection = new MySqlConnection();
                Connection.ConnectionString = conexion_DB_externa;
                Connection.Open();
            }
            catch (MySqlException x)
            {
                MessageBox.Show(x.ToString());
               
            }
            return Connection;
        }

        public void cerrar()
        {
            try
            {
                Connection.Close();
            }
            catch (MySqlException x)
            {

                MessageBox.Show(x.ToString());
            }
        }


    }
}
