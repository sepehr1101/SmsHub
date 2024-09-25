using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Persistence.Features.Consumer.Queries.Implementations
{
    public class ConsumerSafeIpQueryService: IConsumerSafeIpQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConsumerSafeIp> _consumerSafeIps;
        public ConsumerSafeIpQueryService(IUnitOfWork uow)
        {
            _uow= uow;
            _consumerSafeIps=_uow.Set<Entities.ConsumerSafeIp>();
        }
        public async Task<Entities.ConsumerSafeIp> Get(int id)
        {
            var entity=await _consumerSafeIps.FindAsync(id);
            entity.NotNull(nameof(Entities.ConsumerSafeIp));
            return entity;
        }
        public async Task<ICollection<Entities.ConsumerSafeIp>> Get()
        {
            var entities = await _consumerSafeIps.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ConsumerSafeIp));
            return entities;
        }
    }
}
