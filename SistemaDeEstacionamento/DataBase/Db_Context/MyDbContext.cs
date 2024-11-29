﻿using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Atributes;

namespace SistemaDeEstacionamento.DataBase.Db_Context
{
    internal class MyDbContext : DbContext
    {
        public DbSet<AtributesClient> Tabela_Clientes { get; set; }

        public DbSet<AtributesVehicle> Tabela_Veiculos { get; set; }

        public DbSet<AtributesParking> Estacionamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=127.0.0.1;Port=3306;Database=SistemaEstacionamento;User ID=root;Password=123456;",
                new MySqlServerVersion(new Version(8, 0, 39))
            );
        }
        public bool ValidarConexao()
        {
            try
            {
                this.Database.OpenConnection();
                this.Database.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return false;
            }
        }
    }
}
