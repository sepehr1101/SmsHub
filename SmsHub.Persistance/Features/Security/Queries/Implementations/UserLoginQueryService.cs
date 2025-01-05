using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Persistence.Features.Security.Queries.Implementations
{

    public class UserLoginQueryService : IUserLoginQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserLogin> _userLogins;
        public UserLoginQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userLogins = _uow.Set<UserLogin>();
            _userLogins.NotNull(nameof(_userLogins));
        }
        public async Task<UserLogin?> Get(Guid id)
        {
            return await _userLogins
                .Include(u => u.User)
                .SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
