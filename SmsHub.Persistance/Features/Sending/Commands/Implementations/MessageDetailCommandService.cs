using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageDetailCommandService: IMessageDetailCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessagesDetail> _messagesDetails;
        public MessageDetailCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messagesDetails=_uow.Set<MessagesDetail>();
        }
        public async Task Add(MessagesDetail messageDetail)
        {
            await _messagesDetails.AddAsync(messageDetail);
        }
        public async Task Add(ICollection<MessagesDetail> messagesDetails)
        {
            await _messagesDetails.AddRangeAsync(messagesDetails);
        }
        public void Delete(MessagesDetail messageDetail)
        {
            _messagesDetails.Remove(messageDetail);
        }
    }
}
