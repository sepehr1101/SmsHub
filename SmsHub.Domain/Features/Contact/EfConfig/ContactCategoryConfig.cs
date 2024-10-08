using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ContactCategoryConfig : IEntityTypeConfiguration<ContactCategory>
    {
        public void Configure(EntityTypeBuilder<ContactCategory> entity)
        {
            entity.Property(e => e.Css).HasMaxLength(1023);

            entity.Property(e => e.Description).HasMaxLength(255);

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
