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
    [Table("Tabela_Veiculos")]
    internal class AtributesVehicle
    {
        [Column("Tipo_Veiculo")]
        public string TipoVeiculo { get; set; }

        [Column("Nome_Veiculo")]
        public string Nome_Veiculo { get; set; }

        [Column("Cor")]
        public string Cor { get; set; }

        [Key]
        [Column("Placa")]
        public string Placa { get; set; }

        [ForeignKey("Credencial_Acesso")]
        public string Credencial_Acesso { get; set; }
    }

    public enum Tipo_Veiculo
    {
        Caminhao,
        Carro,
        Moto
    }
}
