using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class ConfigConfig : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> entity)
        {
            entity.HasOne(d => d.ConfigTypeGroup)
                   .WithMany(p => p.Configs)
                   .HasForeignKey(d => d.ConfigTypeGroupId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_ConfigTypeGroup_REFERS_Config_ConfigTypeGroupId");

            entity.HasOne(d => d.Template)
                .WithMany(p => p.Configs)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Template_REFERS_Config_TemplateId");
        }
    }
}
