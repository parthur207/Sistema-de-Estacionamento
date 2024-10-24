using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.IStorage___Interface
{
    internal interface IStorage_Client
    {
        string S_Name() { return string.Empty; }
        DateTime S_CheckIn() { return DateTime.Now; }
        (DateTime,DateTime, string) S_CheckOut() { return (DateTime.Now,DateTime.Now, string.Empty); }//TUPLA
    }
}
