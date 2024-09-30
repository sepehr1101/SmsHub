using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Consumer.Queries.Implementations
{
    public class ConsumerSafeIpQueryService: IConsumerSafeIpQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConsumerSafeIp> _consumerSafeIps;
        public ConsumerSafeIpQueryService(IUnitOfWork uow)
        {
            _uow= uow;
            _uow.NotNull(nameof(_uow));
            
            _consumerSafeIps=_uow.Set<ConsumerSafeIp>();
            _consumerSafeIps.NotNull(nameof(_consumerSafeIps));
        }
        public async Task<ConsumerSafeIp> Get(ProviderEnum id)
        {
          return await _uow.FindOrThrowAsync<ConsumerSafeIp>(id);
        }
        public async Task<ICollection<ConsumerSafeIp>> Get()
        {
            return await _consumerSafeIps.ToListAsync();
        }
    }
}
