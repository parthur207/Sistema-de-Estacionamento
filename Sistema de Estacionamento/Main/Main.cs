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

            Insert_ef aux_ins=new Insert_ef();
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
                        aux_C.S_Name();

                        aux_V.S_VehicleType();
                        aux_V.S_VehicleName();
                        aux_V.S_VehiclePlate();
                        aux_V.S_VehicleColor();


                        aux_C.S_CheckIn();//Credencial é gerada dentro do checkin

                        break;

                    case 2:
                        aux_C.S_CheckOut();
                        aux_ins.Insert_CheckOut();
                        break;

                    case 3:
                        //implemento de direicionamento ao método
                        break;

                    case 4:
                        //implemento de direicionamento ao método
                        break;

                    case 5:
                        //implemento de direicionamento ao método
                        break;

                    case 6:
                        //implemento de direicionamento ao método
                        break;

                    case 7:
                        //implemento de direicionamento ao método
                        break;

                    case 8:

                        //Encerrar conexão com o db

                        //encerrar todas as reservas de veículos.
                        return;
                }

            }
        }
    }
}

