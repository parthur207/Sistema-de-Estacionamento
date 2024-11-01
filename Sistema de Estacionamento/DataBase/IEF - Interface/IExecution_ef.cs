using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.IEF___Interface
{
    internal interface IExecution_ef
    {

        void Insert_EF() { }
        void Insert_CheckOut() { }
        void Delete_EF() { }
        bool ValidacaoCredencial_EF(string Credencial) { return true; }
        void QueryCredential_EF(string Credencial) { }
        void QueryPlate_EF(string Plate) { }

        void Update_EF() { }


    }
}
