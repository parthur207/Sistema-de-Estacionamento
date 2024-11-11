using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal class Storage_Config : FinalValue
    {

        private void Settings_Menu()
        {
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
                    break;
                case 2:
                    break;
                case 3:
                    Program.Main(ref_args);
                    break;
            }
        }
    }
}
