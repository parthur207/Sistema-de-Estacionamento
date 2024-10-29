using Sistema_de_Estacionamento.Atributes;
using Sistema_de_Estacionamento.DataBase.Db_Context;
using Sistema_de_Estacionamento.IFeatures;
using Sistema_de_Estacionamento.System___Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.Features___Execuções
{
    internal class QueryVenancies : CarTruck_Parking, IFeature_Parking
    {
        
        public override void ExibirNumeroVagas_Disp()
        {

            try
            {
                using (var context_vagas= new MyDbContext())
                {
                    //var Lista_Credenciais = context_credenciais.Tabela_Clientes.Select(x=>x.Credencial_Acesso).ToList();

                    var numerovagasC= context_vagas.Tabela_Veiculos.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na consulta do número de vagas disponíveis. \n Erro: {ex.Message}");
            }
        }
    }
}
