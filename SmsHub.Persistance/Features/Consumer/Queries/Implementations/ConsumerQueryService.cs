using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Queries.Implementations
{
    internal class ConsumerQueryService:IConsumerQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Consumer> _consumers;
        public ConsumerQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _consumers = _uow.Set<Entities.Consumer>();
        }
        public async Task<Entities.Consumer> Get(int id)
        {
            var entity = await _consumers.FindAsync(id);
            entity.NotNull(nameof(Entities.Consumer));
            return entity;
        }
        public async Task<ICollection<Entities.Consumer>> Get()
        {
            var entities = await _consumers.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.Consumer));
            return entities;
        }
    }
}
