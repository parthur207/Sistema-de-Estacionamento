using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.DataBase.IEF_Interface;

namespace SistemaDeEstacionamento.DataBase.EF_CRUD
{
    internal class ValidacaoCredendital : IExecution_ef
    {
        public bool ValidacaoCredencial_EF(string Credencial)
        {
            bool validacao = false;
            try
            {
                using (var contextoValidacao_credential = new MyDbContext())
                {
                    var credencialExiste = contextoValidacao_credential.Tabela_Clientes.Any(x => x.Credencial_Acesso.Equals(Credencial));
                    return credencialExiste;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado.\nErro: {ex.Message}");
                return false;
            }
              
        }
    }
}
