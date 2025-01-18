using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts
{
    public interface IUserLineDeleteHandler
    {
        Task Handle(DeleteUserLineDto deleteUserLineDto, CancellationToken cancellationToken);
    }
}
