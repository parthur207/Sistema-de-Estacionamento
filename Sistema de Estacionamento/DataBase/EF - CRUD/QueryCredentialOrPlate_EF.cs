using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.IStorage___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF___CRUD
{
    internal class QueryCredentialOrPlate_EF : ValidacaoCredendital, IExecution_ef, IStorage_Vehicle
    {
        protected  AtributesClient dadosQuery_c { get; private set; }
        protected AtributesVehicle dadosQuery_v { get; private set; }

        public void Storage_Query()
        {
            Console.WriteLine("\nDigite o número correspondente a consulta:");
            Console.WriteLine("1) Placa");
            Console.WriteLine("2) Credencial");

            if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 1 || numero > 2)
            {
                Console.WriteLine("\nÉ necessário digitar um numero. Sendo 1 ou 2.");
                return;
            }
            else
            {
                if (numero == 1)
                {
                    Console.WriteLine("\nDigite a placa do veículo:");
                    string placa = Console.ReadLine().Trim().ToUpper();



                    //Placa padrão mercosul: ABC1D23
                    if (string.IsNullOrEmpty(placa) || placa.Length != 7)
                    {
                        Console.WriteLine("\nO conjunto de caracteres informado não equivale a 7.");
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < placa.Length; i++)
                        {
                            if (!char.IsLetter(placa[0]) || !char.IsLetter(placa[1]) || !char.IsLetter(placa[2]) || !char.IsNumber(placa[3]) || !char.IsLetter(placa[4]) || !char.IsNumber(Placa[5]) || !char.IsNumber(placa[6]))
                            {
                                Console.WriteLine("\nA placa informada não está nos padrões mercosul. Padrão exemplo: ABC1D23");
                                break;
                            }
                            else
                            {
                                QueryPlate_EF(placa);
                            }
                        }
                    }
                }
                else if (numero == 2)
                {
                    Console.WriteLine("Digite a credencial:");
                    string credencial = Console.ReadLine().Trim().ToUpper();

                    if (string.IsNullOrEmpty(credencial) || credencial.Length != 6)
                    {

                        Console.WriteLine("\nValor inválido.");
                    }
                    else
                    {
                        bool v = ValidacaoCredencial_EF(credencial);
                        if (v == false)
                        {
                            Console.WriteLine("\nA credencial informada não foi encontrada.");
                        }
                        else
                        {
                            QueryCredential_EF(credencial);
                        }
                    }
                }
            }
        }
      
        public void QueryPlate_EF(string Placa)
        {
            try
            {
                using (var contextoQuery_Credential = new MyDbContext())
                {
                    dadosQuery_c = contextoQuery_Credential.Tabela_Clientes.Where(x => x.Placa.Equals(Placa)).FirstOrDefault();
                    dadosQuery_v = contextoQuery_Credential.Tabela_Veiculos.Where(x => x.Placa.Equals(Placa)).FirstOrDefault();

                    Console.WriteLine("============================================");
                    Console.WriteLine("\nDados do cliente:");
                    Console.WriteLine($"Nome:{dadosQuery_c.Nome_Cliente}");
                    Console.WriteLine($"Credencial de acesso: {dadosQuery_c.Credencial_Acesso}");
                    Console.WriteLine($"Entrada:{dadosQuery_c.Entrada}");
                    if (dadosQuery_c.Saida != null)
                    {
                        Console.WriteLine($"Saída: {dadosQuery_c.Saida}");
                    }
                    if (dadosQuery_c.Periodo != null)
                    {
                        Console.WriteLine($"Periodo: {dadosQuery_c.Periodo}");
                    }
                    Console.WriteLine("============================================");
                    Console.WriteLine("\nDados do veículo:");
                    Console.WriteLine($"Estacionado: {dadosQuery_c.Estacionado}");
                    Console.WriteLine($"Nome veiculo: {dadosQuery_v.Nome_Veiculo}");
                    Console.WriteLine($"Tipo de veículo: {dadosQuery_v.TipoVeiculo}");
                    Console.WriteLine($"Cor:{dadosQuery_v.Cor}");
                    Console.WriteLine($"Placa: {dadosQuery_v.Placa}");
                    Console.WriteLine("============================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado. \nErro: {ex.Message}");
            }
        }  
        
        public void QueryCredential_EF(string Credencial)
        {
           
            try 
            {
                using (var contextoQuery_Credential=new MyDbContext())
                {
                      dadosQuery_c = contextoQuery_Credential.Tabela_Clientes.Where(x => x.Credencial_Acesso.Equals(Credencial)).FirstOrDefault();
                      dadosQuery_v = contextoQuery_Credential.Tabela_Veiculos.Where(x=>x.Credencial_Acesso.Equals(Credencial)).FirstOrDefault();

                    
                        Console.WriteLine("============================================");
                        Console.WriteLine("\nDados do cliente:");
                        Console.WriteLine($"Nome:{dadosQuery_c.Nome_Cliente}");
                        Console.WriteLine($"Credencial de acesso: {dadosQuery_c.Credencial_Acesso}");
                        Console.WriteLine($"Entrada:{dadosQuery_c.Entrada}");
                        if (dadosQuery_c.Saida !=null) {
                            Console.WriteLine($"Saída: {dadosQuery_c.Saida}");
                        }
                        if (dadosQuery_c.Periodo != null) 
                        {
                            Console.WriteLine($"Periodo: {dadosQuery_c.Periodo}");
                        }
                        Console.WriteLine("============================================");
                        Console.WriteLine("\nDados do veículo:");
                        Console.WriteLine($"Estacionado: {dadosQuery_c.Estacionado}");
                        Console.WriteLine($"Nome veiculo: {dadosQuery_v.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {dadosQuery_v.TipoVeiculo}");
                        Console.WriteLine($"Cor:{dadosQuery_v.Cor}");
                        Console.WriteLine($"Placa: {dadosQuery_v.Placa}");
                        Console.WriteLine("============================================");
                }    
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"\nOcorreu um erro inesperado. \nErro: {ex.Message}");
            }
        }

        public (AtributesClient, AtributesVehicle) GetDadosQuery()
        {
            return (dadosQuery_c,dadosQuery_v);
        }
    }
}
