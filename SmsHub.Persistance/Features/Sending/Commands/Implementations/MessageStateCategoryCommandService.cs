using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageStateCategoryCommandService: IMessageStateCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageStateCategory> _messageStateCategories;
        public MessageStateCategoryCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messageStateCategories=_uow.Set<MessageStateCategory>();
        }
        public async Task Add(MessageStateCategory messageStateCategory)
        {
            await _messageStateCategories.AddAsync(messageStateCategory);
        }
        public async Task Add(ICollection<MessageStateCategory> messageStateCategories)
        {
            await _messageStateCategories.AddRangeAsync(messageStateCategories);
        }
        public void Delete(MessageStateCategory messageStateCategory)
        {
            _messageStateCategories.Remove(messageStateCategory);
        }
    }
}
