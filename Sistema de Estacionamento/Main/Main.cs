using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Storage;

namespace Sistema_de_Estacionamento.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            #region Instancições
            StorageClient aux_C = new StorageClient();

            MyDbContext conexao = new MyDbContext();

            StorageVehicle aux_V = new StorageVehicle();

            RandomCredential aux_R = new RandomCredential();

            Insert_ef Aux_ins = new Insert_ef();

            Venancies Aux_q = new Venancies();

            #endregion

            int op = 1;

            bool validacao = conexao.ValidarConexao();
            while (validacao)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("Sistema de Estacionamento");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Registrar Entrada de Veículo/Moto");
                Console.WriteLine("2. Registrar Saída de Veículo/Moto");
                Console.WriteLine("3. Consultar Vagas Disponíveis");
                Console.WriteLine("4. Deletar Registro");
                Console.WriteLine("5. Ver Histórico de Veículos");
                Console.WriteLine("6. Exibir Tarifas");
                Console.WriteLine("7. Relatórios Gerenciais (Admin)");
                Console.WriteLine("8. Configurações do Sistema (Admin)");
                Console.WriteLine("9. Sair");
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
                        Aux_q.Vacancy_check();
                        break;

                    case 4:
                        //Incremento de direcionamento ao método
                        break;

                    case 5:
                        //Incremento de direcionamento ao método
                        break;

                    case 6:
                        //Incremento de direcionamento ao método
                        break;

                    case 7:
                        //Incremento de direcionamento ao método
                        break;

                    case 8:

                        //encerrar todas as reservas de veículos.
                        return;
                }

            }
        }
    }
}

