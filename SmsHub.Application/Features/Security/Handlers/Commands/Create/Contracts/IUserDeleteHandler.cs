using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts
{
    public interface IUserDeleteHandler
    {
        Task Handle(UserDeleteDto input, CancellationToken cancellationToken);
    }
}
