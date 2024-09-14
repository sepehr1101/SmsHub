using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    internal class MessageStateCategoryConfig : IEntityTypeConfiguration<MessageStateCategory>
    {
        public void Configure(EntityTypeBuilder<MessageStateCategory> entity)
        {
            entity.Property(e => e.Css).HasMaxLength(1023);

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.ProviderNavigation)
                .WithMany(p => p.MessageStateCategories)
                .HasForeignKey(d => d.Provider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageStateCategory_Provider_ProviderId");
        }
    }
}
