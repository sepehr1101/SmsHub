using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts
{
    public interface IProviderDeleteHandler
    {
        Task Handle(DeleteProviderDto deleteProviderDto, CancellationToken cancellationToken);
    }
}