using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Atributes
{
    internal class AtributesVehicle
    {
        public Tipo_Veiculo TipoVeiculo { get; set; }
        public string Nome_Veiculo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }

    }
    public enum Tipo_Veiculo
    {
        Caminhão,
        Carro,
        Moto
    }
}
