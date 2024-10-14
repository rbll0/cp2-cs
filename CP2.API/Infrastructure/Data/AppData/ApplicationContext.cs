﻿using CP2.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<VendedorEntity> Vendedor { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir precisão para ComissaoPercentual e MetaMensal
            modelBuilder.Entity<VendedorEntity>()
                .Property(v => v.ComissaoPercentual)
                .HasPrecision(10, 2); // 10 dígitos no total, 2 casas decimais

            modelBuilder.Entity<VendedorEntity>()
                .Property(v => v.MetaMensal)
                .HasPrecision(12, 2); // 12 dígitos no total, 2 casas decimais

            base.OnModelCreating(modelBuilder);
        }

    }
}
