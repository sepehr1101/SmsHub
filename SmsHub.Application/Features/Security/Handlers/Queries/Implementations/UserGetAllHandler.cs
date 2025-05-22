using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public sealed class UserGetAllHandler : IUserGetAllHandler
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserRoleQueryService _userRoleQueryService;
        private readonly IMapper _mapper;
        public UserGetAllHandler(
            IUserQueryService userQueryService,
            IUserRoleQueryService userRoleQueryService,
            IMapper mapper)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _userRoleQueryService = userRoleQueryService;
            _userRoleQueryService.NotNull(nameof(userRoleQueryService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));
        }

        public async Task<ICollection<UserQueryDto>> Handle(CancellationToken cancellationToken)
        {
            ICollection<User> users = await _userQueryService.Get();
            ICollection<UserQueryDto> userQueryDtos = _mapper.Map<ICollection<UserQueryDto>>(users);
            
            userQueryDtos.ForEach(async user => 
            {
                ICollection<UserRole> userRoles= await _userRoleQueryService.Get(user.Id);
                if (userRoles.Count > 0)
                {
                    userRoles.ForEach(u =>
                    {
                        user.RoleId.Add(u.RoleId);
                    });
                }
            });

            return userQueryDtos;

        }
    }
}
