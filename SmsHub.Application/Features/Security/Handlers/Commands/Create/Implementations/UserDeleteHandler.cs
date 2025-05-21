using SmsHub.Application.Exceptions;
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
        private readonly IUserRoleQueryService _userRoleQueryService;
        private readonly IUserRoleCommandService _userRoleCommandService;
        public UserDeleteHandler(IUserCommandService userCommandService,
            IUserQueryService userQueryService,
            IUserRoleQueryService userRoleQueryService,
            IUserRoleCommandService userRoleCommandService)
        {
            _userCommandService = userCommandService;
            _userCommandService.NotNull(nameof(userCommandService));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _userRoleQueryService = userRoleQueryService;
            _userRoleQueryService.NotNull(nameof(userRoleQueryService));

            _userRoleCommandService= userRoleCommandService;
            _userRoleCommandService.NotNull(nameof(userRoleCommandService));

        }
        public async Task Handle(UserDeleteDto input, CancellationToken cancellationToken)
        {
            User user= await _userQueryService.Get(input.Id);
            if (user == null)
            {
                throw new NotFoundItemException();
            }
            ICollection<UserRole> userRoles = await _userRoleQueryService.Get(user.Id);
            if (userRoles != null)
            {
                 _userRoleCommandService.Remove(userRoles, input.RemoveLogInfo);
            }
            await _userCommandService.Remove(input.Id, input.RemoveLogInfo);
        }
    }
}
