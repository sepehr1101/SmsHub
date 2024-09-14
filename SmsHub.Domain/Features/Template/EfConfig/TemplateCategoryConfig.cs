using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
