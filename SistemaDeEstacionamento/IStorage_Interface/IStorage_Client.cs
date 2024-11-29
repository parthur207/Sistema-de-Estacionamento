namespace SistemaDeEstacionamento.IStorage_Interface
{
    internal interface IStorage_Client
    {
        string S_Name() { return string.Empty; }
        DateTime S_CheckIn() { return DateTime.Now; }
        (DateTime,DateTime, string) S_CheckOut() { return (DateTime.Now,DateTime.Now, string.Empty); }//TUPLA
    }
}
