using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SistemaDeEstacionamento.DataBase.Db_Context;

namespace SistemaDeEstacionamento.Atributes
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


        public void AlterarNumeroVagas(int novoNumero, int id)//Admin
        {
            string TipoVeiculo;
            using (var contexto = new MyDbContext())
            {
                var estacionamento = contexto.Estacionamento.FirstOrDefault(x => x.Id == id);

                if (estacionamento != null)
                {
                    estacionamento.NumeroVagas = novoNumero;
                    estacionamento.NumeroVagasDisp = novoNumero;
                    contexto.SaveChanges();
                    if (id == 1)
                    {
                        TipoVeiculo = "Carros/Caminhoes";
                    }
                    else
                    {
                        TipoVeiculo = "Motos";
                    }
                    Console.WriteLine($"\nNumero de vagas atualizado com sucesso. Nova capacidade para {TipoVeiculo}: {novoNumero}\n");
                }
            }
        }

        public void AlterarNumeroVagasDisponiveis(int N_vagas, int id)//Processo de Checkin e Checkout
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