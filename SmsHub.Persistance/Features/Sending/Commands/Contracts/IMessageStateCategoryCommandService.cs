namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageStateCategoryCommandService
    {
        Task Add(Domain.Features.Entities.MessageStateCategory messageStateCategory);
        Task Add(ICollection<Domain.Features.Entities.MessageStateCategory> messageStateCategories);
    }
}
