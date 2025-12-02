using Barbearia23.Domain;
using Barbearia23.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace Barbearia23.Infra.Context
{
    public class BarbeariaContext : DbContext
    {
        public BarbeariaContext(DbContextOptions<BarbeariaContext> options)
          : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Barbeiro> Barbeiro { get; set; }
        public DbSet<Servico> Servico { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Agendamento>().ToTable("Agendamento");
            modelBuilder.Entity<Barbeiro>().ToTable("Barbeiro");
            modelBuilder.Entity<Servico>().ToTable("Servico");
        }
    }
}
