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
        public virtual void Validation_Venancies(Tipo_Veiculo veiculo)
        {
           
           Program.Main(AtributesClient.ref_args);
        }
    }
}
