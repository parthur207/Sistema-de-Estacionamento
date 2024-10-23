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
            Nome_Cliente = S_Name();
            Entrada=S_CheckIn();
            Credencial_Acesso = C_Radom();
            Saida = S_CheckOut();
            Periodo = CheckOut(Entrada, Saida);

            try
            {
                using (var contexto_ins = new MyDbContext())
                {
                    contexto_ins.Tabela_Clientes.Add(Nome_Cliente, Entrada, Credencial_Acesso, Saida, Periodo);
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
