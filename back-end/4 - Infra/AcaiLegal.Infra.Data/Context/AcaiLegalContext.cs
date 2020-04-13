using AcaiLegal.Domain.Entities;
using AcaiLegal.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AcaiLegal.Infra.Data.Context
{
    public class AcaiLegalContext : DbContext
    {
        public DbSet<Tamanho> Tamanho { get; set; }

        public DbSet<Sabor> Sabor { get; set; }

        public DbSet<Adicional> Adicional { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<PedidoAdicional> PedidoAdicional { get; set; }

        public AcaiLegalContext(DbContextOptions<AcaiLegalContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PedidoAdicional>(new PedidoAdicionalMap().Configure);
            modelBuilder.Entity<Pedido>(new PedidoMap().Configure);
        }
    }
}