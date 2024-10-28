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
    internal class MotocycleParking : AttributesParking
    {
        [Column("NumeroVagasMoto")]
        protected override int NumeroVagas { get; set; }

        [Column("VagasMoto")]
        protected override List<bool> Vagas { get; set; }

        public MotocycleParking(int numeroVagas) : base(numeroVagas)
        {
            NumeroVagas = numeroVagas;
            Vagas = new List<bool>(new bool[NumeroVagas]);
        }

        public override void AlterarNumeroVagas(int novoNumero)
        {
            base.AlterarNumeroVagas(novoNumero);
            Console.WriteLine($"Número de vagas para motos ajustado para ({NumeroVagas}).");
            Program.Main(ref_args);
        }
    }
}
