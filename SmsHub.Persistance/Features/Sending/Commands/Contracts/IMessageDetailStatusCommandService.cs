using SmsHub.Domain.Features.Sending.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageDetailStatusCommandService
    {
        Task Add(MessageDetailStatus messageDetailStatus);
        Task Add(ICollection<MessageDetailStatus> messsageDetailStatuses);
        void Delete(MessageDetailStatus messageDetailStatus);
    }
}
