using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ProviderConfig: IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> entity)
        {
            //entity.ToTable("Provider");

            entity.HasIndex(e => e.Title, "IX_Unique_Provider_Title")
                .IsUnique();

            entity.Property(e => e.BaseUri).HasMaxLength(255);

            entity.Property(e => e.DefaultPreNumber).HasMaxLength(15);

            entity.Property(e => e.FallbackBaseUri).HasMaxLength(255);

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.Property(e => e.Website).HasMaxLength(255);
        }
    }
}
