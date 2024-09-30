using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts
{
    public interface ICreateServerUserHandler
    {
        Task<ApiKeyAndHash> Handle(CreateServerUserDto request, CancellationToken cancellationToken);
    }
}