using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts
{
    public interface IUserUpdateHandler
    {
        Task Handle(UserUpdateDto userUpdateDto, CancellationToken cancellationToken);
    }
}