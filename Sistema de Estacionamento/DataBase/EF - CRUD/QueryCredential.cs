using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF___CRUD
{
    internal class QueryCredential : ValidacaoCredendital, IExecution_ef
    {
        public  AtributesClient dadosQuery_c { get; private set; }
        public AtributesVehicle dadosQuery_v { get; private set; }


        public int Storage_Query()
        {
            Console.WriteLine("\nDigite o número correspondente a consulta:");
            Console.WriteLine("1) Placa");
            Console.WriteLine("2) Credencial");

            if (!int.TryParse(Console.ReadLine(), out int numero) || numero<1 || numero>2)
            {
                Console.WriteLine("\nÉ necessário digitar um numero. Sendo 1 ou 2.");
                Program.Main(ref_args);
            }
            else
            {
                if (numero == 1) {
                    Console.WriteLine("\nDigite ");
                }

            }

            return numero;
        }
        public void QueryCredential_EF(string Credencial)
        {
           
            try {
                using (var contextoQuery_Credential=new MyDbContext())
                {
                      dadosQuery_c = contextoQuery_Credential.Tabela_Clientes.Where(x => x.Credencial_Acesso.Equals(Credencial)).FirstOrDefault();
                      dadosQuery_v = contextoQuery_Credential.Tabela_Veiculos.Where(x=>x.Credencial_Acesso.Equals(Credencial)).FirstOrDefault();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"\nOcorreu um erro inesperado. \nErro: {ex.Message}");
            }
        }

        public void QueryCredential_(string Placa)
        {
            try
            {
                using (var contextoQuery_Credential = new MyDbContext())
                {
                    dadosQuery_c = contextoQuery_Credential.Tabela_Clientes.Where(x => x.Placa.Equals(Placa)).FirstOrDefault();
                    dadosQuery_v = contextoQuery_Credential.Tabela_Veiculos.Where(x => x.Placa.Equals(Placa)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado. \nErro: {ex.Message}");
            }
        }
    }
}
