using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class Period_CheckOut_ : StorageVehicle, IFeature_Parking
    {
        public TimeSpan Period_CheckOut(DateTime Inicio, DateTime Final)
        {

            TimeSpan Periodo_Estacionamento = Final - Inicio;
            return Periodo_Estacionamento;
        }
    }
}
