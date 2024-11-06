using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.IFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class Reports : Tariffs, IFeature_Parking
    {
        public void NumberVehicles()
        {
            int QntCarros, QntCaminhoes, QntMotos, qntTotal;

            using (var context_QueryQnt = new MyDbContext())
            {
                QntCarros = context_QueryQnt.Tabela_Veiculos.Count(x => x.TipoVeiculo.Equals("Carro"));
                QntCaminhoes = context_QueryQnt.Tabela_Veiculos.Count(x => x.TipoVeiculo.Equals("Caminhao"));
                QntMotos = context_QueryQnt.Tabela_Veiculos.Count(x => x.TipoVeiculo.Equals("Moto"));
                qntTotal=context_QueryQnt.Tabela_Veiculos.Count();
                Console.WriteLine("============================================");
                Console.WriteLine("Número total de veículos registrados no estacionamento por tipo:");
                Console.WriteLine($"\nCarros: {QntCarros}");
                Console.WriteLine($"Caminhões: {QntCaminhoes}");
                Console.WriteLine($"Motos: {QntMotos}");
                Console.WriteLine($"Total de veículos: {qntTotal}");
                Console.WriteLine("============================================");
            }
        }

        public void AveragePeriod()
        {
            using(var context_Average = new MyDbContext())  
            {
                var qnt_Periodos = context_Average.Tabela_Clientes.Count();
                var totalPeriodo = context_Average.Tabela_Clientes
                                .Select(x => x.Periodo)
                                .Aggregate(TimeSpan.Zero, (soma, periodo) => soma + periodo);

                var PeriodoEmMinutos= totalPeriodo.TotalMinutes;
                var PeriodoEmHoras=totalPeriodo.TotalHours;

                var MediaMinutos = PeriodoEmMinutos / qnt_Periodos;
                var MediaHoras= PeriodoEmHoras / qnt_Periodos;

                Console.WriteLine("============================================");
                Console.WriteLine("Relatório do período médio total de veículos estacionados:");
                Console.WriteLine($"\nMinutos totais: {PeriodoEmMinutos}");
                Console.WriteLine($"Horas Totais: {PeriodoEmHoras}");

                Console.WriteLine($"Media de minutos: {MediaMinutos}");
                Console.WriteLine($"Media de horas: {MediaHoras}");
                Console.WriteLine("============================================");
            }
        }

        public void ReceitaTotal()
        {
            using (var )
            {

            }
        }

    }
}
