using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.DataBase.IEF_Interface;

namespace SistemaDeEstacionamento.DataBase.EF_CRUD
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
                        if (atb_c.Estacionado==false) { Console.WriteLine($"Saída: {atb_c.Saida}"); }
                        if (atb_c.Periodo.ToString() != "00:00:00") { Console.WriteLine($"Periodo: {atb_c.Periodo}"); }
                        if (atb_c.Valor > 0) { Console.WriteLine($"Valor: R${atb_c.Valor:F2}"); }
                        Console.WriteLine($"Estacionado: {atb_c.Estacionado}");
                      
                        Console.WriteLine("___________________");

                        Console.WriteLine("\nDados do Veículo:");
                        Console.WriteLine($"Nome do veículo: {atb_v.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {atb_v.TipoVeiculo}");
                        Console.WriteLine($"Cor: {atb_v.Cor}");
                        Console.WriteLine($"Placa: {atb_v.Placa}");
                        Console.WriteLine($"Credencial de acesso: {atb_v.Credencial_Acesso}\n");
                        
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
