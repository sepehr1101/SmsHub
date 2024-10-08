using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts
{
    public interface IProviderUpdateHandler
    {
        Task Handle(UpdateProviderDto updateProviderDto, CancellationToken cancellationToken);
    }
}