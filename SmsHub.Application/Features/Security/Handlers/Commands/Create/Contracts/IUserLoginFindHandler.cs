using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts
{
    public interface IUserLoginFindHandler
    {
        Task<UserLogin> Handle(SecondStepLoginInput input, CancellationToken cancellationToken);
    }
}