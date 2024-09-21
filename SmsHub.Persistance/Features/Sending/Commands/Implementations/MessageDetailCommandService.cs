using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageDetailCommandService: IMessageDetailCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessagesDetail> _messagesDetails;
        public MessageDetailCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messagesDetails=_uow.Set<Entities.MessagesDetail>();
        }
        public async Task Add(Entities.MessagesDetail messageDetail)
        {
            await _messagesDetails.AddAsync(messageDetail);
        }
        public async Task Add(ICollection<Entities.MessagesDetail> messagesDetails)
        {
            await _messagesDetails.AddRangeAsync(messagesDetails);
        }
    }
}
