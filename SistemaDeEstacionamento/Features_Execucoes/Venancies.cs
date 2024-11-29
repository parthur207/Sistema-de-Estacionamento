﻿using SistemaDeEstacionamento.DataBase.Db_Context;
using SistemaDeEstacionamento.IFeatures_Interface;

namespace SistemaDeEstacionamento.Features_Execucoes
{
    internal class Venancies : IFeature_Parking
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
            var VagasMotos = Validation_Venancies(2);
;            if (VagasCarros.Item1 !=false)
            {
                Console.WriteLine($"\nNumero de vagas disponíveis para carros {VagasCarros.Item2}.");
            }
            else { Console.WriteLine("\nNão há vagas disponíveis para carros/caminhões."); }
            if (VagasMotos.Item1!=false)
            {
                Console.WriteLine($"Número de vagas disponíveis para motos {VagasMotos.Item2}.\n");
            }
            else { Console.WriteLine("\nNão há vagas disponíveis para motos."); }
        }

    }
}
