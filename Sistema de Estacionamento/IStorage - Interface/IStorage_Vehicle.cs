using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.IStorage___Interface
{
    internal interface IStorage_Vehicle
    {
        Tipo_Veiculo S_VehicleType();
        string S_VehicleName();
        string S_VehicleColor();
        string S_VehiclePlate();
    }
}
