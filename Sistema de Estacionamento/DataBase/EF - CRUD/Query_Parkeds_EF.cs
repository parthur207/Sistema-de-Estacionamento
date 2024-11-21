using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF___CRUD
{
    internal class Query_Parkeds_EF : IExecution_ef
    {
        
        protected int Numero_Estacionados { get; set; }
        public void Query_parked()
        {
            try
            {
                using (var context_parkeds = new MyDbContext())
                {
                    Numero_Estacionados = context_parkeds.Tabela_Clientes.Count(x => x.Estacionado.Equals(true));

                    var Lista_credenciais = context_parkeds.Tabela_Clientes.Where(x => x.Estacionado.Equals(true))
                        .Select(x => x.Credencial_Acesso)
                        .ToList();

                    Console.WriteLine("\n============================================");
                    Console.WriteLine("Clientes/Veículos estacionados:");

                    Console.WriteLine($"\nNumero de veículos estacionados: {Numero_Estacionados}");
                    foreach (var credencial in Lista_credenciais)
                    {
                        var atb_c = context_parkeds.Tabela_Clientes.Where(x => x.Credencial_Acesso.Equals(credencial)).FirstOrDefault();
                        var atb_v = context_parkeds.Tabela_Veiculos.Where(x => x.Credencial_Acesso.Equals(credencial)).FirstOrDefault();

                        Console.WriteLine("Dados do cliente:");
                        Console.WriteLine($"\nNome:{atb_c.Nome_Cliente}");
                        Console.WriteLine($"Credencial de acesso: {atb_c.Credencial_Acesso}");
                        Console.WriteLine($"Entrada:{atb_c.Entrada}");
                        if (atb_c.Saida != null)
                        {
                            Console.WriteLine($"Saída: {atb_c.Saida}");
                        }
                        if (atb_c.Periodo.ToString() != "00:00:00")
                        {
                            Console.WriteLine($"Periodo: {atb_c.Periodo}");
                        }
                        Console.WriteLine("\n============================================");
                        Console.WriteLine("Dados do veículo:");
                        Console.WriteLine($"\nEstacionado: {atb_c.Estacionado}");
                        Console.WriteLine($"Nome veiculo: {atb_v.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {atb_v.TipoVeiculo}");
                        Console.WriteLine($"Cor: {atb_v.Cor}");
                        Console.WriteLine($"Placa: {atb_v.Placa}");
                    }
                    Console.WriteLine("============================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado.\nErro: {ex.Message}");
            }
        }

        public int Get_NumbersParkeds()
        {
            return Numero_Estacionados;
        }
    }
}
