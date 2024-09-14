using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class MessageDetailConfig : IEntityTypeConfiguration<MessagesDetail>
    {
        public void Configure(EntityTypeBuilder<MessagesDetail> entity)
        {
            entity.Property(e => e.Receptor).HasMaxLength(15);

            entity.Property(e => e.SendDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MessagesHolder)
                .WithMany(p => p.MessagesDetails)
                .HasForeignKey(d => d.MessagesHolderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
