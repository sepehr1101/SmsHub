using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageDetailCommandService
    {
        Task Add(MessagesDetail messagesDetail);
        Task Add(ICollection<MessagesDetail> messagesDetails);
        void Delete(MessagesDetail messagesDetail);
    }
}
