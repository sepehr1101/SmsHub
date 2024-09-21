namespace SmsHub.Persistence.Features.Config.Commands.Create.Contracts
{
    public interface IConfigTypeCommandService
    {
        Task Add(Domain.Features.Entities.ConfigType configType);
        Task Add(ICollection<Domain.Features.Entities.ConfigType> configTypes);
    }
}
