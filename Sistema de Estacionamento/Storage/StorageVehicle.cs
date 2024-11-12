using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.Features___Execuções;
using Sistema_de_Estacionamento.IStorage___Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Storage
{
    internal class StorageVehicle : Period_CheckOut_ , IStorage_Vehicle
    {
        public Tipo_Veiculo S_VehicleType()
        {
            Tipo_Veiculo tipoVeiculo=Tipo_Veiculo.Carro;
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
                    tipoVeiculo = Tipo_Veiculo.Caminhao;
                }
                else if (Type_V == "b")
                {
                    aux2 = false;
                    tipoVeiculo = Tipo_Veiculo.Carro;
                }
                else if (Type_V == "c")
                {
                    aux2 = false;
                    tipoVeiculo = Tipo_Veiculo.Moto;
                }
            }
            return tipoVeiculo;
        }

        public string S_VehicleName()
        {
            bool aux3 = true;
            string nomeVeiculo = string.Empty;
            while (aux3)
            {
                Console.WriteLine("\nDigite o nome do veículo:");
                nomeVeiculo = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(nomeVeiculo))
                {
                    Console.WriteLine("\nDigite um valor diferente de nulo.");
                }
                else
                {
                    aux3 = false;
                }
            }
            return nomeVeiculo;
        }

        public string S_VehicleColor()
        {
            string color=string.Empty;
            bool aux4 = true;
            while (aux4)
            {
                Console.WriteLine("\nDigite a cor do veículo:");
                color = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(color))
                {
                    Console.WriteLine("\nEntrada inválida.");
                }
                else
                {
                    aux4 = false;
                }
            }
            return color;
        }

        public string S_VehiclePlate()
        {
            bool aux5 = true;
            string placa = string.Empty;
            while (aux5)
            {
                Console.WriteLine("\nDigite a placa do veículo:");
                placa = Console.ReadLine().Trim();

                //Placa padrão mercosul: ABC1D23

                for (int i = 0; i < placa.Length; i++)
                {
                    if (!char.IsLetter(placa[0]) || !char.IsLetter(placa[1]) || !char.IsLetter(placa[2]) || !char.IsNumber(placa[3]) || !char.IsLetter(placa[4]) || !char.IsNumber(placa[5]) || !char.IsNumber(placa[6]))
                    {
                        Console.WriteLine("\nA placa informada não está nos padrões mercosul. Padrão exemplo: ABC1D23");
                        break;
                    }
                    else
                    {
                        aux5 = false;
                    }
                }
            }
            return placa;
        }
    }
}
