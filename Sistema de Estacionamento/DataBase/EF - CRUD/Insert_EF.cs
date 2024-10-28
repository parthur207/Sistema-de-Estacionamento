using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Main;
using Sistema_de_Estacionamento.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF
{
    internal class Insert_ef: RandomCredential, IExecution_ef
    {
        public void Insert_EF()
        {   
            string nomeCliente = S_Name();
            DateTime entrada=S_CheckIn();
            string credencialAcesso = C_Radom();
            //DateTime saida = S_CheckOut();
            //TimeSpan periodo = CheckOut(entrada, saida);

            Tipo_Veiculo tipoVeiculo = S_VehicleType();
            string nomeVeiculo=S_VehicleName();
            string cor= S_VehicleColor();
            string placa= S_VehiclePlate();

            try
            {
                using (var contextoIns_C = new MyDbContext())
                {

                    var novoCliente = new AtributesClient
                    {
                        Nome_Cliente = nomeCliente,
                        Entrada = entrada,
                        Credencial_Acesso = credencialAcesso,
                        //Saida = saida,
                        //Periodo= periodo,
                    };
                    contextoIns_C.Tabela_Clientes.Add(novoCliente);
                    contextoIns_C.SaveChanges();
                }
                using (var contextoIns_V = new MyDbContext())
                {
                    var novoVeiculo = new AtributesVehicle
                    {
                        TipoVeiculo = tipoVeiculo,
                        Nome_Veiculo= nomeVeiculo,
                        Cor= cor,
                        Placa= placa,
                    };

                    contextoIns_V.Tabela_Veiculos.Add(novoVeiculo);
                    contextoIns_V.SaveChanges();
                }
                Console.WriteLine("\nCliente e veiculo inclusos com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorre um erro na tentativa de inserir os dados. \nErro: {ex.Message}");
                Program.Main(ref_args);
            }
        }

        public void Insert_CheckOut() 
        {
            FinalValue auxPg= new FinalValue();

            var Resultado = S_CheckOut();//Resultado.Item1= INICIO |  Resultado.Item2= FINAL |  Resultado.Item3=CREDENCIAL
            TimeSpan periodo = Period_CheckOut(Resultado.Item1, Resultado.Item2);
            double preco = auxPg.Pagamento(periodo);

            try
            {
                using (var contextoIns_checkout = new MyDbContext())
                {
                    var cliente = contextoIns_checkout.Tabela_Clientes.FirstOrDefault(x => x.Credencial_Acesso.Equals(Resultado.Item3));

                    if (cliente != null)
                    {
                        cliente.Final = Resultado.Item2;
                        cliente.Periodo = periodo;
                        cliente.Preco = preco;

                        contextoIns_checkout.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("\nRegistro não encontrado para a credencial especificada.");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado ao executar a ação.\nErro: {ex.Message}");
            }
        }
    }
}
