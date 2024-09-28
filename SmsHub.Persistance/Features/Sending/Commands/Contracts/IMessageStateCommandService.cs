using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageStateCommandService
    {
        Task Add(MessageState messageState);
        Task Add(ICollection<MessageState> messageStates);
    }
}
