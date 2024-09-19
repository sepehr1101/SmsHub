namespace SmsHub.Persistence.Features.Config.Commands.Create.Contracts
{
    public interface IConfigTypeGroupCommandService
    {
        Task Add(Domain.Features.Entities.ConfigTypeGroup configTypeGroup);
        Task Add(ICollection<Domain.Features.Entities.ConfigTypeGroup> configTypeGroups);
    }
}
