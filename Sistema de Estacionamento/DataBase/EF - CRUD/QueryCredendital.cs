using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.IEF___Interface;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.EF
{
    internal class QueryCredendital : Insert_ef, IExecution_ef
    {
        public bool QueryCredencial_EF(string Credencial)
        {
            bool validacao = false;
            try
            {
                using (var contextoQuery_credential = new MyDbContext())
                {
                    var credencialExiste = contextoQuery_credential.Tabela_Clientes.Any(x => x.Credencial_Acesso.Equals(Credencial));
                    if (credencialExiste == true)
                    {
                        validacao = true;
                    }
                    else
                    {
                        validacao = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado.\nErro: {ex.Message}");
                Program.Main(ref_args);
            }
                return validacao;
        }
    }
}
