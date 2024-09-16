using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class DisallowedPhraseConfig : IEntityTypeConfiguration<DisallowedPhrase>
    {
        public void Configure(EntityTypeBuilder<DisallowedPhrase> entity)
        {
            entity.Property(e => e.Phrase).HasMaxLength(255);

            entity.HasOne(d => d.ConfigTypeGroup)
                .WithMany(p => p.DisallowedPhrases)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_DisallowedPhrase_Id");
        }
    }
}
