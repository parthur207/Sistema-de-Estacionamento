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
        TimeSpan Period_CheckOut(DateTime Entrada, DateTime Saida)
        {
          
            return TimeSpan.MaxValue;
        }

        void Exibition_Venancies(Tipo_Veiculo veiculo) { }

        string C_Radom() { return string.Empty; }

        double Pagamento(TimeSpan Periodo) { return 0; }
    }
}
