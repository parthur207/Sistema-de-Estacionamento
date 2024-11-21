using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF___CRUD
{
    internal class QueryAll_EF : IExecution_ef
    {
        public void Query_All()
        {
            try
            {
                using (var context_All = new MyDbContext())
                {
                    var Credencial_List = context_All.Tabela_Clientes.OrderBy(x=>x.Entrada)
                        .Select(x=>x.Credencial_Acesso).ToList();
                    Console.WriteLine("\nTodos os registros:");
                    foreach (var credencial in Credencial_List)
                    {

                        var atb_c = context_All.Tabela_Clientes.Where(x => x.Credencial_Acesso.Equals(credencial))
                            .FirstOrDefault();
                        var atb_v = context_All.Tabela_Veiculos.Where(x => x.Credencial_Acesso.Equals(credencial))
                            .FirstOrDefault();

                        Console.WriteLine("======================================");
                        Console.WriteLine("Dados do Cliente:");
                        Console.WriteLine($"\nNome cliente: {atb_c.Nome_Cliente}");
                        Console.WriteLine($"Entrada: {atb_c.Entrada}");
                        Console.WriteLine($"Saída:{atb_c.Saida}");
                        if (atb_c.Periodo.ToString() != "00:00:00") { Console.WriteLine($"Periodo:{atb_c.Periodo}"); }
                        if (atb_c.Valor != null) { Console.WriteLine($"Valor: R${atb_c.Valor}"); }
                        Console.WriteLine($"Estacionado: {atb_c.Estacionado}");

                        Console.WriteLine("___________________");

                        Console.WriteLine("Dados do Veículo:");
                        Console.WriteLine($"Nome do veículo: {atb_v.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {atb_v.TipoVeiculo}");
                        Console.WriteLine($"Cor: {atb_v.Cor}");
                        Console.WriteLine($"Placa: {atb_v.Placa}");
                        Console.WriteLine($"Credencial de acesso: {atb_v.Credencial_Acesso}");
                        Console.WriteLine("======================================");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado.\n Erro: {ex.Message}");
            }
        }

    }
}
