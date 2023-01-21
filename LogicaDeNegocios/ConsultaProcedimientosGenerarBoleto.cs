
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogicaDeNegocios
{

    public class ConsultaProcedimientosGenerarBoleto
    {
      
        ProcedimientosPaginaprincipal procedimientos = new ProcedimientosPaginaprincipal();

        public List<Ruta> generarInformacionBoleto(string cooperativa, string fechasalida, string horasalida)
        {
            List<Ruta> ListaBoletosGenerados = new List<Ruta>();
            ListaBoletosGenerados = procedimientos.BuscarBoleto(cooperativa, fechasalida, horasalida);
            return ListaBoletosGenerados;
            
        }


        public void LlenarComboAsientos(int busId, ComboBox cbNumeroAsientos,int BoletoID)
        {
           
            List<string> NumeroAsiento = procedimientos.BuscarNumerosAsientos(busId, BoletoID);
            if (NumeroAsiento.Count != 0)
            {
                foreach (string asiento in NumeroAsiento)
                {
                    cbNumeroAsientos.Items.Add(asiento);
                }
            }

        }
    }
}
