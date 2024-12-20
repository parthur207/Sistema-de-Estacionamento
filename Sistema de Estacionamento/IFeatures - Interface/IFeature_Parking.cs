﻿using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.IFeatures
{
    internal interface IFeature_Parking
    {
        TimeSpan Period_CheckOut(DateTime Entrada, DateTime Saida)
        {
          
            return TimeSpan.MaxValue;
        }

        (bool, int) Validation_Venancies(int id) { return (true, int.MaxValue); }

        string CredentialRadom() { return string.Empty; }

        double Pagamento(TimeSpan Periodo) { return 0; }

        void Vacancy_check() { }

        void Exibition_tariffs() { }

        void NumberVehicles() { }

        void AveragePeriod() { }

        void Income() { }
    }
}
