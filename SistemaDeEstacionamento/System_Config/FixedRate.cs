using SistemaDeEstacionamento.DataBase.Db_Context;

namespace SistemaDeEstacionamento.System_Config
{
    internal class FixedRate
    {
        public void SetTaxa(double novaTaxa)
        {
            using (var context_SetTaxa=new MyDbContext())
            {
                var TaxaAtual = context_SetTaxa.Estacionamento.FirstOrDefault();
                if (TaxaAtual != null) 
                {
                    TaxaAtual.Taxa_Minuto = novaTaxa;
                    context_SetTaxa.SaveChanges();

                    Console.WriteLine($"\nNova taxa por minuto atualizada para: {novaTaxa}");
                }
                return;
            }
        }
    }
}
