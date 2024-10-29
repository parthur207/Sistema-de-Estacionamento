using Sistema_de_Estacionamento.DataBase.Db_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Veiculos")]
    internal class AtributesVehicle : MyDbContext
    {
        [Column("Tipo_Veiculo")]
        public Tipo_Veiculo TipoVeiculo { get; set; }

        [Column("Nome_Veiculo")]
        public string Nome_Veiculo { get; set; }

        [Column("Cor")]
        public string Cor { get; set; }

        [Column("Placa")]
        public string Placa { get; set; }

        [ForeignKey("Credencial_Acesso")]
        public string Credencial_Acesso { get; set; }
    }

    public enum Tipo_Veiculo
    {
        Caminhão=2,
        Carro=2,
        Moto=1
    }
}
