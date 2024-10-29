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
<<<<<<< HEAD
        [Column("Vagas_Carros_Caminhoes")]
        protected override int NumeroVagas { get; set; }
        protected override Tipo_Veiculo TipoVeiculo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
=======
        [Column("NumeroVagasCarro")]
        protected override int NumeroVagas { get; set; }

        [Column("VagasCarro")]
        protected override List<bool> Vagas { get; set; }

>>>>>>> 822f63bd43480db25cd87ea5f044bec0fbcfaa7a
        public CarTruck_Parking(int numeroVagas) : base(numeroVagas)
        {
            NumeroVagas = numeroVagas;
        }

        public override void AlterarNumeroVagas(int novoNumero)
        {
            base.AlterarNumeroVagas(novoNumero);
            Console.WriteLine($"Número de vagas para carros ajustado para: {NumeroVagas}");
        }
    }
}
