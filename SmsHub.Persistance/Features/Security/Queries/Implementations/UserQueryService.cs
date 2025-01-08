using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Persistence.Features.Security.Queries.Implementations
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;
        public UserQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<User>();
            _users.NotNull(nameof(_users));
        }
        public async Task<ICollection<User>> Get()
        {
            return await 
                _users
                .Where(u=> u.ValidTo==null)
                .ToListAsync();
        }
        public async Task<User> Get(Guid id)
        {
            return await _uow.FindOrThrowAsync<User>(id);
        }
        public async Task<User?> Get(string username)
        {
            return await _users
                .SingleOrDefaultAsync(u => u.Username == username && u.ValidTo == null);
        }
    }
}
