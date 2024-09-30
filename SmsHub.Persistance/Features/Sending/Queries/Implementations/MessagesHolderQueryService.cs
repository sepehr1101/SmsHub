using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessagesHolderQueryService: IMessagesHolderQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessagesHolder> _messagesHolders;
        public MessagesHolderQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _messagesHolders = _uow.Set<MessagesHolder>();
            _messagesHolders.NotNull(nameof(_messagesHolders));
        }
        public async Task<ICollection<MessagesHolder>> Get()
        {
            return await _messagesHolders.ToListAsync();
        }
        public async Task<MessagesHolder> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<MessagesHolder>(id);
        }
    }
}
