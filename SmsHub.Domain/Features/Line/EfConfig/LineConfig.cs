using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmsHub.Domain.Features.EfConfig
{
    public class LineConfig : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> entity)
        {
            entity.HasIndex(e => e.Number, "IX_Unique_Line_Number")
                   .IsUnique();

            entity.Property(e => e.Number).HasMaxLength(15);

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.Lines)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
