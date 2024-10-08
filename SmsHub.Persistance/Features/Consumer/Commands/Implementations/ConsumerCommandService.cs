using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;

namespace SmsHub.Persistence.Features.Consumer.Commands.Implementations
{
    public class ConsumerCommandService : IConsumerCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Consumer> _consumers;
        public ConsumerCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _consumers = _uow.Set<Entities.Consumer>();
        }

        public async Task Add(Entities.Consumer consumer)
        {
            await _consumers.AddAsync(consumer);
        }
        public async Task Add(ICollection<Entities.Consumer> consumers)
        {
            await _consumers.AddRangeAsync(consumers);
        }
        public void Delete(Entities.Consumer consumer)
        {
            _consumers.Remove(consumer);
        }
    }
}
