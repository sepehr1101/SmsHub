using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;

namespace SmsHub.Persistence.Features.Consumer.Commands.Implementations
{
    public class ConsumerSafeIpCommandService: IConsumerSafeIpCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConsumerSafeIp> _consumerSafeIps;
        public ConsumerSafeIpCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _consumerSafeIps = _uow.Set<ConsumerSafeIp>();
        }

        public async Task Add(ConsumerSafeIp consumerSafeIp)
        {
            await _consumerSafeIps.AddAsync(consumerSafeIp);
        }
        public async Task Add(ICollection<ConsumerSafeIp> consumerSafeIps)
        {
            await _consumerSafeIps.AddRangeAsync(consumerSafeIps);
        }
        public void Delete(ConsumerSafeIp consumerSafeIp)
        {
            _consumerSafeIps.Remove(consumerSafeIp);
        }
    }
}
