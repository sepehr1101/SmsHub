using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Implementations
{
    public class UserRoleCommandService : IUserRoleCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserRole> _userRoles;
        public UserRoleCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userRoles = _uow.Set<UserRole>();
            _userRoles.NotNull(nameof(_userRoles));
        }

        public async Task Add(ICollection<UserRole> userRoles)
        {
            await _userRoles.AddRangeAsync(userRoles);
        }

        public void Remove(ICollection<UserRole> userRoles, string logInfo)
        {
            Guid operationGroupId = Guid.NewGuid();
            userRoles.ForEach(userRole => Remove(userRole, logInfo, operationGroupId));
        }
        private void Remove(UserRole userRole, string logInfo, Guid operationGroupId)
        {
            userRole.RemoveLogInfo = logInfo;
            userRole.RemoveGroupId = operationGroupId;
            userRole.ValidTo = DateTime.Now;
        }
    }
}