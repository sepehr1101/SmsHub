using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class DisallowedPhraseGroupConfig : IEntityTypeConfiguration<DisallowedPhraseGroup>
    {
        public void Configure(EntityTypeBuilder<DisallowedPhraseGroup> entity)
        {
            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
