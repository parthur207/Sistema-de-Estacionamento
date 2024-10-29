using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal class CarTruck_Parking : AttributesParking
    {
        [Column("Vagas_Carros_Caminhoes")]
        protected override int NumeroVagas { get; set; }
        protected override Tipo_Veiculo TipoVeiculo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CarTruck_Parking(int numeroVagas) : base(numeroVagas)
        {
            NumeroVagas = numeroVagas;
        }


        // Construtor que passa o número inicial de vagas para a classe base

        // Implementação do método abstrato para alterar o número de vagas
        public override void AlterarNumeroVagas(int novoNumero)
        {
            Console.WriteLine("\nDigite o novo numero de vagas para o estacionamento de carros/caminhões:");

            if (int.TryParse(Console.ReadLine(), out novoNumero) || novoNumero < 0)
            {
                Console.WriteLine("\nÉ necessário digitar um número, sendo maior que 0.");
            }
            else
            {
                NumeroVagas = novoNumero;
                Vagas = new List<bool>(new bool[NumeroVagas]); // Redimensiona as vagas
                Console.WriteLine($"\nNúmero de vagas para carros ajustado para: {NumeroVagas}");
            }
        }
    }
}
