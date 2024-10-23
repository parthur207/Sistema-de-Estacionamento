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
        protected string Credencial_Acesso { get; set; }

        [Column("Nome_Cliente")]
        protected string Nome_Cliente { get; set; }

        [Column("Entrada")]
        protected DateTime Entrada { get; set; }

        [Column("Saida")]
        protected DateTime Saida { get; set; }

        [Column("Periodo")]
        protected TimeSpan Periodo { get; set; }
    }
}
