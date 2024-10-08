using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ConsumerConfig : IEntityTypeConfiguration<Entities.Consumer>
    {
        public void Configure(EntityTypeBuilder<Entities.Consumer> entity)
        {
            entity.Property(e => e.Description).HasMaxLength(1023);

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
