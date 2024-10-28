using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    
    internal abstract class AttributesParking
    {
        protected abstract int NumeroVagas { get; set; }
        protected abstract List<bool> Vagas { get; set; }
        [Table("Tabela_Estacionamento")]
        public AttributesParking(int numeroVagas)
        {
            NumeroVagas = numeroVagas;
            Vagas = new List<bool>(new bool[NumeroVagas]);
        }
        public virtual void AlterarNumeroVagas(int novoNumero) { }
        public virtual void ExibirNumeroVagas(Tipo_Veiculo tipo)
        {
            var vagasDisp = Vagas.Select(x => x.Equals(true)).Count();
            if (vagasDisp <= 0)
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
