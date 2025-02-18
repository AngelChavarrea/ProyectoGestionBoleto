﻿
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogicaDeNegocios
{

    public class ConsultasProcedimientos
    {
       
        ProcedimientosPaginaprincipal procedimientos = new ProcedimientosPaginaprincipal();

        
        public List<int> Login(string usuario, string password)
        {
            List<int> IdPeronsaAndRol = procedimientos.IniciasSeccion(usuario, password);
            if(IdPeronsaAndRol.Count > 0)
            {
                MessageBox.Show("Inicio de sesión realizado con éxito.");
            }
            else
            {
                throw new ControlExcepcion("Usuario y/o contrasena incorrecta");
               
            }
            return IdPeronsaAndRol;
        }

        public void LlenarCombos(ComboBox cbOrigen, ComboBox cbDestino)
        {
            List<string> ciudad = new List<string>();
            ciudad = procedimientos.CargarCiudad();
            if (ciudad.Count!=0)
            {
                foreach (string ciudadfx in ciudad)
                {
                    cbOrigen.Items.Add(ciudadfx);
                    cbDestino.Items.Add(ciudadfx);
                }
            }

        }

        public void LlenarComboCooperativa(ComboBox cbCooperativa, string origen, string destino)
        {
            List<string> coopeativa = new List<string>();
            string Coop = string.Empty;
            coopeativa = procedimientos.CargarCooperativa(origen,destino);
            if (coopeativa.Count != 0)
            {
                foreach (string coopeativafx in coopeativa)
                {
                    if (coopeativafx != Coop)
                    {
                        cbCooperativa.Items.Add(coopeativafx);
                        Coop = coopeativafx;
                    }
                    
                }
            }
        }

        public void LLenarGrit(string origen, string destino, string cooperativa, DataGridView dataGridInf)
        {
            procedimientos.LllenarDataGrid(origen, destino, cooperativa, dataGridInf);
        }
       
        public bool ValidarDataGridVacio(DataGridView dataGridInf)
        {
            bool bandera = false;

            if (dataGridInf.SelectedRows.Count > 0)
            {
                bandera= true;
            }
            else
            {
                throw new ControlExcepcion(" Por favor seleccionar un horario!");
            }
            return bandera;
        }
    }
}
