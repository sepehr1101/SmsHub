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
            _uow.NotNull(nameof(_uow));

            _consumers = _uow.Set<Entities.Consumer>();
            _consumers.NotNull(nameof(_consumers));
        }
        public async Task<Entities.Consumer> Get(int id)
        {
            return await _uow.FindOrThrowAsync<Entities.Consumer>(id);
        }
        public async Task<ICollection<Entities.Consumer>> Get()
        {
            return await _consumers.ToListAsync();
        }
    }
}
