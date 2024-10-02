using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Contracts
{
    public interface IPermittedTimeCommandService
    {
        Task Add(PermittedTime permittedTime);
        Task Add(ICollection<PermittedTime> permittedTimes);
        void Delete(PermittedTime permittedTime);
    }
}
