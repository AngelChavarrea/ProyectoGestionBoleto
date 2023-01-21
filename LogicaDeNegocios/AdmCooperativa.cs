
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios
{

    public class AdmCooperativa
    {
       
        Cooperativa procedimientos = new Cooperativa();
        public bool RegistrarCooperativa(Cooperativa cooperativa)
        {
            Cooperativa registrar = cooperativa;
            registrar.InsertarCooperativa(registrar);
            return true;
        }

   
        public List<Cooperativa> ConsultarCooperativa(int idCooperativa)
        {
            List<Cooperativa> lista = new List<Cooperativa>();
            Cooperativa cooperativa = null;
            cooperativa = Cooperativa.BuscarCooperativa(idCooperativa);
            lista.Add(cooperativa);
            return lista;
        }


        public string Modificar(string ruc, string telefono, string correo, string contrasena)
        {
            return procedimientos.ActualizarCooperativa(ruc, telefono, correo, contrasena);
        }
        public void EliminarVendedor(string cedulaNombre)
        {
            if (!Vendedor.EliminarVendedor(cedulaNombre))
            {
                throw new ControlExcepcion("Error al eliminar intetar más tarde");
            }
        }

        public void LLenarCombos(int idCoop,Guna2ComboBox combo,int x)
        {
            
            procedimientos.LLenarCombos(idCoop, combo,x);
        }

        public void GenerarBoleto(int first, string PlacaBus, string fecha, string hora, string precio)
        {
            if(!procedimientos.GenerarBOleto(first, PlacaBus, fecha, hora, precio))
            {
                throw new ControlExcepcion("Error al generar boleto");
            }
        }

        public List<string> ConsultarCooperativa(string v)
        {
            List<string> lista = new List<string>();
            if (v=="")
            {

            }
            else
            {
                if (v == "Inicio") v = "";
                lista = Cooperativa.buscarCoop(v);
            }
            return lista;
        }
    }
}
