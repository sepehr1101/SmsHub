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

            entity.HasOne(d => d.DisallowedPhraseGroup)
                .WithMany(p => p.DisallowedPhrases)
                .HasForeignKey(d => d.DisallowedPhraseGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DisallowedPhrase_DisallowedPhraseGroup_Id");
        }
    }
}
