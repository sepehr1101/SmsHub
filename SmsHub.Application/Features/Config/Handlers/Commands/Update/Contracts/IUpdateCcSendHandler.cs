using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IUpdateCcSendHandler
    {
        Task Handle(UpdateCcSendDto updateCcSendDto, CancellationToken cancellationToken);
    }
}
