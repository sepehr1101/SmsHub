namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageDetailCommandService
    {
        Task Add(Domain.Features.Entities.MessagesDetail messagesDetail);
        Task Add(ICollection<Domain.Features.Entities.MessagesDetail> messagesDetails);
    }
}
