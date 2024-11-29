using SistemaDeEstacionamento.Atributes;

namespace SistemaDeEstacionamento.System_Config
{
    internal sealed class Storage_Config
    {

        public void Settings_Menu()
        {

            AtributesParking Aux_MT = new AtributesParking();
            AtributesParking Aux_CC = new AtributesParking();
            FixedRate Aux_set= new FixedRate();

            bool val = true;
            int op;

            while (val)
            {

                Console.WriteLine("\n============================================");
                Console.WriteLine("Configurações do Sistema\n");
                Console.WriteLine("Informe o número correspondente:\n");

                Console.WriteLine("1. Alterar o capadidade de vagas disponibilizadas por veículo (Carros|Caminhões / Motos)");
                Console.WriteLine("2. Alterar o valor da tarifa (Valor X Minutos)");
                Console.WriteLine("3. Voltar ao menu principal");
                Console.WriteLine("============================================");
                if (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 3)
                {
                    Console.WriteLine("\nOpção inválida. É necessário digitar um caracter numérico, sendo de 1 a 3.");
                }
                else
                {
                    val = false;

                    switch (op)
                    {
                        case 1:

                            Console.WriteLine("\nSelecione o número correspondente ao tipo de veículo:");
                            Console.WriteLine("1. Carros/Caminhões.");
                            Console.WriteLine("2. Motos");
                            if (!int.TryParse(Console.ReadLine(), out int id) || id < 1 || id > 2)
                            {
                                Console.WriteLine("\nOpção inválida. É necessário informar 1, ou 2.\n");
                            }
                            else
                            {
                                Console.WriteLine("\nInforme a nova capacidade de vagas para o estacionamento:");
                                if (!int.TryParse(Console.ReadLine(), out int NovaCapacidade) || NovaCapacidade < 0)
                                {
                                    Console.WriteLine("\nValor inválido. Repita o processo novamente.\n");
                                    val = true;
                                }
                                else
                                {
                                    if (id == 1)
                                    {
                                        Aux_CC.AlterarNumeroVagas(NovaCapacidade, id);
                                    }
                                    else if (id == 2)
                                    {
                                        Aux_MT.AlterarNumeroVagas(NovaCapacidade, id);
                                    }
                                }
                            }
                            break;

                        case 2:

                            Console.WriteLine("\nInforme o novo valor da tarifa (NovoValor X minutos): ");
                            if (!double.TryParse(Console.ReadLine(), out double novaTarifa) || novaTarifa < 0)
                            {
                                Console.WriteLine("\nValor inválido. É necessário digitar um número, sendo maior que 0.\n");
                            }
                            else
                            {
                                Aux_set.SetTaxa(novaTarifa);
                            }
                            break;
                        case 3:
                            Console.WriteLine();
                            return;
                    }
                }
            }
        }
    }
}
