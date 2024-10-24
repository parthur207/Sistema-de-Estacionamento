using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    [Table("Clientes")]
    internal class AtributesClient : AtributesVehicle
    {
        public static string[] ref_args { get; private set; }//Parâmetro de referência ao método Main

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

        [Column("Estacionado")]
        public bool Estacionado { get; set; }
    }
}
