using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class CcSendConfig : IEntityTypeConfiguration<CcSend>
    {
        public void Configure(EntityTypeBuilder<CcSend> entity)
        {
            entity.Property(e => e.Mobile)
                  .HasMaxLength(11)
                  .IsUnicode(false)
                  .IsFixedLength();

            entity.HasOne(d => d.ConfigTypeGroup)
                .WithMany(p => p.CcSends)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_CcSend_Id");
        }
    }
}
