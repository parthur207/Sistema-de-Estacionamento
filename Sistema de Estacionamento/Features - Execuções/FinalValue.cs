using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.IFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class FinalValue : IFeature_Parking
    {
        public double Pagamento(TimeSpan Periodo, int id)
        {
            double Preco;
            // Calculo padrão do valor a ser pago: VALOR A PAGAR = (taxa * minutos)

            //PREÇO FIXO: 0 a 60 minutos
            if (Periodo.TotalMinutes>=0 && Periodo.TotalMinutes<=60)
            {
                Preco = 8.50;
            }
            else if (Periodo.TotalMinutes >= 480 && Periodo.TotalMinutes<= 720) //PREÇO FIXO: 480 minutos, equivalente a 8 horas | 720 minutos, equivalente a 12 horas
            {
                Preco = 50.00;
            }
            else
            {
                if (id == 1)
                {
                    Preco = GetTaxa().Item1 * Periodo.TotalMinutes;
                }
                else
                {
                    Preco = GetTaxa().Item2 * Periodo.TotalMinutes;
                }
            }
            return Preco;
        }

        protected (double, double) GetTaxa()
        {
            using (var contexto_preco=new MyDbContext())
            {
                var Taxa_CC = contexto_preco.Estacionamento.Where(x=>x.Id.Equals(1)).Select(x=>x.Taxa_Minuto).FirstOrDefault();
                var Taxa_MT= contexto_preco.Estacionamento.Where(x => x.Id.Equals(2)).Select(x => x.Taxa_Minuto).FirstOrDefault();

                return (Taxa_CC,Taxa_MT);
            }  
        }
    }
}
