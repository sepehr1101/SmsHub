using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts
{
    public interface IUserLineUpdateHandler
    {
        Task Handle(UpdateUserLineDto updateUserLineDto, CancellationToken cancellationToken);
    }
}
