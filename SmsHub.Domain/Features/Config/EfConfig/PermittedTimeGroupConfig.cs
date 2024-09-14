using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.EfConfig
{
    public class PermittedTimeGroupConfig : IEntityTypeConfiguration<PermittedTimeGroup>
    {
        public void Configure(EntityTypeBuilder<PermittedTimeGroup> builder)
        {
            throw new NotImplementedException();
        }
    }
}
