using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface IReceiveManagerCreateHandler
    {
        Task<ICollection<Received>> Handle(int lineId);
    }
}
