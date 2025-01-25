using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ConfigTypeGroupConfig : IEntityTypeConfiguration<ConfigTypeGroup>
    {
        public void Configure(EntityTypeBuilder<ConfigTypeGroup> entity)
        {
            entity.Property(e => e.Title).HasMaxLength(255);

        }
    }
}
