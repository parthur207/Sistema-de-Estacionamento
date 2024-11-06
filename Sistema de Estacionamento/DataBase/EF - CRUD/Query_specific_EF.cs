using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.IStorage___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                        Console.WriteLine("\nDigite o nome do veículo:");
                        atributo= Console.ReadLine().TrimStart().TrimEnd();

                        if (string.IsNullOrEmpty(atributo))
                        {
                            Console.WriteLine("\nO nome do veículo não pode ser vazio.");
                        }
                        else
                        {
                            Query_exe(categoria,atributo);
                        }

                        break;

                    case 3:

                        categoria = 3;
                        Console.WriteLine("\nInforme o número correspondente ao tipo da consulta:");
                        Console.WriteLine("1. Carro");
                        Console.WriteLine("2. Caminhão");
                        Console.WriteLine("3. Moto");

                        if(!int.TryParse(Console.ReadLine(),out int atributo_numeral))
                        {
                        Console.WriteLine("\nOpção inválida. É necessário informar um número de 1 a 3"); 
                        }
                        else
                        {
                            atributo=atributo_numeral.ToString();
                            Query_exe(categoria, atributo);
                        }
                       
                        break;

                    case 4:
                        Program.Main(ref_args);
                        break;
                }
            }
        

        private void Query_exe(int categoria, string atributo)
        {
            if (categoria == 1)
            {
                using (var context_QueryDT = new MyDbContext())
                {
                    var listaCredenciais = context_QueryDT.Tabela_Clientes.Where(x => x.Entrada.Equals(atributo))
                        .Select(x => x.Credencial_Acesso).ToList();

                    foreach (var credencial in listaCredenciais)
                    {
                        var atb_C = context_QueryDT.Tabela_Clientes.FirstOrDefault(x => x.Credencial_Acesso.Equals(credencial));
                        var atb_V = context_QueryDT.Tabela_Veiculos.FirstOrDefault(x => x.Credencial_Acesso.Equals(credencial));

                        Console.WriteLine("======================================");
                        Console.WriteLine("Dados do Cliente:");
                        Console.WriteLine($"\nNome cliente: {atb_C.Nome_Cliente}");
                        Console.WriteLine($"Entrada: {atb_C.Entrada}");
                        Console.WriteLine($"Saída:{atb_C.Saida}");
                        if (atb_C.Periodo != null) { Console.WriteLine($"Periodo:{atb_C.Periodo}"); }
                        if (atb_C.Valor != null) { Console.WriteLine($"Valor: R${atb_C.Valor}"); }
                        Console.WriteLine($"Estacionado: {atb_C.Estacionado}");

                        Console.WriteLine("___________________");

                        Console.WriteLine("Dados do Veículo:");
                        Console.WriteLine($"Nome do veículo: {atb_V.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {atb_V.TipoVeiculo}");
                        Console.WriteLine($"Cor: {atb_V.Cor}");
                        Console.WriteLine($"Placa: {atb_V.Placa}");
                        Console.WriteLine($"Credencial de acesso: {atb_V.Credencial_Acesso}");
                        Console.WriteLine("======================================");
                    }
                    Program.Main(ref_args);
                }
            }
            else if (categoria == 2)
            {
                using (var context_QueryV = new MyDbContext())
                {
                    var listaCredenciais = context_QueryV.Tabela_Veiculos.Where(x => x.Nome_Veiculo.Equals(atributo))
                        .Select(x => x.Credencial_Acesso).ToList();
                    Console.WriteLine($"\nRegistros vinculados ao veículo ({atributo}):");

                    foreach (var credencial in listaCredenciais)
                    {
                        var atb_C = context_QueryV.Tabela_Clientes.FirstOrDefault(x => x.Credencial_Acesso.Equals(credencial));
                        var atb_V = context_QueryV.Tabela_Veiculos.FirstOrDefault(x => x.Credencial_Acesso.Equals(credencial));
                        Console.WriteLine("======================================");
                        Console.WriteLine("Dados do Cliente:");
                        Console.WriteLine($"\nNome cliente: {atb_C.Nome_Cliente}");
                        Console.WriteLine($"Entrada: {atb_C.Entrada}");
                        Console.WriteLine($"Saída:{atb_C.Saida}");
                        if (atb_C.Periodo != null) { Console.WriteLine($"Periodo:{atb_C.Periodo}"); }
                        if (atb_C.Valor != null) { Console.WriteLine($"Valor: R${atb_C.Valor}"); }
                        Console.WriteLine($"Estacionado: {atb_C.Estacionado}");

                        Console.WriteLine("___________________");

                        Console.WriteLine("Dados do Veículo:");
                        Console.WriteLine($"Nome do veículo: {atb_V.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {atb_V.TipoVeiculo}");
                        Console.WriteLine($"Cor: {atb_V.Cor}");
                        Console.WriteLine($"Placa: {atb_V.Placa}");
                        Console.WriteLine($"Credencial de acesso: {atb_V.Credencial_Acesso}");
                        Console.WriteLine("======================================");
                    }
                    Program.Main(ref_args);
                }
            }
            else
            {
                string tipo_veículo;
                if (atributo == "1")
                {
                    tipo_veículo = "Carro";
                }
                else if (atributo == "2")
                {
                    tipo_veículo = "Caminhao";
                }
                else
                {
                    tipo_veículo = "Moto";
                }
                using (var context_QueryTp = new MyDbContext())
                {
                    var listaCredenciais = context_QueryTp.Tabela_Veiculos.Where(x => x.TipoVeiculo.Equals(tipo_veículo))
                    .Select(x => x.Credencial_Acesso).ToList();

                    Console.WriteLine($"\nRegistros vinculados ao tipo ({tipo_veículo}):");
                    foreach (var credencial in listaCredenciais)
                    {
                        var atb_C = context_QueryTp.Tabela_Clientes.FirstOrDefault(x => x.Credencial_Acesso.Equals(credencial));
                        var atb_V = context_QueryTp.Tabela_Veiculos.FirstOrDefault(x => x.Credencial_Acesso.Equals(credencial));
                        Console.WriteLine("======================================");
                        Console.WriteLine("Dados do Cliente:");
                        Console.WriteLine($"\nNome cliente: {atb_C.Nome_Cliente}");
                        Console.WriteLine($"Entrada: {atb_C.Entrada}");
                        Console.WriteLine($"Saída:{atb_C.Saida}");
                        if (atb_C.Periodo != null) { Console.WriteLine($"Periodo:{atb_C.Periodo}"); }
                        if (atb_C.Valor != null) { Console.WriteLine($"Valor: R${atb_C.Valor}"); }
                        Console.WriteLine($"Estacionado: {atb_C.Estacionado}");

                        Console.WriteLine("___________________");

                        Console.WriteLine("Dados do Veículo:");
                        Console.WriteLine($"Nome do veículo: {atb_V.Nome_Veiculo}");
                        Console.WriteLine($"Tipo de veículo: {atb_V.TipoVeiculo}");
                        Console.WriteLine($"Cor: {atb_V.Cor}");
                        Console.WriteLine($"Placa: {atb_V.Placa}");
                        Console.WriteLine($"Credencial de acesso: {atb_V.Credencial_Acesso}");
                        Console.WriteLine("======================================");
                    }
                    Program.Main(ref_args);
                }
            }
        }
    }
}

