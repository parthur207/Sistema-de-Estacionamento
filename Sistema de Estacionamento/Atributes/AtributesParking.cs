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
    internal abstract class AttributesParking
    {
        [Column("Id")]
        protected int Id { get; set; }
        protected abstract int NumeroVagas { get; set; }
        protected abstract int NumeroVgasDisp { get; set; }
        protected abstract Tipo_Veiculo Tipo { get;}
    
        public virtual void AlterarNumeroVagas(int novoNumero)

        {
            try 
            {
                using (var contexto_update=new MyDbContext()) 
                { 
                var Contexto_Parking=contexto_update.Database
                }
            }
            catch (Exception ex) { Console.WriteLine($"Ocorreu um erro inesperado: \n{ex.Message}"); }

        }
        public virtual void ExibirNumeroVagas_Disp()
        {
        }
    }
}
