﻿using SistemaDeEstacionamento.Atributes;
using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.DataBase.IEF_Interface;
using SistemaDeEstacionamento.Features_Execucoes;
using SistemaDeEstacionamento.Storage;

namespace SistemaDeEstacionamento.DataBase.EF_CRUD
{
    internal class Insert_ef : StorageClient , IExecution_ef
    {
        public void Insert_EF()
        {
            int id_vehicle;
            string nomeCliente = S_Name();
            DateTime entrada = S_CheckIn();
            string credencialAcesso = CredentialRadom();

            Tipo_Veiculo tipoVeiculo = S_VehicleType();
            string tipoVeiculo_string= tipoVeiculo.ToString();
            string nomeVeiculo = S_VehicleName();
            string cor = S_VehicleColor();

            string placa = S_VehiclePlate();

            Venancies v = new Venancies();

            if (tipoVeiculo_string == "Carro" || tipoVeiculo_string == "Caminhao")
            {
                id_vehicle = 1;
                var hávagas = v.Validation_Venancies(id_vehicle);

                if (hávagas.Item1 == false)
                {
                    Console.WriteLine($"\nNão há vagas disponíveis para {tipoVeiculo}.\n");
                    return; // Retorna ao loop do Main, sem recursão
                }
                else
                {
                    var parking = new AtributesParking();
                    parking.AlterarNumeroVagasDisponiveis(-1, id_vehicle);
                }
            }
            else
            {
                id_vehicle = 2;
                var hávagas = v.Validation_Venancies(id_vehicle);

                if (hávagas.Item1 == false)
                {
                    Console.WriteLine($"\nNão há vagas disponíveis para {tipoVeiculo}.\n");
                    return;
                }
                else
                {
                    var parking = new AtributesParking();
                    parking.AlterarNumeroVagasDisponiveis(-1, id_vehicle);
                }
            }

            try
            {
                using (var contextoIns_C = new MyDbContext())
                {
                    var novoCliente = new AtributesClient
                    {
                        Nome_Cliente = nomeCliente,
                        Entrada = entrada,
                        Credencial_Acesso = credencialAcesso,
                        Estacionado = true,
                    };
                    contextoIns_C.Tabela_Clientes.Add(novoCliente);
                    contextoIns_C.SaveChanges();
                }
                using (var contextoIns_V = new MyDbContext())
                {
                    var novoVeiculo = new AtributesVehicle
                    {
                        TipoVeiculo = tipoVeiculo_string,
                        Nome_Veiculo = nomeVeiculo,
                        Cor = cor,
                        Placa = placa,
                        Credencial_Acesso = credencialAcesso,
                    };
                
                    contextoIns_V.Tabela_Veiculos.Add(novoVeiculo);
                    contextoIns_V.SaveChanges();
                }
                Console.WriteLine("\n============================================");
                Console.WriteLine("\nCliente e veículo inclusos com sucesso.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro na tentativa de inserir os dados.\nErro: {ex.ToString()}\n");
            }
        }

        public void Insert_CheckOut()
        {
            int id_vehicle;
            FinalValue auxPg = new FinalValue();
            double preco;
            var Resultado = S_CheckOut(); // Resultado.Item1 = INICIO | Resultado.Item2 = FINAL | Resultado.Item3 = CREDENCIAL | Resultado.Item4 = True, ou false (existencia da credencial)
            TimeSpan periodo = Period_CheckOut(Resultado.Item1, Resultado.Item2);
            if (Resultado.Item3=="__") { return; }
            try
            {
                if (Resultado.Item4 == true) {
                    using (var contextoIns_checkout = new MyDbContext())
                    {
                        var cliente = contextoIns_checkout.Tabela_Clientes.FirstOrDefault(x => x.Credencial_Acesso.Equals(Resultado.Item3));
                        var veiculo = contextoIns_checkout.Tabela_Veiculos.FirstOrDefault(x => x.Credencial_Acesso.Equals(Resultado.Item3));
                        if (veiculo.TipoVeiculo=="Carro" || veiculo.TipoVeiculo=="Caminhao") {
                            id_vehicle = 1;
                            preco = auxPg.Pagamento(periodo, id_vehicle);
                        }
                        else
                        {
                            id_vehicle = 2;
                            preco = auxPg.Pagamento(periodo, id_vehicle);
                        }
                        Console.WriteLine("\n============================================");
                        Console.WriteLine("CheckOut:");
                        Console.WriteLine($"\nValor final a ser pago: {preco}");
                        Console.WriteLine("============================================");
                        Console.WriteLine("\nDeseja confirmar o checkout?\n(1. Sim | 2. Não)");
                        if (!int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 2)
                        {
                            Console.WriteLine("\nOpção inválida. É necessário digitar (1 - sim) ou (2 - Não).");
                            return;
                        }
                        else if (op != 1)
                        {
                            Console.WriteLine("\nAção de check-out cancelada.");
                            return; // Sai do método e retorna ao menu principal
                        }
                        else
                        {
                            var parking = new AtributesParking();
                            parking.AlterarNumeroVagasDisponiveis(1, id_vehicle);
                     
                        }
                        cliente.Saida = Resultado.Item2;
                        cliente.Periodo = periodo;
                        cliente.Valor = preco;
                        cliente.Estacionado = false;
                        contextoIns_checkout.SaveChanges();
                        Console.WriteLine("\nCheckout concluído.");
                        Console.WriteLine("Número de vagas disponíveis atualizado.\n");
                        }
                    }
                
                else
                {
                    Console.WriteLine("\nA credencial informada não existe.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado ao executar a ação.\nErro: {ex.Message}\n");
            }
        }
    }
}
