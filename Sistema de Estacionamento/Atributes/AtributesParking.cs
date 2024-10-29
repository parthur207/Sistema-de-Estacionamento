using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
<<<<<<< HEAD
    [Table("Estacionamento")]
    internal abstract class AttributesParking
    {
        protected abstract int NumeroVagas { get; set; }

        protected abstract Tipo_Veiculo TipoVeiculo { get; set; }

=======
    [Table("Tabela_Estacionamento")]
    internal abstract class AttributesParking
    {
        protected abstract int NumeroVagas { get; set; }
        protected abstract List<bool> Vagas { get; set; }
        
>>>>>>> 822f63bd43480db25cd87ea5f044bec0fbcfaa7a
        public AttributesParking(int numeroVagas)
        {
            NumeroVagas = numeroVagas;
        }
<<<<<<< HEAD
        public abstract void AlterarNumeroVagas(int novoNumero);
        public virtual void ExibirNumeroVagas(Tipo_Veiculo tipo)
        {
            using (var query_vagas)
=======
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
>>>>>>> 822f63bd43480db25cd87ea5f044bec0fbcfaa7a
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
