using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Implementations
{
    public class RoleCommandService : IRoleCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Role> _roles;
        public RoleCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _roles = _uow.Set<Role>();
            _roles.NotNull(nameof(_roles));
        }
        public async Task Add(Role role)
        {
            await _roles.AddAsync(role);
        }
    }
}