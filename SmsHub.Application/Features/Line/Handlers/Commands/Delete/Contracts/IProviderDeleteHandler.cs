using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts
{
    public interface IProviderDeleteHandler
    {
        Task Handle(DeleteProviderDto deleteProviderDto, CancellationToken cancellationToken);
    }
}