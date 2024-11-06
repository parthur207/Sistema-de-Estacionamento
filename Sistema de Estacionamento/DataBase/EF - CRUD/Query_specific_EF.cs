using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.IStorage___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF___CRUD
{
    internal class Query_specific_EF : QueryAll_EF, IExecution_ef
    {
        public void Query_specific()
        {
            int categoria, op;
            string atributo=" ";
            DateOnly Data = DateOnly.FromDateTime(DateTime.Now);// Introduzido com um valor por não poder ser nulo.

            Console.WriteLine("\n1. Realizar consulta por (data)");
            Console.WriteLine("2. Realizar Consulta por (Nome do veículo)");
            Console.WriteLine("3. Realiza consulta por (Tipo de veículo)");
            Console.WriteLine("4. Voltar ao menu principal");
            while (!int.TryParse(Console.ReadLine(),out op) || op<1 || op>4)
            {
                Console.WriteLine("\nOpção inválida. É necessário digitar um número de 1 a 4.");
            }
            switch (op)
            {
                case 1:
                    categoria = 1;
                    Console.WriteLine("\nDigite a data específica da consulta:");
                    atributo = Console.ReadLine().Trim();
                    string formato = "dd/MM/yyyy";

                    if (!DateOnly.TryParseExact(atributo, formato, null, System.Globalization.DateTimeStyles.None, out Data))
                    {
                        Console.WriteLine("\nA data informada não está no formato correto (DD/MM/YYYY).");
                    }
                    else
                    {
                        Query_exe(categoria, atributo);
                    }
                    break;

                    case 2:
                    categoria=2;
                        break;
                    case 3:
                        break;
                    case 4:
                        Program.Main(ref_args);
                        break;
                }
            }
        

        private void Query_exe(int categoria, string atributo)
        {
            if (categoria ==1)
            {
                
            }
            else if (categoria == 2)
            {

            }
            else
            {

            }
        }
    }
}
