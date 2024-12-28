using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmsHub.Domain.Features.EfConfig
{
    public class TemplateConfig : IEntityTypeConfiguration<Entities.Template>
    {
        public void Configure(EntityTypeBuilder<Entities.Template> entity)
        {

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.TemplateCategory)
                  .WithMany(p => p.Templates)
                  .HasForeignKey(d => d.TemplateCategoryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TemplateCategory_REFERS_Template_TemplateCategoryId");
        }
    }
}
