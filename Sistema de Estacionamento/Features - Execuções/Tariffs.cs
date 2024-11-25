using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class Tariffs : FinalValue, IFeature_Parking
    {
        public void Exibition_tariffs()
        {

            double taxa_CarroCaminhao = Math.Round(GetTaxa().Item1, 2);
            double taxa_Moto = Math.Round(GetTaxa().Item2, 2);

            double valor_ex1=Math.Round(GetTaxa().Item1 * 360, 2);
            double valor_ex2= Math.Round(GetTaxa().Item2 * 360, 2);

            double valor_ex3= Math.Round(GetTaxa().Item1 * 780, 2);
            double valor_ex4= Math.Round(GetTaxa().Item2 * 780, 2);

            Console.WriteLine("\n============================================");
            Console.WriteLine("Regras tarifárias:");
            Console.WriteLine($"\n* Tarifa por minuto: A tarifa básica é de R$ {taxa_CarroCaminhao} para Carros/Caminhões e R$ {taxa_Moto} para Motos.\r\nEste valor será multiplicado pelo número total de minutos que o cliente permaneceu estacionado.");
            Console.WriteLine("\n* Tarifa fixa para períodos específicos: Se o tempo de uso total estiver entre 8 e 12 horas (equivalente a 480 e 720 minutos), o usuário pagará um valor fixo de R$ 50,00.");
            Console.WriteLine($"\n* Exemplos Práticos: \n- Exemplo 1: Se o usuário utilizar o serviço por 6 horas (360 minutos), o valor para carros/caminhões será 360 * {taxa_CarroCaminhao} = R$ {valor_ex1}. Motos o valor será de R$ 360 * {taxa_Moto} = R$ {valor_ex2}");
            Console.WriteLine("- Exemplo 2: Para um período de 30 minutos, equivalente a 0,5 hora, ou 60 minutos, equivalente a 1 hora, ");
            Console.WriteLine($"- Exemplo 3: Com 13 horas de uso (780 minutos), o valor para carros/caminhões será 780 * {taxa_CarroCaminhao} = R$ {valor_ex3}. Motos o valor será 780 * {taxa_Moto} = R$ {valor_ex4}\n g");
            
        }
    }

}
