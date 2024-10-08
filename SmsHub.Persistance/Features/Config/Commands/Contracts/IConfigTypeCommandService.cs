using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Contracts
{
    public interface IConfigTypeCommandService
    {
        Task Add(ConfigType configType);
        Task Add(ICollection<ConfigType> configTypes);
        void Delete(ConfigType configType);
    }
}
