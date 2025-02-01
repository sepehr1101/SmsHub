using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Queries.Implementations
{
    public class CheckRoleByCollectionIdHandler : ICheckRoleByCollectionIdHandler
    {
        private readonly IRoleQueryService _roleQueryService;
        public CheckRoleByCollectionIdHandler(IRoleQueryService roleQueryService)
        {
             _roleQueryService= roleQueryService;
            _roleQueryService.NotNull(nameof(roleQueryService));
        }
        public async Task<int> Handle(ICollection<int> roleIds)
        {
            var roleCount=await _roleQueryService.CheckRole(roleIds);
            return roleCount;
        }
    }
}
