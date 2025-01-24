using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserDeleteHandler : IUserDeleteHandler
    {
        private readonly IUserCommandService _userCommandService;
        public UserDeleteHandler(IUserCommandService userCommandService)
        {
            _userCommandService=userCommandService;
            _userCommandService.NotNull(nameof(userCommandService));
        }
        public async Task Handle(UserDeleteDto input, CancellationToken cancellationToken)
        {
            await _userCommandService.Remove(input.Id, input.RemoveLogInfo);
        }
    }
}
