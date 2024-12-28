using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ContactConfig : IEntityTypeConfiguration<Entities.Contact>
    {
        public void Configure(EntityTypeBuilder<Entities.Contact> entity)
        {
            entity.HasIndex(e => e.Title, "IX_Unique_Contact_Title")
                  .IsUnique();

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
