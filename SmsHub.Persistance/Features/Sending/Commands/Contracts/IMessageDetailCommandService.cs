using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageDetailCommandService
    {
        Task Add(MessageDetail messagesDetail);
        Task Add(ICollection<MessageDetail> messagesDetails);
        void Delete(MessageDetail messagesDetail);
    }
}
