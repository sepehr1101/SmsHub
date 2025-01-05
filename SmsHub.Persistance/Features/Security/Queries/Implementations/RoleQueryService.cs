using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Persistence.Features.Security.Queries.Implementations
{
    public class RoleQueryService : IRoleQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Role> _roles;
        public RoleQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _roles = _uow.Set<Role>();
            _roles.NotNull(nameof(_roles));
        }

        public async Task<ICollection<Role>> Get()
        {
            return await _roles
                .ToListAsync();
        }
        public async Task<Role> Get(int id)
        {
            return await _uow.FindOrThrowAsync<Role>(id);
        }
    }
}
