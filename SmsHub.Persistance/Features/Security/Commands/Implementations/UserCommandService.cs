using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Implementations
{
    public class UserCommandService : IUserCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;
        public UserCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _users = _uow.Set<User>();
            _users.NotNull(nameof(_users));
        }
        public async Task Add(User user)
        {
            await _users.AddAsync(user);
        }

        public async Task Remove(Guid userId, string logInfo)
        {
            var user = await _users.FindAsync(userId);
            user.RemoveLogInfo = logInfo;
            user.ValidTo = DateTime.Now;
        }

        public async Task Remove(User user, string logInfo)
        {
            user.RemoveLogInfo = logInfo;
            user.ValidTo = DateTime.Now;
        }
    }
}