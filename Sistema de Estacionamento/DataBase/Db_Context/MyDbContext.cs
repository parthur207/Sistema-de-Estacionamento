using Microsoft.EntityFrameworkCore;
using Sistema_de_Estacionamento.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estacionamento.DataBase.Db_Context
{
    internal class MyDbContext : DbContext
    {

        public DbSet<AtributesClient> Tabela_Clientes { get; set; }

        public DbSet<AtributesVehicle> Tabela_Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=Parking;User ID=root;Password=Admin;", new MySqlServerVersion(new Version(8,0,36)));
        }

        public bool ValidarConexao()
        {
            try
            {
                // Tenta abrir a conexão com o banco de dados
                this.Database.OpenConnection();
                this.Database.CloseConnection(); // Fecha a conexão após validação
                return true; // Conexão bem-sucedida
            }
            catch (Exception ex)
            {
                // Se houver erro na conexão, captura e retorna falso
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return false;
            }
        }
    }
}
