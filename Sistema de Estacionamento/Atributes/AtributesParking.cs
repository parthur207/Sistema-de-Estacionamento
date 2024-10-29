using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Estacionamento")]
    internal abstract class AttributesParking
    {
        protected abstract int NumeroVagas { get; set; }

        protected abstract Tipo_Veiculo TipoVeiculo { get; set; }

        public AttributesParking(int numeroVagas)
        {
            NumeroVagas = numeroVagas;
        }
        public abstract void AlterarNumeroVagas(int novoNumero);
        public virtual void ExibirNumeroVagas(Tipo_Veiculo tipo)
        {
            using (var query_vagas)
            {
                Console.WriteLine($"\nNão há vagas disponíveis para Veículos {(tipo)}");
            }
            else
            {
                Console.WriteLine($"\nNumero de vagas disponíveis para Veículos {(tipo)}: {vagasDisp}");
            }
        }
    }
}
