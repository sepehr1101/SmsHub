using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Common.UseragentLog;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Implementations
{
    public class UserSeeder : IDataSeeder
    {
        public int Order { get; set; } = 21;

        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;
        public UserSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<User>();
            _users.NotNull(nameof(_users));
        }
        public async void SeedData()
        {
            if (!_users.Any())
            {
                var userId = Guid.NewGuid();
                var programmer = new User()
                {
                    Id = userId,
                    InsertLogInfo = LogInfoJson.Get(),
                    InvalidLoginAttemptCount = 0,
                    Mobile = "09135742556",
                    ValidFrom = DateTime.Now,
                    SerialNumber = Guid.NewGuid().ToString("n"),
                    UserRoles = CreateUserRoles(userId),
                    DisplayName = "راهبر یک",
                    FullName = "test",
                    HasTwoStepVerification = false,
                    MobileConfirmed = true,
                    Password = await SecurityOperations.GetSha512Hash("q123456"),
                    Username="admin"                    
                };
                _users.Add(programmer);
                _uow.SaveChanges();
            }
        }
        private ICollection<UserRole> CreateUserRoles(Guid userId)
        {
            var userRoles= new List<UserRole>
            {
                new UserRole() { UserId = userId, RoleId = 3, ValidFrom = DateTime.Now, InsertLogInfo = LogInfoJson.Get() }
            };
            return userRoles;
        }
    }
}