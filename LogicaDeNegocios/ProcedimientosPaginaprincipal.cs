
using Datos;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogicaDeNegocios
{

    public class ProcedimientosPaginaprincipal
    {

        Conexion con = new Conexion();
        private static string cedula = "";

        public static string getCedula()
        {
            return cedula;
        }

        public static void setCedula(string cedulas)
        {
            cedula = cedulas;
        }

        public List<int> IniciasSeccion(string correo, string password)
        {
            List<int> IdPeronsaAndRol = new List<int>();
            List<string> IdCedula = new List<string>();
            try
            {
                MySqlCommand mySqlCommand = ConectarProcedimiento("sspl_ProcesoInicioSeccion");
                mySqlCommand.Parameters.AddWithValue("@CorreoFx", correo);
                mySqlCommand.Parameters.AddWithValue("@contrasenaFx", password);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    int x = Convert.ToInt32(lector["Foreking_RolesUsuario"]);
                    IdPeronsaAndRol.Add(Convert.ToInt32(lector["Foreking_RolesUsuario"]));
                    if (x == 1 || x==3)
                    {
                        IdPeronsaAndRol.Add(Convert.ToInt32(lector["idPersona"]));
                    }
                    else
                    {
                        IdCedula.Add(Convert.ToString(lector["Cedula"]));
                        setCedula(IdCedula[0]);
                    }                  
                }
                con.cerrar(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error intentolo mas tarde" + ex);

            }          
            return IdPeronsaAndRol;
        }

        public List<string> BuscarNumerosAsientos(int busId, int BoletoID)
        {
            List<string> asientos = new List<string>();
            try
            {
                MySqlCommand mySqlCommand = ConectarProcedimiento("BuscarAsientos");
                mySqlCommand.Parameters.AddWithValue("@idBus", busId);
                mySqlCommand.Parameters.AddWithValue("@BoletoID", BoletoID);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    asientos.Add(lector["DescripcionBus"].ToString());
                }
                con.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error intentolo mas tarde" + ex);

            }
            return asientos;
        }


         public List<Ruta> BuscarBoleto(string cooperativa, string fechasalida, string horasalida)
        {
            List<Ruta> newlist = new List<Ruta>();
            Ruta generarInformacionBoleto = null;
            try
            {
                MySqlCommand mySqlCommand = ConectarProcedimiento("spl_LlenarVentanaCompra");
                mySqlCommand.Parameters.AddWithValue("@cooperativaFX", cooperativa);
                mySqlCommand.Parameters.AddWithValue("@horaSalidaFX", fechasalida);
                mySqlCommand.Parameters.AddWithValue("@fechaSalidaFX", Convert.ToDateTime(horasalida));
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    generarInformacionBoleto = new Ruta(
                    Convert.ToInt32(lector["Id_generearBoleto"].ToString()), Convert.ToInt32(lector["idBus"].ToString()), lector["salida"].ToString(), lector["FechaSalida"].ToString(), lector["destino"].ToString(),
                    lector["HoraSalida"].ToString(), lector["nombreCooperativa"].ToString(), lector["Disco"].ToString(), lector["CantidadAsiento"].ToString(), lector["Precio"].ToString()
                    );
                    
                    newlist.Add(generarInformacionBoleto);
                    
                }
                con.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error intentolo mas tarde" + ex);

            }
            return newlist;
        }

        public List<string> CargarCooperativa(string origen, string destino)
        {
            List<string> cooperativa = new List<string>();
            try
            {
                MySqlCommand mySqlCommand = ConectarProcedimiento("ProcesoBuscarCooperativa");
                mySqlCommand.Parameters.AddWithValue("@SalidaFx", origen);
                mySqlCommand.Parameters.AddWithValue("@SestinoFX", destino);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    cooperativa.Add(lector["nombreCooperativa"].ToString());
                }
                con.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error intentolo mas tarde" + ex);

            }
            return cooperativa;
        }

        public void LllenarDataGrid(string origen, string destino, string cooperativa, DataGridView dataGridInf)
        {
            try
            {
                MySqlCommand mySqlCommand = ConectarProcedimiento("ProcesoLlenarDataGrid");
                mySqlCommand.Parameters.AddWithValue("@SalidaFx", origen);
                mySqlCommand.Parameters.AddWithValue("@DestinoFX", destino);
                mySqlCommand.Parameters.AddWithValue("@CooperativaFX", cooperativa);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    int numerofila = dataGridInf.Rows.Count;
                    dataGridInf.Rows.Add(1);
                    dataGridInf.Rows[numerofila].Cells[0].Value = lector["nombreCooperativa"].ToString();
                    dataGridInf.Rows[numerofila].Cells[1].Value = lector["HoraSalida"].ToString();
                    dataGridInf.Rows[numerofila].Cells[2].Value = lector["FechaSalida"];
                    dataGridInf.Rows[numerofila].Cells[3].Value = lector["Precio"].ToString();
                    dataGridInf.Rows[numerofila].Cells[4].Value = "Seleccionar...";
                }
                con.cerrar();
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error intentolo mas tarde"+ex);
            }
        }

        public List<string> CargarCiudad()
        {
            List<string> ciudad = new List<string>();
            try
            {
                MySqlCommand mySqlCommand = ConectarProcedimiento("ProcesoBusquedaCiudad"); 
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                    while (lector.Read())
                    {
                        ciudad.Add(lector["DescripcionCiudad"].ToString());
                    }
                con.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error intentolo mas tarde"+ex);

            }
            return ciudad;
        }

        private MySqlCommand ConectarProcedimiento(string Procedimientos)
        {
            MySqlCommand mySqlCommand;
            mySqlCommand = new MySqlCommand(Procedimientos, con.conectar());
            mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            return mySqlCommand;
        }

    }
}
