﻿using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.DataBase.EF_CRUD;
using SistemaDeEstacionamento.Features_Execucoes;
using SistemaDeEstacionamento.Storage;
using SistemaDeEstacionamento.System_Config;

namespace SistemaDeEstacionamento.Main
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            bool execucao=true;

            #region Instanciações

            MyDbContext conexao = new MyDbContext();

            StorageVehicle aux_V = new StorageVehicle();

            RandomCredential aux_R = new RandomCredential();

            Insert_ef Aux_ins = new Insert_ef();

            Venancies Aux_qv= new Venancies();

            DeleteRecord_EF Aux_dlt = new DeleteRecord_EF();

            Tariffs Aux_t = new Tariffs();

            QueryAll_EF Aux_Q = new QueryAll_EF();

            Query_specific_EF Aux_QE = new Query_specific_EF();

            Query_Parkeds_EF Aux_PK=new Query_Parkeds_EF();

            Reports Aux_R=new Reports();

            Storage_Config Aux_s=new Storage_Config();

            #endregion

            int op = 1;

            bool validacao = conexao.ValidarConexao();
            while (validacao && execucao)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("SistemaDeEstacionamento");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Registrar Entrada de Veículo/Moto");
                Console.WriteLine("2. Registrar Saída de Veículo/Moto");
                Console.WriteLine("3. Consultar Vagas Disponíveis");
                Console.WriteLine("4. Consultar veículos estacionados");
                Console.WriteLine("5. Deletar Registro");
                Console.WriteLine("6. Ver Histórico de todos os Clientes/Veículos");
                Console.WriteLine("7. Realizar consulta específica (cliente/veículo)");
                Console.WriteLine("8. Exibir Tarifas");
                Console.WriteLine("9. Relatórios Gerenciais (Admin)");
                Console.WriteLine("10. Configurações do Sistema (Admin)");
                Console.WriteLine("11. Sair");
                Console.WriteLine("============================================");
                Console.WriteLine("Escolha uma opção:");
                while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 10)
                {
                    Console.WriteLine("\nOpção inválida. Digite um digito, sendo de 1 a 10.");
                }
                switch (op)
                {
                    case 1:
                        Aux_ins.Insert_EF();
                        break;

                    case 2:
                        Aux_ins.Insert_CheckOut();
                        break;

                    case 3:
                        Aux_qv.Vacancy_check();
                        break;

                    case 4:
                        Aux_PK.Query_parked();
                        break;

                    case 5:
                        Aux_dlt.Delete_EF();
                        break;

                    case 6:
                        Aux_Q.Query_All();
                        break;

                    case 7:
                        Aux_QE.Query_specific();
                        break;

                    case 8:
                        Aux_t.Exibition_tariffs();
                        break;

                    case 9:
                        Aux_R.S_Reports();
                        break;

                    case 10:
                        Aux_s.Settings_Menu();
                        break;

                    case 11:
                        Console.WriteLine("\nPrograma Encerrado.");
                        execucao = false; 
                        return;
                }
            }
        }
    }
}

