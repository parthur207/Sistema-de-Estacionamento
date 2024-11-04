using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.DataBase.EF;
using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Main;
using Sistema_de_Estacionamento.System___Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class Venancies : ValidacaoCredendital, IFeature_Parking
    { 
        public (bool, int) Validation_Venancies(int id_veiculo)
        {
            using (var contexto_vagas= new MyDbContext())
            {
                var numero = contexto_vagas.Estacionamento
                    .Where(x => x.Id == id_veiculo)
                    .Select(x => x.NumeroVagasDisp).FirstOrDefault();

                if (numero <= 0)
                {
                    return (false, 0);

                }
                else
                {
                    return (true,numero);
                }
            }
        }

        public void Vacancy_check()
        {
            var VagasCarros = Validation_Venancies(1);

            Console.WriteLine($"\nNumero de vagas disponíveis para carros {VagasCarros}.");
         
            var VagasMotos= Validation_Venancies(2);
            Console.WriteLine($"Número de vagas disponíveis para motos {VagasMotos}.");
            Program.Main(ref_args);
        }

    }
}
