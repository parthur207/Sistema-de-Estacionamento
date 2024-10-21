using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    internal class AtributesClient : AtributesVehicle
    {
        public static string[] ref_args { get; private set; }//Parâmetro de referência ao método Main

        protected string Credencial_Acesso { get; set; }
        protected string Nome { get; set; }
        protected DateTime Entrada { get; set; }
        protected DateTime Saida { get; set; }
        protected DateTime Periodo { get; set; }
    }
}
