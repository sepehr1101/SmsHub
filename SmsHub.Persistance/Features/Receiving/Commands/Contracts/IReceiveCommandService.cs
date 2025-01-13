using SmsHub.Domain.Features.Receiving.Entities;

namespace SmsHub.Persistence.Features.Receiving.Commands.Contracts
{
    public interface IReceiveCommandService
    {
        Task Add(Receive receive);
        Task Add(ICollection<Receive> receive);
    }
}
