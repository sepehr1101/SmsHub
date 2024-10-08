using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ContactNumberConfig : IEntityTypeConfiguration<ContactNumber>
    {
        public void Configure(EntityTypeBuilder<ContactNumber> entity)
        {
            entity.Property(e => e.Number).HasMaxLength(255);

            entity.HasOne(d => d.ContactCategory)
                .WithMany(p => p.ContactNumbers)
                .HasForeignKey(d => d.ContactCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ContactNumberCategory)
                .WithMany(p => p.ContactNumbers)
                .HasForeignKey(d => d.ContactNumberCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
