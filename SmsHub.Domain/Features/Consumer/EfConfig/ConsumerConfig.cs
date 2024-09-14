using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ConsumerConfig : IEntityTypeConfiguration<Entities.Consumer>
    {
        public void Configure(EntityTypeBuilder<Entities.Consumer> entity)
        {
            //entity.ToTable("Consumer");

            entity.Property(e => e.Description).HasMaxLength(1023);

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
