using SistemaDeEstacionamento.Atributes;

namespace SistemaDeEstacionamento.IStorage_Interface
{
    internal interface IStorage_Vehicle
    {
        Tipo_Veiculo S_VehicleType();
        string S_VehicleName();
        string S_VehicleColor();
        string S_VehiclePlate();
        void Storage_Query() { }
    }
}
