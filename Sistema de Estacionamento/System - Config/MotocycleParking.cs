using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal class MotocycleParking : AttributesParking
    {
        protected override List<bool> Vagas { get; set; }
        protected override int NumeroVagas { get; set; }


        public MotocycleParking(int numeroVagas) : base(numeroVagas)
        {
            NumeroVagas = numeroVagas;
            Vagas = new List<bool>(new bool[NumeroVagas]);
        }

        // Implementação do método abstrato para alterar o número de vagas
        public override void AlterarNumeroVagas(int novoNumero)
        {
            Console.WriteLine("\nDigite o novo numero de vagas para o estacionamento de motos:");
            if (int.TryParse(Console.ReadLine(), out novoNumero) || novoNumero < 0)
            {
                Console.WriteLine("\nÉ necessário digitar um número, sendo maior que 0.");
            }
            else
            {
                NumeroVagas = novoNumero;
                Vagas = new List<bool>(new bool[NumeroVagas]); // Redimensiona as vagas
                Console.WriteLine($"Número de vagas para motos ajustado para: {NumeroVagas}");
            }
        }

    }
}
