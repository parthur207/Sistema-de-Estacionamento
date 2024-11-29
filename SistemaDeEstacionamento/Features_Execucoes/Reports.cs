using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.IFeatures_Interface;

namespace SistemaDeEstacionamento.Features_Execucoes
{
    internal class Reports : IFeature_Parking
    {

        public void S_Reports()
        {
            bool val = true;
            do
            {
                Console.WriteLine("\n============================================");
                Console.WriteLine("Relatórios (Digite o número correspondente):");
                Console.WriteLine("\n1. Número total/mês de clientes/veículos atendidos.");
                Console.WriteLine("2. Tempo total/médio de permanência");
                Console.WriteLine("3. Receita total/mês gerada");
                Console.WriteLine("4. Voltar ao menu principal");
                Console.WriteLine("============================================");
                if (!int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 4)
                {
                    Console.WriteLine("\nOpção inválida. É necessário escolher um número de 1 a 4.");
                }
                else
                {
                    val = false;
                }

                switch (op)
                {
                    case 1:
                        NumberVehicles();
                        break;
                    case 2:
                        AveragePeriod();
                        break;
                    case 3:
                        Income();
                        break;
                    case 4:
                        return;
                 
                }
            }
            while (val);
        }

        public void NumberVehicles()
        {
            int QntCarros, QntCaminhoes, QntMotos, qntTotal;

            using (var context_QueryQnt = new MyDbContext())
            {
                QntCarros = context_QueryQnt.Tabela_Veiculos.Count(x => x.TipoVeiculo.Equals("Carro"));
                QntCaminhoes = context_QueryQnt.Tabela_Veiculos.Count(x => x.TipoVeiculo.Equals("Caminhao"));
                QntMotos = context_QueryQnt.Tabela_Veiculos.Count(x => x.TipoVeiculo.Equals("Moto"));
                qntTotal=context_QueryQnt.Tabela_Veiculos.Count();
                Console.WriteLine("\n============================================");
                Console.WriteLine("Número total de veículos registrados no estacionamento por tipo:");
                Console.WriteLine($"\nCarros: {QntCarros}");
                Console.WriteLine($"Caminhões: {QntCaminhoes}");
                Console.WriteLine($"Motos: {QntMotos}");
                Console.WriteLine($"\nTotal de veículos: {qntTotal}\n");
               

                var ListaCredenciais_MesCarros = context_QueryQnt.Tabela_Veiculos.Where(x => x.TipoVeiculo.Equals("Carro"))
                    .Select(x => x.Credencial_Acesso).ToList();
            }
        }

        public void AveragePeriod()
        {
            using (var context_Average = new MyDbContext())
            {
                var registros = context_Average.Tabela_Clientes
                    .Select(x => x.Periodo)
                    .ToList(); // Recupera todos os períodos na memória

                if (!registros.Any())
                {
                    Console.WriteLine("\nSem registros no momento.");
                    return;
                }

                var totalPeriodo = registros.Aggregate(TimeSpan.Zero, (soma, periodo) => soma + periodo); // Soma os períodos na memória

                var PeriodoEmMinutos = totalPeriodo.TotalMinutes;
                var PeriodoEmHoras = totalPeriodo.TotalHours;

                var MediaMinutos = PeriodoEmMinutos / registros.Count;
                var MediaHoras = PeriodoEmHoras / registros.Count;

                Console.WriteLine("\n============================================");
                Console.WriteLine("Relatório do período médio total de veículos estacionados:");
                Console.WriteLine($"\nMinutos totais: {PeriodoEmMinutos}");
                Console.WriteLine($"Horas Totais: {PeriodoEmHoras}");
                Console.WriteLine($"\nMédia de minutos: {MediaMinutos}");
                Console.WriteLine($"Média de horas: {MediaHoras}\n");
            }
        }

        public void Income()
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};
            using (var Context_TotalValue = new MyDbContext())
            {
                var receita = Context_TotalValue.Tabela_Clientes.Sum(x => x.Valor);
                Console.WriteLine("\n============================================");
                Console.WriteLine($"Receita total acumulada: R$ {(receita)}");

                Console.WriteLine("\nReceitas mensais: ");

                for (int mes = 1; mes <= 12; mes++)
                {
                    using (var Context_ValueMonth = new MyDbContext()) 
                    {
                        var ValorMes = Context_ValueMonth.Tabela_Clientes.Where(x => x.Entrada.Month.Equals(mes)).Sum(x=>x.Valor);

                        Console.WriteLine($"{meses[mes-1]}: {ValorMes}");
                    }
                  
                }   Console.WriteLine("");
            }
        }
    }
}
