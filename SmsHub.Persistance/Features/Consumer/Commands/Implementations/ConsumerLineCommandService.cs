using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;

namespace SmsHub.Persistence.Features.Consumer.Commands.Implementations
{
    public class ConsumerLineCommandService: IConsumerLineCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ConsumerLine> _consumerLines;
        public ConsumerLineCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _consumerLines = _uow.Set<Entities.ConsumerLine>();
        }

        public async Task Add(Entities.ConsumerLine consumerLine)
        {
            await _consumerLines.AddAsync(consumerLine);
        }
        public async Task Add(ICollection<Entities.ConsumerLine> consumerLines)
        {
            await _consumerLines.AddRangeAsync(consumerLines);
        }
    }
}
