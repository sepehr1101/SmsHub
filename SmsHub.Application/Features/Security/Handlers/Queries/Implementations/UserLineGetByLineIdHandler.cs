using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class UserLineGetByLineIdHandler : IUserLineGetByLineIdHandler
    {
        private readonly IUserLineQueryService _userLineQueryService;
        public UserLineGetByLineIdHandler(IUserLineQueryService userLineQueryService)
        {
            _userLineQueryService = userLineQueryService;
            _userLineQueryService.NotNull(nameof(userLineQueryService));
        }

        public async Task<ICollection<GetUserLineByLineIdDto>> Handle(int lineId, CancellationToken cancellationToken)
        {
            var userLines = await _userLineQueryService.GetUserLinesByLineId(lineId);
            return userLines;
        }
    }
}
