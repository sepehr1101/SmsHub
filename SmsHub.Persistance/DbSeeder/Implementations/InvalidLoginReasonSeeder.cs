using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class InvalidLoginReasonSeeder : IDataSeeder
    {
        public int Order { get; set; } = 6;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<InvalidLoginReason> _invalidLoginReason;
        public InvalidLoginReasonSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _invalidLoginReason = _uow.Set<InvalidLoginReason>();
            _invalidLoginReason.NotNull(nameof(_invalidLoginReason));
        }
        public void SeedData()
        {
            if (!_invalidLoginReason.Any())
            {
                var InvalidUserName = new InvalidLoginReason()
                {
                    Title = MessageResources.InvalidUserName
                };
                var InvalidPassword = new InvalidLoginReason()
                {
                    Title = MessageResources.InvalidPassword
                };
                var InvalidTwoStepVerification = new InvalidLoginReason()
                {
                    Title = MessageResources.InvalidTwoStepVerification
                };
                var ExpireTwoStepVerification = new InvalidLoginReason()
                {
                    Title = MessageResources.ExpireTwoStepVerification
                };
                var TryingAfterLock = new InvalidLoginReason()
                {
                    Title = MessageResources.TryingAfterLock
                };
                var TryingByDesableUser = new InvalidLoginReason()
                {
                    Title = MessageResources.TryingByDesableUser
                };

                var invalidLoginReasons = new InvalidLoginReason[]
                {
                    InvalidUserName,
                    InvalidPassword,
                    InvalidTwoStepVerification,
                    ExpireTwoStepVerification,
                    TryingAfterLock,
                    TryingByDesableUser
                };

                _invalidLoginReason.AddRange(invalidLoginReasons);
                _uow.SaveChanges();
            }
        }
    }
}
