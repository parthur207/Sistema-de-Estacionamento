namespace SistemaDeEstacionamento.DataBase.IEF_Interface
{
    internal interface IExecution_ef
    {

        void Insert_EF() { }
        void Insert_CheckOut() { }
        void Delete_EF() { }
        bool ValidacaoCredencial_EF(string Credencial) { return true; }
        void QueryCredential_EF(string Credencial) { }
        void QueryPlate_EF(string Plate) { }

        void Query_All() { }
        void Query_parked() { }
        void Query_specific() { }

    }
}
