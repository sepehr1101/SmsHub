using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class UserLineGetByUserIdHandler : IUserLineGetByUserIdHandler
    {
        private readonly IUserLineQueryService _userLineQueryService;

        public UserLineGetByUserIdHandler(IUserLineQueryService userLineQueryService)
        {
            _userLineQueryService=userLineQueryService;
            _userLineQueryService.NotNull(nameof(userLineQueryService));
        }

        public async Task<ICollection<GetUserLineByUserIdDto>> Handle(Guid userId,CancellationToken cancellationToken)
        {
            var userLines = await _userLineQueryService.GetUserLinesByUserId(userId);
            return userLines;
        }
    }
}
