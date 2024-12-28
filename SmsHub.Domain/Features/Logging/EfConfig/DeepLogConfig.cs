using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Logging.EfConfig
{
    public class DeepLogConfig : IEntityTypeConfiguration<DeepLog>
    {
        public void Configure(EntityTypeBuilder<DeepLog> entity)
        {
            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.Property(e => e.Ip)
                  .HasMaxLength(64)
                  .IsUnicode(false);

            entity.Property(e => e.PrimaryDb).HasMaxLength(255);

            entity.Property(e => e.PrimaryId).HasMaxLength(63);

            entity.Property(e => e.PrimaryTable).HasMaxLength(255);

            entity.HasOne(d => d.OperationType)
                  .WithMany(p => p.DeepLogs)
                  .HasForeignKey(d => d.OperationTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_OperationType_REFERS_DeepLog_OperationTypeId");
        }
    }
}
