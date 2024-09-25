using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class ServerUserDataSeeder : IDataSeeder
    {       
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ServerUser> _serverUsers;
        public ServerUserDataSeeder(IUnitOfWork uow)
        {          
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _serverUsers=_uow.Set<ServerUser>();

        }
        public int Order { get; set; } = 2;

        public void SeedData()
        {
            var admin = new ServerUser()
            {
                //11b7f4c84913a006ad3115acdfc359f6.YXNkZg==
                ApiKeyHash = @"4NDEgUAJDlgiwSRBZICGjpRlrGPxwf/MH/s2NHupmkRh8zDaQaEdbwEo8LHwPBZoB99IRp7HNw6FNvL3dM3e7g==",
                CreateDateTime = DateTime.Now,
                DeleteDateTime = null,
                IsAdmin = true,
                Username = @"administrator"
            };
            _serverUsers.Add(admin);
        }
    }
}
