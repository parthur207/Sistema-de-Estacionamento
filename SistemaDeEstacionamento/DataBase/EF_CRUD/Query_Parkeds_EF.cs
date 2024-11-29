using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.DataBase.IEF_Interface;

namespace SistemaDeEstacionamento.DataBase.EF_CRUD
{
    internal class Query_Parkeds_EF : IExecution_ef
    {
        
        
        public void Query_parked()
        {
            try
            {
                using (var context_parkeds = new MyDbContext())
                {
                    var numero_estacionados = Get_NumbersParkeds();

                    var Lista_credenciais = context_parkeds.Tabela_Clientes.Where(x => x.Estacionado.Equals(true))
                        .Select(x => x.Credencial_Acesso)
                        .ToList();
                    if (numero_estacionados == 0)
                    {
                        Console.WriteLine("\nNão a veículos estacionados no momento.\n");
                    }
                    else
                    {
                        Console.WriteLine("\n============================================");
                        Console.WriteLine("Clientes/Veículos estacionados:");

                        Console.WriteLine($"\nNumero de veículos estacionados: {numero_estacionados}");
                        foreach (var credencial in Lista_credenciais)
                        {
                            var atb_c = context_parkeds.Tabela_Clientes.Where(x => x.Credencial_Acesso.Equals(credencial)).FirstOrDefault();
                            var atb_v = context_parkeds.Tabela_Veiculos.Where(x => x.Credencial_Acesso.Equals(credencial)).FirstOrDefault();
                            Console.WriteLine("___________________");
                            Console.WriteLine("\nDados do cliente:");
                            Console.WriteLine($"\nNome: {atb_c.Nome_Cliente}");
                            Console.WriteLine($"Credencial de acesso: {atb_c.Credencial_Acesso}");
                            Console.WriteLine($"Entrada: {atb_c.Entrada}");
                            Console.WriteLine("___________________");
                            Console.WriteLine("\nDados do veículo:");
                            Console.WriteLine($"\nEstacionado: {atb_c.Estacionado}");
                            Console.WriteLine($"Nome veiculo: {atb_v.Nome_Veiculo}");
                            Console.WriteLine($"Tipo de veículo: {atb_v.TipoVeiculo}");
                            Console.WriteLine($"Cor: {atb_v.Cor}");
                            Console.WriteLine($"Placa: {atb_v.Placa}\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado.\nErro: {ex.Message}");
            }
        }

        public int Get_NumbersParkeds()
        {
            int Numero_Estacionados=0;
            try
            {
                using (var context_parkeds=new MyDbContext())
                {
                    Numero_Estacionados = context_parkeds.Tabela_Clientes.Count(x => x.Estacionado.Equals(true));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro na tentativa de obtenção do número de veículos estacionados.\nErro: {ex.Message}");
            }
            return Numero_Estacionados;
        }
    }
}
