using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class CcSendGroupConfig : IEntityTypeConfiguration<CcSendGroup>
    {
        public void Configure(EntityTypeBuilder<CcSendGroup> entity)
        {
            entity.Property(e => e.Title)
                  .HasMaxLength(255)
                  .IsUnicode(true)
                  .IsFixedLength();
        }
    }
}
