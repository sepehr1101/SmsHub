using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    internal class TemplateCategoryConfig : IEntityTypeConfiguration<TemplateCategory>
    {
        public void Configure(EntityTypeBuilder<TemplateCategory> entity)
        {
            entity.Property(e => e.Description).HasMaxLength(255);

            entity.Property(e => e.Title).HasMaxLength(255);
        }
    }
}
