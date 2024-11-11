using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class Tariffs : FinalValue , IFeature_Parking
    {
        public void Exibition_tariffs() 
        {
            Console.WriteLine("============================================");
            Console.WriteLine("\nRegras tarifárias:");
            Console.WriteLine($"\n* Tarifa por minuto: A tarifa básica é de R$ {GetPreco()} por minuto.\r\nEste valor será multiplicado pelo número total de minutos que o cliente permaneceu estacionado.");
            Console.WriteLine("\n*Tarifa Fixa para Períodos Específicos: Se o tempo de uso total estiver entre 8 e 12 horas (equivalente a 480 a 720 minutos), o usuário paga um valor fixo de R$ 50,00.");
            Console.WriteLine("* Exemplos Práticos: \n- Exemplo 1: Se o usuário utilizar o serviço por 6 horas (360 minutos), o valor será 360 * 0,10 = R$ 36,00.");
            Console.WriteLine("- Exemplo 2: Para um período de 10 horas (600 minutos), o valor cobrado será fixo de R$ 50,00.");
            Console.WriteLine("- Exemplo 3: Com 13 horas de uso (780 minutos), o valor será 780 * 0,10 = R$ 78,00.");
            Console.WriteLine("============================================");
            Program.Main(ref_args);
        }
    }

}
