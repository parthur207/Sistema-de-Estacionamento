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
            DateTime saida = S_CheckOut();
            TimeSpan periodo = CheckOut(entrada, saida);
            
            try
            {
                using (var contexto_ins = new MyDbContext())
                {

                    var novoCliente = new AtributesClient
                    {
                        Nome_Cliente = nomeCliente,
                        Entrada = entrada,
                        Credencial_Acesso = credencialAcesso,
                        Saida = saida,
                        Periodo= periodo,
                    };
                    contexto_ins.Tabela_Clientes.Add(novoCliente);
                    contexto_ins.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorre um erro na tentativa de inserir os dados. \nErro: {ex.Message}");
                Program.Main(ref_args);
            }
        }
    }
}
