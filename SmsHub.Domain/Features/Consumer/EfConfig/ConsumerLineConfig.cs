using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Consumer.EfConfig
{
    public class ConsumerLineConfig : IEntityTypeConfiguration<ConsumerLine>
    {
        public void Configure(EntityTypeBuilder<ConsumerLine> entity)
        {
            entity.HasOne(d => d.Consumer)
                  .WithMany(p => p.ConsumerLines)
                  .HasForeignKey(d => d.ConsumerId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Consumer_REFERS_ConsumerLine_ConsumerId");

            entity.HasOne(d => d.Line)
                  .WithMany(p => p.ConsumerLines)
                  .HasForeignKey(d => d.LineId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Line_REFERS_ConsumerLine_LineId");
        }
    }
}
