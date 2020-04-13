using AcaiLegal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcaiLegal.Infra.Data.Mapping
{
    public class PedidoAdicionalMap : IEntityTypeConfiguration<PedidoAdicional>
    {
        public void Configure(EntityTypeBuilder<PedidoAdicional> builder)
        {
            builder
                .HasKey(pa => new { pa.PedidoId, pa.AdicionalId });
                
            builder
                .HasOne(pa => pa.Pedido)
                .WithMany(p => p.Adicionais)
                .HasForeignKey(pa => pa.PedidoId);
        }
    }
}