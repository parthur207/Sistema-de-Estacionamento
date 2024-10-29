using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    
    internal abstract class AttributesParking
    {
        protected abstract int NumeroVagas { get; set; }
        protected abstract int NumeroVgasDisp { get; set; }
        protected abstract Tipo_Veiculo Tipo { get;}
    
        public virtual void AlterarNumeroVagas(int novoNumero) { }
        public virtual void ExibirNumeroVagas_Disp()
        {
        }
    }
}
