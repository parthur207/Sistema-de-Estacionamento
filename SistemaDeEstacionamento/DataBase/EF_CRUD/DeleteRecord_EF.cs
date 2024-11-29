using SistemaDeEstacionamento.Atributes;
using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.DataBase.IEF_Interface;

namespace SistemaDeEstacionamento.DataBase.EF_CRUD
{
    internal class DeleteRecord_EF : ValidacaoCredendital, IExecution_ef
    {

        QueryCredentialOrPlate_EF query=new QueryCredentialOrPlate_EF();
        public void Delete_EF() 
        {
            
            int id_vehicle, op;
            Console.WriteLine("\nDigite a credencial que deseja realizar a exclusão:");
            string credencial = Console.ReadLine().ToUpper().Trim();

            bool validacao = ValidacaoCredencial_EF(credencial);
            
            if (validacao == false)
            {
                Console.WriteLine("\nCredencial não encontrada.\n");
                return;
            }
            else
            {
                query.QueryCredential_EF(credencial);

                Console.WriteLine("Deseja prosseguir com a exclusão?\n1.Sim | 2.Não");
                if (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 2)
                {
                    Console.WriteLine("\nO valor fornecido é inválido. Digite (1) para 'Sim' ou (2) para 'Não'");
                   
                }
                else if (op == 1)
                {
                        var dados_delete = query.GetDadosQuery();

                        using (var ContextDelete = new MyDbContext())
                        {
                            if (dados_delete.Item1.Estacionado == true)
                            {

                                if (dados_delete.Item2.TipoVeiculo == "Carro" || dados_delete.Item2.TipoVeiculo =="Caminhao")
                                {
                                    id_vehicle = 1;
                                    var parking = new AtributesParking();
                                    parking.AlterarNumeroVagasDisponiveis(1, id_vehicle);
                                }
                                else
                                {
                                    id_vehicle = 2;
                                    var parking = new AtributesParking();
                                    parking.AlterarNumeroVagasDisponiveis(1, id_vehicle);
                                }
                            }
                            ContextDelete.Tabela_Clientes.Remove(dados_delete.Item1);
                            ContextDelete.Tabela_Veiculos.Remove(dados_delete.Item2);
                            ContextDelete.SaveChanges();
                            Console.WriteLine("\nExclusão efetuada com sucesso.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nNenhuma ação realizada.");
                }
            }
        }
    }
}


