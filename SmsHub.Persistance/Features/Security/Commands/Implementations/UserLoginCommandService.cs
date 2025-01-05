using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Persistence.Features.Security.Commands.Implementations
{
    public class UserLoginCommandService : IUserLoginCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserLogin> _userLogins;
        public UserLoginCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userLogins = _uow.Set<UserLogin>();
            _userLogins.NotNull(nameof(_userLogins));
        }
        public async Task Add(UserLogin userLogin)
        {
            await _userLogins.AddAsync(userLogin);
        }
    }
}
