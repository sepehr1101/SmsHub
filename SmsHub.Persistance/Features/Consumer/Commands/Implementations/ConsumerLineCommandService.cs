using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Commands.Implementations
{
    public class ConsumerLineCommandService : IConsumerLineCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConsumerLine> _consumerLines;
        public ConsumerLineCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _consumerLines = _uow.Set<ConsumerLine>();
        }

        public async Task Add(ConsumerLine consumerLine)
        {
            await _consumerLines.AddAsync(consumerLine);
        }
        public async Task Add(ICollection<ConsumerLine> consumerLines)
        {
            await _consumerLines.AddRangeAsync(consumerLines);
        }
        public void Delete(ConsumerLine consumerLine)
        {
            _consumerLines.Remove(consumerLine);
        }
    }
}
