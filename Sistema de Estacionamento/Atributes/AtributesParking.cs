using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Estacionamento")]
    internal abstract class AtributesParking
    {
        [Column("Id")]
        public int Id { get; set; } // 1 ou 2
        public abstract int NumeroVagas { get; set; }
        public abstract int NumeroVagasDisp { get; set; }
    
        public virtual void AlterarNumeroVagas(int novoNumero, int id)
        {
            try 
            {
                using (var contexto_update=new MyDbContext()) 
                {
                    var Parking = contexto_update.Estacionamento.Where(x => x.Id.Equals(id)).FirstOrDefault();

                    Parking.NumeroVagas= novoNumero;

                    contexto_update.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Ocorreu um erro inesperado: \n{ex.Message}"); }
        }
        public virtual void ExibirNumeroVagas_Disp(){}
    }
}
