using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.Features___Execuções;
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
        protected override Tipo_Veiculo Tipo { get; } = Tipo_Veiculo.Carro;

      
        public override void AlterarNumeroVagas(int novoNumero)
        {
            base.AlterarNumeroVagas(novoNumero);
            Console.WriteLine($"Número de vagas para carros ajustado para: {NumeroVagas}");
        }
    }
}
