using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
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
    internal class Venancies : IFeature_Parking
    { 
        public bool Validation_Venancies(int id_veiculo)
        {
            using (var contexto_vagas= new MyDbContext())
            {
                var numero = contexto_vagas.Estacionamento
                    .Where(x => x.Id == id_veiculo)
                    .Select(x => x.NumeroVagasDisp).FirstOrDefault();

                if (numero <= 0)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }
    }
}
