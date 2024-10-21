using Sistema_de_Estacionamento.System___Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class QueryVenancies : CarTruck_Parking, IExecution
    {
        public QueryVenancies(int numeroVagas) : base(numeroVagas) { }



    }
}
