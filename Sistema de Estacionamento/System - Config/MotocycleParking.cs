using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal class MotocycleParking : AtributesParking
    {
        [Column("Numero_Vagas_M")]
        public override int NumeroVagas { get; set; }

        [Column("Vagas_Disponíveis_M")]
        public override int NumeroVagasDisp { get; set; }
  

        public override void AlterarNumeroVagas(int novoNumero, int id)
        {
           
            Console.WriteLine($"\nDigite o novo numero de vagas para o estacionamento de Motos:");
            if (!int.TryParse(Console.ReadLine(), out novoNumero)|| novoNumero<)
            {
                Console.WriteLine("\nValor fornecido deve");
            }


            Program.Main(ref_args);
        }
    }
}
