using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageStateQueryService: IMessageStateQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageState> _messageStates;
        public MessageStateQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _messageStates = _uow.Set<MessageState>();
            _messageStates.NotNull(nameof(_messageStates));
        }
        public async Task<ICollection<MessageState>> Get()
        {
          return await _messageStates.ToListAsync();
        }
        public async Task<MessageState> Get(long id)
        {
            return await _uow.FindOrThrowAsync<MessageState>(id);
        }
    }
}
