using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageStateCommandService: IMessageStateCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageState> _messageStates;
        public MessageStateCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messageStates=_uow.Set<MessageState>();
        }
        public async Task Add(MessageState messageState)
        {
            await _messageStates.AddAsync(messageState);
        }
        public async Task Add(ICollection<MessageState> messageStates)
        {
            await _messageStates.AddRangeAsync(messageStates);
        }
        public void Delete(MessageState messageState)
        {
            _messageStates.Remove(messageState);
        }
    }
}
