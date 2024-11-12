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
        public int Id { get; set; }

        // Propriedades abstratas com associação as colunas do db
        [Column("Numero_Vagas")]
        public abstract int NumeroVagas { get; set; }

        [Column("Vagas_Disponiveis")]
        public abstract int NumeroVagasDisp { get; set; }

        [Column ("Taxa_Minuto")]
        public double Taxa_Minuto { get; set; }

        public abstract void AlterarNumeroVagas(int novoNumero);//Admin

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
                    return;
                }
            }
        }
    }
}
      