using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal sealed class Storage_Config : FinalValue
    {

        public void Settings_Menu()
        {

            MotocycleParking Aux_MT= new MotocycleParking();
            CarTruck_Parking Aux_CC= new CarTruck_Parking();
            FixedRate Aux_set= new FixedRate();

            bool val = true;
            int op;

            do
            {
                Console.WriteLine("============================================");
                Console.WriteLine("Configurações do Sistema\n");
                Console.WriteLine("\nInforme o número correspondente:\n");

                Console.WriteLine("1. Alterar o número de vagas disponibilizadas por veículo (Carros/Motos)");
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
                }
            }
            while (val);

            switch (op)
            {
                case 1:

                    Console.WriteLine("\nSelecione o número correspondente:");
                    Console.WriteLine("1. Carros/Caminhões.");
                    Console.WriteLine("2. Motos");
                    if(!int.TryParse(Console.ReadLine(), out int id) || id < 1 || id > 2)
                    {
                        Console.WriteLine("\nOpção inválida. É necessário informar 1, ou 2.");
                    }
                    else
                    {
                        Console.WriteLine("\nInforme a nova capacidade de vagas para o estacionamento:");
                        if (!int.TryParse(Console.ReadLine(), out int NovaCapacidade) || id<0)
                        {
                            Console.WriteLine("\nValor inválido. Repita o processo novamente.");
                        }
                        else
                        {
                            if (id==1) 
                            { 
                                Aux_CC.AlterarNumeroVagas(NovaCapacidade);
                            }
                            else if(id==2)
                            {
                                Aux_MT.AlterarNumeroVagas(NovaCapacidade);
                            }
                        }
                    }
                    break;

                case 2:

                    Console.WriteLine("\nInforme o novo valor da tarifa (NovoValor X minutos): ");
                    if(!double.TryParse(Console.ReadLine(), out double novaTarifa) || novaTarifa < 0)
                    {
                        Console.WriteLine("\nValor inválido. É necessário digitar um número, sendo maior que 0.");
                    }
                    else
                    {
                        Aux_set.SetTaxa(novaTarifa);
                    }
                    break;
                case 3:
                    Program.Main(ref_args);
                    break;
            }
        }
    }
}
