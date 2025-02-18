﻿using Datos;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogicaDeNegocios
{
    public class Pago
    {
        public  static int MNumeroboleto;
        private string nombreConsumidor;
        private string cedulaConsumidor;
        public Pago() { }
        private static List<string> boleto = new List<string>();
        public static List<Pago> InfoBoleto = new List<Pago>();
        public Pago(string NombreConsumidor, string CedulaConsumidor)
        {
            this.CedulaConsumidor = CedulaConsumidor;
            this.NombreConsumidor = NombreConsumidor;
        }
        private string cooperativa, destino, fechaSalida, horaSalida, LugarSalida, numeroDisco;
        private double precios;

        public string Destino { get => destino; set => destino = value; }
        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string LugarSalida1 { get => LugarSalida; set => LugarSalida = value; }
        public string NumeroDisco { get => numeroDisco; set => numeroDisco = value; }
        public double Precios { get => precios; set => precios = value; }
        public string NombreConsumidor { get => nombreConsumidor; set => nombreConsumidor = value; }
        public string CedulaConsumidor { get => cedulaConsumidor; set => cedulaConsumidor = value; }

        public string getCooperativa()
        {
            return cooperativa;
        }

        public void setCooperativa(string cooperativa)
        {
            this.cooperativa = cooperativa;
        }
        public static List<string> getBoleto()
        {
            return boleto;
        }
        public static bool pagarBoleto(int Id_bus, string Cedula_cliente, List<string> asientos)
        {
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            bool validacion = false;        
            try
            {
                MessageBoxButtons ob = MessageBoxButtons.YesNoCancel;
                DialogResult obj = MessageBox.Show("Desea confirmar el pago","Titulo",ob, MessageBoxIcon.Question);
                if (obj == DialogResult.Yes)
                {
                    int num = MNumeroboleto;
                    
                    while (num > 0)
                    {
                        int x = 1;
                        MySqlCommand mySqlCommand = conector.ConectarProcedimiento("spl_pago", con.conectar());
                        mySqlCommand.Parameters.AddWithValue("@id_bus", Id_bus);
                        mySqlCommand.Parameters.AddWithValue("@cedula_cliente", Cedula_cliente);
                        mySqlCommand.Parameters.AddWithValue("@FechaActual", DateTime.Now);
                        foreach (Pago p in InfoBoleto)
                        {         
                            if (x == num)
                            {
                                mySqlCommand.Parameters.AddWithValue("@Nombre_comprador", p.nombreConsumidor);
                                mySqlCommand.Parameters.AddWithValue("@cedula_Comprador", p.cedulaConsumidor);
                            }
                            x++;
                        }
                        mySqlCommand.ExecuteNonQuery();
                        num--;
                    }
                    boleto.Clear();
                    InfoBoleto.Clear();
                    MessageBox.Show("Se realizó el pago con éxito ");
                    validacion = true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                Conexion cono = new Conexion();
                foreach (string p in asientos)
                {
                    MySqlCommand mySqlCommand = conector.ConectarProcedimiento("InactivarAsientos", cono.conectar());
                    mySqlCommand.Parameters.AddWithValue("@asiento", p);
                    mySqlCommand.Parameters.AddWithValue("@Idboleto", Id_bus);
                    mySqlCommand.ExecuteNonQuery();
                }
                
                cono.cerrar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return validacion;
        }

        public static List<string> GuardarPdf()
        {
            List<string> list = new List<string>();
            string tablas = string.Empty;
            double precio=0;
            string cliente= string.Empty;
            Conexion con = new Conexion();
            ConectorDeProcedimientos conector = new ConectorDeProcedimientos();
            try
            {
                MySqlCommand mySqlCommand = conector.ConectarProcedimiento("ImprimirBoleto", con.conectar());
                mySqlCommand.Parameters.AddWithValue("@cantboleto", MNumeroboleto);
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                while (lector.Read())
                {
                    tablas += "<tr>";
                    tablas += "<td>" + lector["Id_compra"].ToString() + "</td>";
                    tablas += "<td>" + lector["cooperativa"].ToString() + "</td>";
                    tablas += "<td>" + lector["Placa"].ToString() + "</td>";
                    tablas += "<td>" + lector["Cedula_Comprador"].ToString() + "</td>";
                    tablas += "<td>" + lector["Fecha_Salida"].ToString() + "</td>";
                    tablas += "<td>" + lector["HoraSalida"].ToString() + "</td>";
                    tablas += "<td>" + lector["Precio"].ToString() + "</td>";
                    tablas += "</tr>";
                    precio = precio + Convert.ToDouble(lector["Precio"]);
                    MNumeroboleto--;
                    cliente = lector["Nombre_cliente"].ToString();
                }
                list.Add(tablas);
                list.Add(Convert.ToString(precio));
                list.Add(cliente);
                con.cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error emitido por: " + ex);
            }
            return list;
        }
    }
}
