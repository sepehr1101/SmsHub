using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class RoleGetAllHandler : IRoleGetAllHandler
    {
        private readonly IMapper _mapper;
        private readonly IRoleQueryService _roleQueryService;
        public RoleGetAllHandler(
            IMapper mapper,
            IRoleQueryService roleQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _roleQueryService = roleQueryService;
            _roleQueryService.NotNull(nameof(roleQueryService));
        }
        public async Task<ICollection<GetRoleDto>> Handle()
        {
            var roles = await _roleQueryService.Get();
            var getRoleDto=_mapper.Map<ICollection<GetRoleDto>>(roles);

            return getRoleDto;
        }
    }
}
