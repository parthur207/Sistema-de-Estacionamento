using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.IStorage___Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Storage
{
    internal class StorageVehicle : StorageClient, IStorage_Vehicle
    {
        public void S_VehicleType()
        {
            bool aux2 = true;
            while (aux2)
            {
                Console.WriteLine("\nInforme o tipo de veículo:");
                Console.WriteLine("\na) Caminhão");
                Console.WriteLine("b) Carro");
                Console.WriteLine("c) Moto");
                string Type_V = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(Type_V) || (Type_V != "a" || Type_V != "b" || Type_V != "c"))
                {
                    Console.WriteLine("\nInforme uma alternativa válida.");
                }
                else if (Type_V == "a")
                {
                    aux2 = false;
                    TipoVeiculo = Tipo_Veiculo.Caminhão;
                }
                else if (Type_V == "b")
                {
                    aux2 = false;
                    TipoVeiculo = Tipo_Veiculo.Carro;
                }
                else if (Type_V == "c")
                {
                    aux2 = false;
                    TipoVeiculo = Tipo_Veiculo.Moto;
                }
                //Incremento que irá colher o dado
            }
        }

        public void S_VehicleName()
        {
            bool aux3 = true;
            while (aux3)
            {
                Console.WriteLine("\nDigite o nome do veículo:");
                Nome_Veiculo = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(Nome_Veiculo))
                {
                    Console.WriteLine("\nDigite um valor diferente de nulo.");
                }
                else
                {
                    aux3 = false;
                }
                //Incremento que irá colher o dado
            }
        }

        public void S_VehicleColor()
        {
            bool aux4 = true;
            while (aux4)
            {
                Console.WriteLine("\nDigite a cor do veículo:");
                Cor = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(Cor))
                {
                    Console.WriteLine("\nEntrada inválida.");
                }
                else
                {
                    aux4 = false;
                }
                //incremento
            }
        }

        public void S_VehiclePlate()
        {
            bool aux5 = true;
            while (aux5)
            {
                Console.WriteLine("\nDigite a placa do veículo:");
                Placa = Console.ReadLine().Trim();

                //Placa padrão mercosul: ABC1D34

                for (int i = 0; i < Placa.Length; i++)
                {
                    if (!char.IsLetter(Placa[0]) || !char.IsLetter(Placa[1]) || !char.IsLetter(Placa[2]) || !char.IsNumber(Placa[3]) || !char.IsLetter(Placa[4]) || !char.IsNumber(Placa[5]) || !char.IsNumber(Placa[6]))
                    {
                        Console.WriteLine("\nA placa informada não está nos padrões mercosul. Padrão exemplo: ABC1D34");
                        break;
                    }
                    else
                    {
                        aux5 = false;
                        //incremento
                    }
                }
            }
        }
    }
}
