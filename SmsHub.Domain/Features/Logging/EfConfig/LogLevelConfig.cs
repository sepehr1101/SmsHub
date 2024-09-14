using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Logging.EfConfig
{
    public class LogLevelConfig : IEntityTypeConfiguration<LogLevel>
    {
        public void Configure(EntityTypeBuilder<LogLevel> entity)
        {

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Css).HasMaxLength(1023);

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
