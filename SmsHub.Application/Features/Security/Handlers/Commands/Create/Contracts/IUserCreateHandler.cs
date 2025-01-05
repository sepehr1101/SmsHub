using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts
{
    public interface IUserCreateHandler
    {
        Task Handle(UserCreateDto userCreateDto, CancellationToken cancellationToken);
    }
}