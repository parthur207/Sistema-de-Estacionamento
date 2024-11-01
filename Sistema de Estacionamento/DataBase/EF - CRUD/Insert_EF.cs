using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Main;
using Sistema_de_Estacionamento.Storage;
using Sistema_de_Estacionamento.System___Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF
{
    internal class Insert_ef : RandomCredential, IExecution_ef
    {
        public void Insert_EF()
        {
            int id_vehicle;

            string nomeCliente = S_Name();
            DateTime entrada = S_CheckIn();
            string credencialAcesso = CredentialRadom();

            Tipo_Veiculo tipoVeiculo = S_VehicleType();
            string nomeVeiculo = S_VehicleName();
            string cor = S_VehicleColor();
            string placa = S_VehiclePlate();

            Venancies v = new Venancies();

            if (tipoVeiculo == Tipo_Veiculo.Carro || tipoVeiculo == Tipo_Veiculo.Caminhão)
            {
                id_vehicle = 1;
                var hávagas = v.Validation_Venancies(id_vehicle);

                if (hávagas.Item1 == true)
                {
                    var parking = new CarTruck_Parking();
                    parking.AlterarNumeroVagasDisponiveis(-1, id_vehicle);
                }
                else
                {
                    Console.WriteLine($"\nNão há vagas disponíveis para {tipoVeiculo}.");
                    Program.Main(ref_args);
                }
            }
            else
            {
                id_vehicle = 2;
                var hávagas = v.Validation_Venancies(id_vehicle);

                if (hávagas.Item1 == true)
                {
                    var parking = new CarTruck_Parking();
                    parking.AlterarNumeroVagasDisponiveis(-1, id_vehicle);
                }
                else
                {
                    Console.WriteLine($"\nNão há vagas disponíveis para {tipoVeiculo}.");
                    Program.Main(ref_args);
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
                        Placa = placa
                    };
                    contextoIns_C.Tabela_Clientes.Add(novoCliente);
                    contextoIns_C.SaveChanges();
                }
                using (var contextoIns_V = new MyDbContext())
                {
                    var novoVeiculo = new AtributesVehicle
                    {
                        TipoVeiculo = tipoVeiculo,
                        Nome_Veiculo = nomeVeiculo,
                        Cor = cor,
                        Placa = placa,
                        Credencial_Acesso = credencialAcesso,
                    };

                    contextoIns_V.Tabela_Veiculos.Add(novoVeiculo);
                    contextoIns_V.SaveChanges();

                    var vaga = contextoIns_V.Estacionamento.FirstOrDefault(x => x.Id.Equals(id_vehicle));

                }
                Console.WriteLine("\nCliente e veiculo inclusos com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorre um erro na tentativa de inserir os dados.\nErro: {ex.Message}");
                Program.Main(ref_args);
            }
        }

        public void Insert_CheckOut()
        {

            int id_vehicle;
            FinalValue auxPg = new FinalValue();

            var Resultado = S_CheckOut();//Resultado.Item1= INICIO |  Resultado.Item2= FINAL |  Resultado.Item3=CREDENCIAL
            TimeSpan periodo = Period_CheckOut(Resultado.Item1, Resultado.Item2);
            double preco = auxPg.Pagamento(periodo);

            try
            {
                using (var contextoIns_checkout = new MyDbContext())
                {
                    var cliente = contextoIns_checkout.Tabela_Clientes.FirstOrDefault(x => x.Credencial_Acesso.Equals(Resultado.Item3));

                    var veiculo = contextoIns_checkout.Tabela_Veiculos.FirstOrDefault(x => x.Credencial_Acesso.Equals(Resultado.Item3));

                    Console.WriteLine("\nCheckOut:");

                    Console.WriteLine($"\nValor final a ser pago: {cliente.Valor}");
                    Console.WriteLine("============================================");
                    Console.WriteLine("\nDeseja confirmar o checkout?\nn(1. Sim | 2. Não)");
                    if (int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 2)
                    {
                        Console.WriteLine("\nOpção inválida. É necessário digitar (1 - sim) ou (2 - Não).");
                        Program.Main(ref_args);
                    }
                    else if (op != 1)
                    {
                        Program.Main(ref_args);
                    }
                    else
                    {
                        if (veiculo.TipoVeiculo == Tipo_Veiculo.Carro || veiculo.TipoVeiculo == Tipo_Veiculo.Caminhão)
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
                        AtributesClient atributesVehicle = new AtributesClient
                        {
                            Saida = Resultado.Item2,
                            Periodo= periodo,
                            Valor=preco,
                            Estacionado =false,
                        };
                        cliente.Tabela_Clientes.Add(atributesVehicle);
                        contextoIns_checkout.SaveChanges();
                        Console.WriteLine("\nCheckout concluído.");
                        Console.WriteLine("Número de vagas disponíveis atualizado.");
                    }
                }
                Program.Main(ref_args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado ao executar a ação.\nErro: {ex.Message}");
                Program.Main(ref_args);

            }
        }
    }
}
    
