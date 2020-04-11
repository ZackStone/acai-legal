using AcaiLegal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcaiLegal.Infra.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {                
            builder
                .HasMany(p => p.Adicionais)
                .WithOne(pa => pa.Pedido)
                .HasForeignKey(pa => pa.PedidoId);
        }
    }
}