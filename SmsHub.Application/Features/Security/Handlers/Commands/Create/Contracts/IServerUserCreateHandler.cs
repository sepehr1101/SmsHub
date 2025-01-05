using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts
{
    public interface IServerUserCreateHandler
    {
        Task<ApiKeyAndHash> Handle(CreateServerUserDto request, CancellationToken cancellationToken);
    }
}