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
    internal class QueryVenancies_Disp : CarTruck_Parking, IFeature_Parking
    {
        
        public override void Numero_Vagas_Disp()
        {

            try
            {
                using (var context_vagas= new MyDbContext())
                {
                    

                    //Lista das credenciais que o carro ainda está estacionado
                    var List_credencial_true = context_vagas.Tabela_Clientes
                        .Where(x=>x.Estacionado.Equals(true))
                        .Select(x=>x.Credencial_Acesso)
                        .ToList();

                    //Numero de credenciais de motos estacionadas
                    foreach (var credencial in List_credencial_true) {
                        var VagasDisp_M = context_vagas.Tabela_Veiculos
                            .Where(x => x.Credencial_Acesso.Equals(credencial))
                            .Count(x=>x.TipoVeiculo.Equals("Moto"));
                    }
                    //Numero de credenciais de carros,ou caminhoes estacionadas
                    foreach (var credencial_ in List_credencial_true)
                    {
                        var VagasDisp_C = context_vagas.Tabela_Veiculos
                            .Where(x => x.Credencial_Acesso.Equals(credencial_))
                            .Count(x => x.TipoVeiculo.Equals("Carro") || x.TipoVeiculo.Equals("Caminhao"));
                    }

                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na consulta do número de vagas disponíveis. \n Erro: {ex.Message}");
            }
        }
    }
}
