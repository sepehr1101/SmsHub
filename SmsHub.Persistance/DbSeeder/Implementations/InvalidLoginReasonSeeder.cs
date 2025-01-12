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
                    Id = InvalidLoginReasonEnum.InvalidUserName,
                    Title = MessageResources.InvalidUserName
                };
                var InvalidPassword = new InvalidLoginReason()
                {
                    Id = InvalidLoginReasonEnum.InvalidPasswor,
                    Title = MessageResources.InvalidPassword
                };
                var InvalidTwoStepVerification = new InvalidLoginReason()
                {
                    Id = InvalidLoginReasonEnum.InvalidTwoStepVerification,
                    Title = MessageResources.InvalidTwoStepVerification
                };
                var ExpireTwoStepVerification = new InvalidLoginReason()
                {
                    Id = InvalidLoginReasonEnum.ExpireTwoStepVerification,
                    Title = MessageResources.ExpireTwoStepVerification
                };
                var TryingAfterLock = new InvalidLoginReason()
                {
                    Id = InvalidLoginReasonEnum.TryingAfterLock,
                    Title = MessageResources.TryingAfterLock
                };
                var TryingByDisableUser = new InvalidLoginReason()
                {
                    Id = InvalidLoginReasonEnum.TryingByDisableUser,
                    Title = MessageResources.TryingByDisableUser
                };

                var invalidLoginReasons = new InvalidLoginReason[]
                {
                    InvalidUserName,
                    InvalidPassword,
                    InvalidTwoStepVerification,
                    ExpireTwoStepVerification,
                    TryingAfterLock,
                    TryingByDisableUser
                };

                _invalidLoginReason.AddRange(invalidLoginReasons);
                _uow.SaveChanges();
            }
        }
    }
}
