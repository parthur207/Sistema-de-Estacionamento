using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Tabela_Clientes")]
    internal class AtributesClient
    {

        [Key]
        [Column("Credencial_Acesso")]
        public string Credencial_Acesso { get; set; }

        [Column("Nome_Cliente")]
        public string Nome_Cliente { get; set; }

        [Column("Entrada")]
        public DateTime Entrada { get; set; }

        [Column("Saida")]
        public DateTime Saida { get; set; }

        [Column("Periodo")]
        public TimeSpan Periodo { get; set; }

        [Column("Valor")]
        public double Valor { get; set; }

        [Column("Estacionado")]
        public bool Estacionado { get; set; }

        [ForeignKey("Placa")]
        public string Placa { get; set; }
    }
}
