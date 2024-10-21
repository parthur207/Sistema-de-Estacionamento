using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Main;
using Sistema_de_Estacionamento.System___Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class Venancies : CarTruck_Parking, IFeature_Parking
    {

        public Venancies(int numeroVagas) : base(numeroVagas) { }
        public virtual void Exibition_Venancies(Tipo_Veiculo veiculo)
        {
            if (veiculo.Equals(Tipo_Veiculo.Carro) || veiculo.Equals(Tipo_Veiculo.Caminhão))
            {
                ExibirNumeroVagas(Tipo_Veiculo.Carro);
            }
            else if (veiculo.Equals(Tipo_Veiculo.Moto))
            {
                ExibirNumeroVagas(Tipo_Veiculo.Moto);
            }
            Program.Main(AtributesClient.ref_args);
        }
    }
}
