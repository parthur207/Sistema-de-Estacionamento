using SistemaDeEstacionamento.IFeatures_Interface;

namespace SistemaDeEstacionamento.Features_Execucoes
{
    internal class Period_CheckOut_ : RandomCredential, IFeature_Parking
    {
        public TimeSpan Period_CheckOut(DateTime Inicio, DateTime Final)
        {
            TimeSpan Periodo_Estacionamento = Final - Inicio;
            return Periodo_Estacionamento;
        }
    }
}
