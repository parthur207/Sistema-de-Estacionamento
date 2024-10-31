using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.System___Config
{
    internal class CarTruck_Parking : AtributesParking
    {
        [Column("Numero_Vagas_C")]
        private int _numeroVagasCarros;
        [Column("Vagas_Disponíveis_C")]
        private int _numeroVagasDisponiveisCarros;

        public override int NumeroVagas
        {
            get => _numeroVagasCarros;
            set => _numeroVagasCarros = value;
        }

        public override int NumeroVagasDisp
        {
            get => _numeroVagasDisponiveisCarros;
            set => _numeroVagasDisponiveisCarros = value;
        }

        public override void AlterarNumeroVagasDisponiveis(int N_vagas, int id) { }//Atribuição de valores incrementando ou decrementando na varaivel de vagas disponíveis

        
        public override void AlterarNumeroVagas(int novoNumero, MyDbContext contexto)//Admin
        {
            var estacionamento = contexto.Estacionamento.FirstOrDefault(x => x.Id == this.Id);
            if (estacionamento != null)
            {
                estacionamento.NumeroVagas = novoNumero;
                contexto.SaveChanges();
            }
        }
    }
}

