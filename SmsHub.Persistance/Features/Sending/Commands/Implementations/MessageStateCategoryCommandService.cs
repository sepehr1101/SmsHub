using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageStateCategoryCommandService: IMessageStateCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessageStateCategory> _messageStateCategories;
        public MessageStateCategoryCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messageStateCategories=_uow.Set<Entities.MessageStateCategory>();
        }
        public async Task Add(Entities.MessageStateCategory messageStateCategory)
        {
            await _messageStateCategories.AddAsync(messageStateCategory);
        }
        public async Task Add(ICollection<Entities.MessageStateCategory> messageStateCategories)
        {
            await _messageStateCategories.AddRangeAsync(messageStateCategories);
        }
    }
}
