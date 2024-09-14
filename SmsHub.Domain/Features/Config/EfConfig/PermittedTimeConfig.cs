using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class PermittedTimeConfig : IEntityTypeConfiguration<PermittedTime>
    {
        public void Configure(EntityTypeBuilder<PermittedTime> builder)
        {
            throw new NotImplementedException();
        }
    }
}
