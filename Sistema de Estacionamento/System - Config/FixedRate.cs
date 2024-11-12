using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
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
