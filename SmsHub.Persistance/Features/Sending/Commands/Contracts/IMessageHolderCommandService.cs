namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageHolderCommandService
    {
        Task Add(Domain.Features.Entities.MessagesHolder messagesHolder);
        Task Add(ICollection<Domain.Features.Entities.MessagesHolder> messagesHolders);
    }
}
