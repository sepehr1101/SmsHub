using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts
{
    public interface IServerUserDeleteHandler
    {
        Task Handle(DeleteServerUserDto deleteServerUserDto, CancellationToken cancellationToken);
    }
}
