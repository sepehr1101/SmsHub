using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts
{
    public interface IUpdateProviderHandler
    {
        Task Handle(UpdateProviderDto updateProviderDto, CancellationToken cancellationToken);
    }
}