using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface IReceiveManagerCreateHandler
    {
        Task<ICollection<Received>> Handle(int lineId);
    }
}
