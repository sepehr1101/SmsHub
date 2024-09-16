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

            entity.HasOne(d => d.ConfigType)
                .WithMany(p => p.ConfigTypeGroups)
                .HasForeignKey(d => d.ConfigTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigType_REFERS_ConfigTypeGroup_Id");
        }
    }
}
