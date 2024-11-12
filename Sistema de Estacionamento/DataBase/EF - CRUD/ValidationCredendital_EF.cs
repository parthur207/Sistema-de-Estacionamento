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
    internal class ValidacaoCredendital : Insert_ef, IExecution_ef
    {
        public bool ValidacaoCredencial_EF(string Credencial)
        {
            bool validacao = false;
            try
            {
                using (var contextoValidacao_credential = new MyDbContext())
                {
                    var credencialExiste = contextoValidacao_credential.Tabela_Clientes.Any(x => x.Credencial_Acesso.Equals(Credencial));
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
            }
                return validacao;
        }
    }
}
