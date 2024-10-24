using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class RandomCredential : VehicleCheckOut, IFeature_Parking
    {
        public string C_Radom()
        {
            string Credencial=string.Empty;
            bool random = true;

            while (random)
            {

                Random Letter = new Random();

                for (int i = 0; i < 3; i++)
                {
                    char letraAleatoria = (char)Letter.Next(65, 91);//ASCII
                    Credencial += letraAleatoria.ToString();
                }
                Random Number = new Random();
                for (int i = 3; i < 6; i++)
                {
                    int numeroAleatorio = Number.Next(0, 10);// 0 A 9
                    Credencial += numeroAleatorio.ToString();
                }

                //Incremento de método que irá verificar se ja existe alguma credencial identica com a gerada, se sim, será realizado uma nova
                /*if ()
                {

                }
                else
                {
                    random = false;
                }*/
            }
            return Credencial;
        }
    }
}
