using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Sending.EfConfig
{
    public class MessageBatchConfig : IEntityTypeConfiguration<MessageBatch>
    {
        public void Configure(EntityTypeBuilder<MessageBatch> entity)
        {
            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Line)
                  .WithMany(p => p.MessageBatches)
                  .HasForeignKey(d => d.LineId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_MessageBatch_REFERS_Line_MessageBatchId");
          }
    }
}
