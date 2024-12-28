using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Logging.EfConfig
{
    public class InformativeLogConfig : IEntityTypeConfiguration<InformativeLog>
    {
        public void Configure(EntityTypeBuilder<InformativeLog> entity)
        {

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.Property(e => e.Ip)
                  .HasMaxLength(64)
                  .IsUnicode(false);
             
            entity.Property(e => e.Section).HasMaxLength(255);

            entity.Property(e => e.UserInfo).HasMaxLength(255);

            entity.HasOne(d => d.LogLevel)
                  .WithMany(p => p.InformativeLogs)
                  .HasForeignKey(d => d.LogLevelId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_LogLevel_REFERS_InformativeLog_Id");
        }
    }
}
