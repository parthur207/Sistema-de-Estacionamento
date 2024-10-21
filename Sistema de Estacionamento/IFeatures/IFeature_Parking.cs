using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.IFeatures
{
    internal interface IFeature_Parking
    {
        TimeSpan CheckOut(DateTime Entrada, DateTime Saida)
        {
            TimeSpan Periodo_Estacionamento = Entrada - Saida;
            return Periodo_Estacionamento;
        }

        void Exibition_Venancies(Tipo_Veiculo veiculo) { }

        void C_Radom() { }

        decimal Pagamento() { return 0; }
    }
}
