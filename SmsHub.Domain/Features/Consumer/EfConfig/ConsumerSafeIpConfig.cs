using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Consumer.EfConfig
{
    public class ConsumerSafeIpConfig : IEntityTypeConfiguration<ConsumerSafeIp>
    {
        public void Configure(EntityTypeBuilder<ConsumerSafeIp> entity)
        {
            entity.Property(e => e.FromIp).HasMaxLength(64);

            entity.Property(e => e.ToIp).HasMaxLength(64);

            entity.HasOne(d => d.Consumer)
                .WithMany(p => p.ConsumerSafeIps)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumer_REFERS_ConsumerSafeIp_ConsumerId");
        }
    }
}
