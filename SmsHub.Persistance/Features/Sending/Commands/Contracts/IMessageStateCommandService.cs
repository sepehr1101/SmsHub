namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageStateCommandService
    {
        Task Add(Domain.Features.Entities.MessageState messageState);
        Task Add(ICollection<Domain.Features.Entities.MessageState> messageStates);
    }
}
