using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Commands.Implementations
{
    public class ConsumerSafeIpCommandService: IConsumerSafeIpCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConsumerSafeIp> _consumerSafeIps;
        public ConsumerSafeIpCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _consumerSafeIps = _uow.Set<Entities.ConsumerSafeIp>();
        }

        public async Task Add(Entities.ConsumerSafeIp consumerSafeIp)
        {
            await _consumerSafeIps.AddAsync(consumerSafeIp);
        }
        public async Task Add(ICollection<Entities.ConsumerSafeIp> consumerSafeIps)
        {
            await _consumerSafeIps.AddRangeAsync(consumerSafeIps);
        }
    }
}
