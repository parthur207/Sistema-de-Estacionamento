using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.DataBase.EF___CRUD;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Storage;
using Sistema_de_Estacionamento.System___Config;

namespace Sistema_de_Estacionamento.Main
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {

            // Variável para controle do loop do menu
            bool continuar = true;

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

            Reports Aux_R=new Reports();

            Storage_Config Aux_s=new Storage_Config();

            #endregion

            int op = 1;

            bool validacao = conexao.ValidarConexao();
            while (validacao && continuar)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("Sistema de Estacionamento");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Registrar Entrada de Veículo/Moto");
                Console.WriteLine("2. Registrar Saída de Veículo/Moto");
                Console.WriteLine("3. Consultar Vagas Disponíveis");
                Console.WriteLine("4. Deletar Registro");
                Console.WriteLine("5. Ver Histórico de todos os Clientes/Veículos");
                Console.WriteLine("6. Realizar consulta específica (cliente/veículo)");
                Console.WriteLine("7. Exibir Tarifas");
                Console.WriteLine("8. Relatórios Gerenciais (Admin)");
                Console.WriteLine("9. Configurações do Sistema (Admin)");
                Console.WriteLine("10. Sair");
                Console.WriteLine("============================================");
                Console.WriteLine("Escolha uma opção:");
                while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 9)
                {
                    Console.WriteLine("\nOpção inválida. Digite um digito, sendo de 1 a 9.");
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
                        Aux_dlt.Delete_EF();
                        break;

                    case 5:
                        Aux_Q.Query_All();
                        break;

                    case 6:
                        Aux_QE.Query_specific();
                        break;

                    case 7:
                        Aux_t.Exibition_tariffs();
                        break;

                    case 8:
                        Aux_R.S_Reports();
                        break;

                    case 9:
                        Aux_s.Settings_Menu();
                        break;

                    case 10:
                        Console.WriteLine("\nPrograma Encerrado.");
                        continuar = false;  // Define 'continuar' como falso para sair do loop
                        break;
                }
            }
        }
    }
}

