using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Contact.EfConfig
{
    public class ContactNumberCategoryConfig : IEntityTypeConfiguration<ContactNumberCategory>
    {
        public void Configure(EntityTypeBuilder<ContactNumberCategory> entity)
        {
            entity.HasIndex(e => e.Title, "IX_Unique_ContactNumberCategory_Title")
                  .IsUnique();

            entity.Property(e => e.Css).HasMaxLength(1023);

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
