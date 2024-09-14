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
                .IsUnicode(false);

            entity.HasOne(d => d.CcSendGroup)
                .WithMany(p => p.CcSends)
                .HasForeignKey(d => d.CcSendGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CcSend_CcSendGroup_Id");
        }
    }
}
