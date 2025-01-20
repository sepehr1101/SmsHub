using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageDetailCommandService: IMessageDetailCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageDetail> _messagesDetails;
        public MessageDetailCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messagesDetails=_uow.Set<MessageDetail>();
        }
        public async Task Add(MessageDetail messageDetail)
        {
            await _messagesDetails.AddAsync(messageDetail);
        }
        public async Task Add(ICollection<MessageDetail> messagesDetails)
        {
            await _messagesDetails.AddRangeAsync(messagesDetails);
        }
        public void Delete(MessageDetail messageDetail)
        {
            _messagesDetails.Remove(messageDetail);
        }
    }
}
