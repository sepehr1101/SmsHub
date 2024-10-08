using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class PermittedTimeConfig : IEntityTypeConfiguration<PermittedTime>
    {
        public void Configure(EntityTypeBuilder<PermittedTime> entity)
        {
            entity.Property(e => e.FromTime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

            entity.Property(e => e.ToTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ConfigTypeGroup)
                .WithMany(p => p.PermittedTimes)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_PermittedTime_ConfigTypeGroupId");
        }
    }
}
