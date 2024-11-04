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
    internal abstract class AtributesParking : MyDbContext
    {
        [Column("Id")]
        public int Id { get; set; }

        // Propriedades abstratas
        public abstract int NumeroVagas { get; set; }
        public abstract int NumeroVagasDisp { get; set; }

        public abstract void AlterarNumeroVagas(int novoNumero, MyDbContext contexto);
        public virtual void AlterarNumeroVagasDisponiveis(int N_vagas, int id)
        {
            using (var contexto = new MyDbContext())
            {
                var estacionamento = contexto.Estacionamento.FirstOrDefault(x => x.Id == id);

                if (estacionamento != null)
                {
                    
                    estacionamento.NumeroVagasDisp += N_vagas;
                    if (estacionamento.NumeroVagasDisp < 0)
                    {
                        estacionamento.NumeroVagasDisp = 0;
                      
                    }
                        contexto.SaveChanges();
                }
            }
        }
    }
}
      