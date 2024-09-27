using Microsoft.EntityFrameworkCore;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Persistence.Features.Consumer.Queries.Implementations
{
    public class ConsumerLineQueryService : IConsumerLineQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConsumerLine> consumerLines;
        public ConsumerLineQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            consumerLines = _uow.Set<Entities.ConsumerLine>();
        }
        public async Task<Entities.ConsumerLine> Get(int id)
        {
            var entity = await consumerLines.FindAsync(id);
            entity.NotNull(nameof(Entities.ConsumerLine));
            return entity;
        }
        public async Task<ICollection<Entities.ConsumerLine>> Get()
        {
            var entities = await consumerLines.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ConsumerLine));
            return entities;
        }
    }
}
