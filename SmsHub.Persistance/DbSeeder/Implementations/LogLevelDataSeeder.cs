using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class LogLevelDataSeeder:IDataSeeder
    {
        public int Order { get; set; }
        private readonly IUnitOfWork _uow;
        private readonly DbSet<LogLevel> _loglevel;

        public LogLevelDataSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _loglevel=_uow.Set<LogLevel>();
            _loglevel.NotNull(nameof(_loglevel));
        }


        public void SeedData()
        {
            if (!_loglevel.Any())
            {
                var security = new LogLevel()
                {
                    Id=LogLevelEnum.Security,
                    Title="امنیت",
                    Css=string.Empty,
                };
                var internalOperation = new LogLevel()
                {
                    Id = LogLevelEnum.InternalOperation,
                    Title = "عملیات داخلی",
                    Css = string.Empty,
                };
                var send = new LogLevel()
                {
                    Id = LogLevelEnum.Send,
                    Title = "ارسال",
                    Css = string.Empty,
                };
                var receive = new LogLevel()
                {
                    Id = LogLevelEnum.Receive,
                    Title = "دریافت",
                    Css = string.Empty,
                };

                var loglevels= new LogLevel[] {  security, internalOperation, send, receive };
                _loglevel.AddRange(loglevels);

                _uow.SaveChanges();
            }
        }
    }
}
