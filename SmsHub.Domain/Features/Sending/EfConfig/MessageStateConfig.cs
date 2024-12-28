using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    internal class MessageStateConfig : IEntityTypeConfiguration<MessageState>
    {
        public void Configure(EntityTypeBuilder<MessageState> entity)
        {
            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MessageStateCategory)
                  .WithMany(p => p.MessageStates)
                  .HasForeignKey(d => d.MessageStateCategoryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_MessageStateCategory_REFERS_MessageState_MessageStateCategoryId");

            //entity.HasOne(d => d.MessagesDetailId)
            //      .WithMany(p => p.MessageStates)
            //      .HasForeignKey(d => d.MessagesDetailId)
            //      .OnDelete(DeleteBehavior.ClientSetNull)
            //      .HasConstraintName("FK_MessagesDetail_REFERS_MessageState_MessagesDetailId");
        }
    }
}
