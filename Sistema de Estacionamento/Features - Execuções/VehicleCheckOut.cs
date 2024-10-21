using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class VehicleCheckOut : StorageClient, IFeature_Parking
    {
        protected TimeSpan PeriodoEstadia { get; private set; }
        public TimeSpan CheckOut(DateTime Inicio, DateTime Final)
        {
            return PeriodoEstadia;
        }
    }
}
