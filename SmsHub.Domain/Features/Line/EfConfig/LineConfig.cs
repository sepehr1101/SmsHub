using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmsHub.Domain.Features.EfConfig
{
    public class LineConfig : IEntityTypeConfiguration<Entities.Line>
    {
        public void Configure(EntityTypeBuilder<Entities.Line> entity)
        {
            entity.HasIndex(e => e.Number, "UQ_Line_Number")
                    .IsUnique();

            entity.Property(e => e.Number).HasMaxLength(15);

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.Lines)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provider_REFERS_Line_ProviderId");
        }
    }
}
