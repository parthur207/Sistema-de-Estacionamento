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
        void Delete_EF() { }

        bool QueryCredencial_EF(string Credencial) { return true; }

        void QueryNome_EF() { }

        void Update_EF() { }


    }
}
