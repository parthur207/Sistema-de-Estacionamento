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
        [Column("NumeroVagasCarro")]
        protected override int NumeroVagas { get; set; }

        [Column("VagasCarro")]
        protected override List<bool> Vagas { get; set; }

        public CarTruck_Parking(int numeroVagas) : base(numeroVagas)
        {
            NumeroVagas = numeroVagas;
            Vagas = new List<bool>(new bool[NumeroVagas]);
        }

        public override void AlterarNumeroVagas(int novoNumero)
        {
            base.AlterarNumeroVagas(novoNumero);
            Console.WriteLine($"Número de vagas para carros ajustado para: {NumeroVagas}");
        }
    }
}
