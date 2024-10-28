using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Tabela_Estacionamento")]
    internal abstract class AttributesParking
    {
        protected abstract int NumeroVagas { get; set; }
        protected abstract List<bool> Vagas { get; set; }
        
        public AttributesParking(int numeroVagas)
        {
            NumeroVagas = numeroVagas;
            Vagas = new List<bool>(new bool[NumeroVagas]);
        }
        public virtual void AlterarNumeroVagas(int novoNumero) 
        {
            if (novoNumero > 0)
            {
                NumeroVagas = novoNumero;
                Vagas = new List<bool>(new bool[NumeroVagas]);
                Console.WriteLine($"Número de vagas ajustado para: {NumeroVagas}");
            }
            else
            {
                Console.WriteLine("O número de vagas deve ser maior que 0.");
            }
        }
        public virtual void ExibirNumeroVagas(Tipo_Veiculo tipo)
        {
            var vagasDisp = Vagas.Select(x => x.Equals(true)).Count();
            if (vagasDisp == 0)
            {
                Console.WriteLine($"\nNão há vagas disponíveis para {(tipo)} no momento.");
            }
            else
            {
                Console.WriteLine($"\nNumero de vagas disponíveis para Veículos {(tipo)}: {vagasDisp}");
            }
        }
    }
}
