using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.Main;
using Sistema_de_Estacionamento.System___Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF___CRUD
{
    internal class DeleteRecord_EF : ValidacaoCredendital, IExecution_ef
    {

        QueryCredentialOrPlate_EF query=new QueryCredentialOrPlate_EF();
        private const string Senha = "Resiliencia2024";
        public void Delete_EF() 
        {
            
            int id_vehicle, op;
            Console.WriteLine("Digite a credencial que deseja realizar a exclusão:");
            string credencial = Console.ReadLine().ToUpper().Trim();

            bool validacao = ValidacaoCredencial_EF(credencial);
            
            if (validacao == false)
            {
                Console.WriteLine("\nCredencial não encontrada.");
                Program.Main(ref_args);
            }
            else
            {
                query.QueryCredential_EF(credencial);

                Console.WriteLine("\nDeseja prosseguir com a exclusão?\n1.Sim | 2.Não");
                if (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 2)
                {
                    Console.WriteLine("\nO valor fornecido é inválido. Digite (1) para 'Sim' ou (2) para 'Não'");
                   
                }
                else if (op == 1)
                {
                    Console.WriteLine("Digite a senha de confirmação:");
                    string senha = Console.ReadLine().Trim();

                    if (senha != Senha)
                    {
                        Console.WriteLine("\nSenha incorreta.");
                        Program.Main(ref_args);
                    }
                    else
                    {


                        var dados_delete = query.GetDadosQuery();

                        using (var ContextDelete = new MyDbContext())
                        {
                            if (dados_delete.Item1.Estacionado == true)
                            {

                                if (dados_delete.Item2.TipoVeiculo == Atributes.Tipo_Veiculo.Carro || dados_delete.Item2.TipoVeiculo == Atributes.Tipo_Veiculo.Caminhao)
                                {
                                    id_vehicle = 1;
                                    var parking = new CarTruck_Parking();
                                    parking.AlterarNumeroVagasDisponiveis(1, id_vehicle);
                                }
                                else
                                {
                                    id_vehicle = 2;
                                    var parking = new MotocycleParking();
                                    parking.AlterarNumeroVagasDisponiveis(1, id_vehicle);
                                }
                            }
                            ContextDelete.Tabela_Clientes.Remove(dados_delete.Item1);
                            ContextDelete.Tabela_Veiculos.Remove(dados_delete.Item2);
                            ContextDelete.SaveChanges();
                            Console.WriteLine("\nExclusão efetuada com sucesso.");

                            Program.Main(ref_args);
                        }
                    }
                }
            }
        }
    }
}

