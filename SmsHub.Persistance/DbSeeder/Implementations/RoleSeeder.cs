using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Implementations
{
    public class RoleSeeder : IDataSeeder
    {
        public int Order { get; set; } = 20;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Role> _roles;
        public RoleSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _roles = _uow.Set<Role>();
            _roles.NotNull(nameof(_roles));
        }

        public void SeedData()
        {
            if (!_roles.Any())
            {
                var admin = new Role()
                {
                    Title = "راهبر",
                    Name = BaseRoles.Admin
                };
                var programmer = new Role()
                {
                    Title = "برنامه نویس",
                    Name = BaseRoles.Programmer
                };
                var ai = new Role()
                {                   
                    Title = "دستیار هوشمند",
                    Name = BaseRoles.Ai
                };
                var generalUser = new Role()
                {
                    Title = "کاربر",
                    Name = BaseRoles.Ai
                };
                var roles = new Role[] { generalUser, ai, programmer, admin };
                _roles.AddRange(roles);
                _uow.SaveChanges();
            }
        }
    }
}
