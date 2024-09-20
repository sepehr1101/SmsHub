using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageHolderCommandService: IMessageHolderCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessagesHolder> _messagesHolders;
        public MessageHolderCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messagesHolders=_uow.Set<Entities.MessagesHolder>();
        }
        public async Task Add(Entities.MessagesHolder messageHolder)
        {
            await _messagesHolders.AddAsync(messageHolder);
        }
        public async Task Add(ICollection<Entities.MessagesHolder> messagesHolders)
        {
            await _messagesHolders.AddRangeAsync(messagesHolders);
        }
    }
}
