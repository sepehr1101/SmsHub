using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageStateCommandService: IMessageStateCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessageState> _messageStates;
        public MessageStateCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messageStates=_uow.Set<Entities.MessageState>();
        }
        public async Task Add(Entities.MessageState messageState)
        {
            await _messageStates.AddAsync(messageState);
        }
        public async Task Add(ICollection<Entities.MessageState> messageStates)
        {
            await _messageStates.AddRangeAsync(messageStates);
        }
    }
}
