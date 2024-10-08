using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageHolderCommandService
    {
        Task Add(MessagesHolder messagesHolder);
        Task Add(ICollection<MessagesHolder> messagesHolders);
        void Delete(MessagesHolder messagesHolder);
    }
}
