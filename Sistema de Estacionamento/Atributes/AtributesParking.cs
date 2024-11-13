using Sistema_de_Estacionamento.DataBase.Db_Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Estacionamento")]
    internal class AtributesParking
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Numero_Vagas")]
        public int NumeroVagas { get; set; }

        [Column("Vagas_Disponiveis")]
        public int NumeroVagasDisp { get; set; }

        [Column("Taxa_Minuto")]
        public double Taxa_Minuto { get; set; }


        public void AlterarNumeroVagas(int novoNumero, int Id)
        {
            using (var contexto = new MyDbContext())
            {
                var estacionamento = contexto.Estacionamento.FirstOrDefault(x => x.Id == this.Id);

                if (estacionamento != null)
                {
                    estacionamento.NumeroVagas = novoNumero;
                    estacionamento.NumeroVagasDisp = novoNumero;
                    contexto.SaveChanges();
                    Console.WriteLine($"Numero de vagas atualizado com sucesso. Nova capacidade: {novoNumero}");
                }
            }
        }

        public void AlterarNumeroVagasDisponiveis(int N_vagas, int Id)
        {
            using (var contexto = new MyDbContext())
            {
                var estacionamento = contexto.Estacionamento.FirstOrDefault(x => x.Id == this.Id);

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