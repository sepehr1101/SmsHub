using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageStateCategoryCommandService
    {
        Task Add(MessageStateCategory messageStateCategory);
        Task Add(ICollection<MessageStateCategory> messageStateCategories);
        void Delete(MessageStateCategory messageStateCategory);
    }
}
