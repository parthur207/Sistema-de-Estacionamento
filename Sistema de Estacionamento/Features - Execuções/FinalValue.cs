using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.IFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class FinalValue : MyDbContext, IFeature_Parking
    {
        protected double Preco_Minuto { get; private set; } = 0.10;
        public double Pagamento(TimeSpan Periodo)
        {
            double Preco;
            // Calculo padrão do valor a ser pago: VALOR A PAGAR = (0.10 * minutos)
            if (Periodo.TotalMinutes >= 480 && Periodo.TotalMinutes<= 720) //PREÇO FIXO: 480 minutos, equivalente a 8 horas | 720 minutos, equivalente a 12 horas
            {
                Preco = 50.00;
            }
            else
            {
                Preco = Preco_Minuto * Periodo.TotalMinutes;
            }
            return Preco;
        }
    }
}
