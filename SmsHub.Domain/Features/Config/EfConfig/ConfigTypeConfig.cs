using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ConfigTypeConfig : IEntityTypeConfiguration<ConfigType>
    {
        public void Configure(EntityTypeBuilder<ConfigType> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
