using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.IStorage___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Storage
{
    internal class StorageClient : AtributesClient, IStorage_Client
    {
        VehicleCheckOut aux_co = new VehicleCheckOut();
        QueryCredendital aux_Q = new QueryCredendital();

        public string S_Name()
        {
            bool aux1 = true;
            string nomeCliente=string.Empty;
            while (aux1)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("\nDigite o nome do cliente:");
                 nomeCliente = Console.ReadLine().TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(Nome_Cliente))
                {
                    Console.WriteLine("\nO nome do cliente não pode ser nulo.");
                }
                else
                {
                    aux1 = false;
                }
            }
            return nomeCliente;
        }

        public DateTime S_CheckIn()
        {
            DateTime entrada = DateTime.Now;
           
            return entrada;
        }

        

        public DateTime S_CheckOut()
        {

            bool validacao1 = true;
            bool validacao2 = false;
            DateTime saida=DateTime.Now;
            while (validacao1)
            {
                Console.WriteLine("\nInforme a credencial do cliente:");
                string Credencial = Console.ReadLine().TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(Credencial))
                {
                    Console.WriteLine("\nO valor informado não pode ser nulo.");
                }
                else
                {
                    validacao1 = false;

                    bool val=aux_Q.QueryCredencial_EF(Credencial);
                    if (val == true)
                    {
                        validacao2 = true;
                    }
                    else 
                    {
                        validacao2 = false;
                    }
                }
            }
            while (validacao2)
            {
                Console.WriteLine("\nDados do cliente e veículo:");
                Console.WriteLine("============================================");


                //Incrementar uma funcionalidade irá realizar a query conforme o nome do cliente, exibir os dados do veículo de vinculação e o check-in de entrada ao estacionamento


                Console.WriteLine("============================================");
                Console.WriteLine("\nDeseja confirmar o check-out? ");
                Console.WriteLine("\n1. Sim");
                Console.WriteLine("2. Não");
                Console.WriteLine("============================================");
                if (int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 2)
                {
                    Console.WriteLine("\nOpção inválida. Digite (1) para 'Sim' ou (2) para 'Não'.");
                }
                else if (op.Equals(1))
                {
                    validacao2 = false;

                    saida = DateTime.Now;

                }
                else if (op.Equals(2))
                {
                    validacao2 = false;

                    Program.Main(ref_args);

                }
            }
            return saida;
        }
    }
}
