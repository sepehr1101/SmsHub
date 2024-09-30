using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageStateCategoryQueryService: IMessageStateCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageStateCategory> _messageStateCategories;
        public MessageStateCategoryQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _messageStateCategories = _uow.Set<MessageStateCategory>();
            _messageStateCategories.NotNull(nameof(_messageStateCategories));
        }
        public async Task<ICollection<MessageStateCategory>> Get()
        {
            return await _messageStateCategories.ToListAsync();
        }
        public async Task<MessageStateCategory> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<MessageStateCategory>(id);
        }
    }
}
