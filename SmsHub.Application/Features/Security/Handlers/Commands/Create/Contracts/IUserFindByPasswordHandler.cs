using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts
{
    public interface IUserFindByPasswordHandler
    {
        Task<(User?, bool)> Handle(FirstStepLoginInput input, CancellationToken cancellationToken);
    }
}