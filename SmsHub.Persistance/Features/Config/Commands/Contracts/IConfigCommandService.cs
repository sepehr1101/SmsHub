using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Contracts
{
    public interface IConfigCommandService
    {
        Task Add(Entities.Config config);
        Task Add(ICollection<Entities.Config> configs);
        void Delete(Entities.Config config);
    }
}
