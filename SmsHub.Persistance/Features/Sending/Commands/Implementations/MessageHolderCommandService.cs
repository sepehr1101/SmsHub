using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageHolderCommandService: IMessageHolderCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessagesHolder> _messagesHolders;
        public MessageHolderCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messagesHolders=_uow.Set<MessagesHolder>();
        }
        public async Task Add(MessagesHolder messageHolder)
        {
            await _messagesHolders.AddAsync(messageHolder);
        }
        public async Task Add(ICollection<MessagesHolder> messagesHolders)
        {
            await _messagesHolders.AddRangeAsync(messagesHolders);
        }
        public void Delete(MessagesHolder messageHolder)
        {
            _messagesHolders.Remove(messageHolder);
        }
    }
}
