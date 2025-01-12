using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class LogoutReasonSeeder : IDataSeeder
    {
        public int Order { get; set; } = 8;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<LogoutReason> _logoutReasons;
        public LogoutReasonSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _logoutReasons = _uow.Set<LogoutReason>();
            _logoutReasons.NotNull(nameof(_logoutReasons));
        }

        public void SeedData()
        {
            if (!_logoutReasons.Any())
            {
                var ByUser = new LogoutReason()
                {
                    Id = LogoutReasonEnum.ByUser,
                    Title = MessageResources.ByAdmin
                };
                var ByAdmin = new LogoutReason()
                {
                    Id = LogoutReasonEnum.ByAdmin,
                    Title = MessageResources.ByAdmin
                };
                var ChangePassword = new LogoutReason()
                {
                    Id = LogoutReasonEnum.ChangePasswordByUser,
                    Title = MessageResources.ChangePasswordByUser
                };
                var EditByAdmin = new LogoutReason()
                {
                    Id = LogoutReasonEnum.EditByAdmin,
                    Title = MessageResources.EditByAdmin
                };
                var ExpireToken = new LogoutReason()
                {
                    Id = LogoutReasonEnum.ExpireToken,
                    Title = MessageResources.ExpireToken
                };
                var ChangeIpInSession = new LogoutReason()
                {
                    Id = LogoutReasonEnum.ChangeIpInSession,
                    Title = MessageResources.ChangeIpInThisSession
                };
                var ChangeWebClientSpecification = new LogoutReason()
                {
                    Id = LogoutReasonEnum.ChangeWebClientSpecification,
                    Title = MessageResources.ChangeWebClientSpecifications
                };
                var LoginAtTheSameTime = new LogoutReason()
                {
                    Id = LogoutReasonEnum.LoginAtSameTime,
                    Title = MessageResources.LoginAtSameTime
                };

                var logoutReasons = new LogoutReason[]
                {
                    ByUser,
                    ByAdmin,
                    ChangePassword,
                    EditByAdmin,
                    ExpireToken,
                    ChangeIpInSession,
                    ChangeWebClientSpecification,
                    LoginAtTheSameTime
                };

                _logoutReasons.AddRange(logoutReasons);
                _uow.SaveChanges();
            }
        }
    }
}
