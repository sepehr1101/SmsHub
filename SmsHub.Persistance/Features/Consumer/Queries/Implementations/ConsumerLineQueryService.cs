using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Consumer.Queries.Implementations
{
    public class ConsumerLineQueryService : IConsumerLineQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ConsumerLine> _consumerLines;
        public ConsumerLineQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _consumerLines = _uow.Set<ConsumerLine>();
            _consumerLines.NotNull(nameof(_consumerLines));
        }
        public async Task<ConsumerLine> Get(int id)
        {
            return await _uow.FindOrThrowAsync<ConsumerLine>(id);
        }
        public async Task<ICollection<ConsumerLine>> Get()
        {
            return await _consumerLines.ToListAsync();
        }
    }
}
