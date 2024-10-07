using SmsHub.Domain.Features.Config.MediatorDtos;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface ICcSendUpdateHandler
    {
        Task Handle(UpdateCcSendDto updateCcSendDto, CancellationToken cancellationToken);
    }
}
