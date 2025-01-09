using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public sealed class UserGetAllHandler : IUserGetAllHandler
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IMapper _mapper;
        public UserGetAllHandler(
            IUserQueryService userQueryService,
            IMapper mapper)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));
        }

        public async Task<ICollection<UserQueryDto>> Handle(CancellationToken cancellationToken)
        {
            var users = await _userQueryService.Get();
            var userQueryDtos = _mapper.Map<ICollection<UserQueryDto>>(users);
            return userQueryDtos;
        }
    }
}
