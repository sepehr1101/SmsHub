using SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Delete.Implementations
{
    public class UserLineDeleteHandler : IUserLineDeleteHandler
    {
        private readonly IUserLineCommandService _userLineCommandService;
        public UserLineDeleteHandler(IUserLineCommandService userLineCommandService)
        {
            _userLineCommandService= userLineCommandService;
            _userLineCommandService.NotNull(nameof(userLineCommandService));
        }
        public async Task Handle(DeleteUserLineDto deleteUserLineDto, CancellationToken cancellationToken)
        {
             await _userLineCommandService.Delete(deleteUserLineDto.Id);
        }
    }
}
