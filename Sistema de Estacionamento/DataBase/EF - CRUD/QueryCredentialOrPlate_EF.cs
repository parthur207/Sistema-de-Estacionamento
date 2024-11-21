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
    internal class QueryCredentialOrPlate_EF : ValidacaoCredendital, IExecution_ef
    {
        protected  AtributesClient dadosQuery_c { get;  set; }
        protected AtributesVehicle dadosQuery_v { get; set; }

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
                            if (!char.IsLetter(placa[0]) || !char.IsLetter(placa[1]) || !char.IsLetter(placa[2]) || !char.IsNumber(placa[3]) || !char.IsLetter(placa[4]) || !char.IsNumber(placa[5]) || !char.IsNumber(placa[6]))
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
                   
                    var atb_v = contextoQuery_Credential.Tabela_Veiculos.Where(x => x.Placa.Equals(Placa)).FirstOrDefault();

                    var atb_c = contextoQuery_Credential.Tabela_Clientes.FirstOrDefault(x=>x.Credencial_Acesso.Equals(atb_v.Credencial_Acesso));
                    
                    dadosQuery_c = atb_c;
                    dadosQuery_v = atb_v;

                    Console.WriteLine("============================================");
                    Console.WriteLine("\nDados do cliente:");
                    Console.WriteLine($"Nome:{atb_c.Nome_Cliente}");
                    Console.WriteLine($"Credencial de acesso: {atb_c.Credencial_Acesso}");
                    Console.WriteLine($"Entrada:{atb_c.Entrada}");
                    if (atb_c.Saida != null)
                    {
                        Console.WriteLine($"Saída: {atb_c.Saida}");
                    }
                    if (atb_c.Periodo.ToString() != "00:00:00")
                    {
                        Console.WriteLine($"Periodo: {atb_c.Periodo}");
                    }
                    if (atb_c.Valor > 0) { Console.WriteLine($"Valor a pagar: {atb_c.Valor}"); }
                    Console.WriteLine("============================================");
                    Console.WriteLine("\nDados do veículo:");
                    Console.WriteLine($"Estacionado: {atb_c.Estacionado}");
                    Console.WriteLine($"Nome veiculo: {atb_v.Nome_Veiculo}");
                    Console.WriteLine($"Tipo de veículo: {atb_v.TipoVeiculo}");
                    Console.WriteLine($"Cor:{atb_v.Cor}");
                    Console.WriteLine($"Placa: {atb_v.Placa}");
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
                    var atb_c = contextoQuery_Credential.Tabela_Clientes.Where(x => x.Credencial_Acesso.Equals(Credencial)).FirstOrDefault();
                    var atb_v = contextoQuery_Credential.Tabela_Veiculos.Where(x=>x.Credencial_Acesso.Equals(Credencial)).FirstOrDefault();

                    dadosQuery_c = atb_c;
                    dadosQuery_v = atb_v;

                    Console.WriteLine("\n============================================");
                    Console.WriteLine("Dados do cliente:");
                    Console.WriteLine($"\nNome:{atb_c.Nome_Cliente}");
                    Console.WriteLine($"Credencial de acesso: {atb_c.Credencial_Acesso}");
                    Console.WriteLine($"Entrada:{atb_c.Entrada}");
                    if (atb_c.Saida !=null) {
                        Console.WriteLine($"Saída: {atb_c.Saida}");
                    }
                    if (atb_c.Periodo.ToString() != "00:00:00") 
                    {
                        Console.WriteLine($"Periodo: {atb_c.Periodo}");
                    }
                    if (atb_c.Valor > 0) { Console.WriteLine($"Valor a pagar: {atb_c.Valor}"); }
                    Console.WriteLine("\n============================================");
                    Console.WriteLine("Dados do veículo:");
                    Console.WriteLine($"\nEstacionado: {atb_c.Estacionado}");
                    Console.WriteLine($"Nome veiculo: {atb_v.Nome_Veiculo}");
                    Console.WriteLine($"Tipo de veículo: {atb_v.TipoVeiculo}");
                    Console.WriteLine($"Cor: {atb_v.Cor}");
                    Console.WriteLine($"Placa: {atb_v.Placa}");
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
