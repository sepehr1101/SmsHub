using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Contracts
{
    public interface IConfigTypeGroupCommandService
    {
        Task Add(ConfigTypeGroup configTypeGroup);
        Task Add(ICollection<ConfigTypeGroup> configTypeGroups);
        void Delete(ConfigTypeGroup configTypeGroup);
    }
}
