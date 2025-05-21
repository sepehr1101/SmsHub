using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserDeleteHandler : IUserDeleteHandler
    {
        private readonly IUserCommandService _userCommandService;
        private readonly IUserQueryService _userQueryService;
        public UserDeleteHandler(IUserCommandService userCommandService,
            IUserQueryService userQueryService)
        {
            _userCommandService = userCommandService;
            _userCommandService.NotNull(nameof(userCommandService));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

        }
        public async Task Handle(UserDeleteDto input, CancellationToken cancellationToken)
        {
            User user = await _userQueryService.Get(input.Id);
            await _userCommandService.Remove(input.Id, input.RemoveLogInfo);
        }
    }
}
