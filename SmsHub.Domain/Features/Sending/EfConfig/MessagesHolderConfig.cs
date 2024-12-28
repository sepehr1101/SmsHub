using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Sending.EfConfig
{
    public class MessagesHolderConfig : IEntityTypeConfiguration<MessagesHolder>
    {
        public void Configure(EntityTypeBuilder<MessagesHolder> entity)
        {

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MessageBatch)
                  .WithMany(p => p.MessagesHolders)
                  .HasForeignKey(d => d.MessageBatchId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_MessageBatch_REFERS_MessagesHolder_MessageBatchId");
        }
    }
}
