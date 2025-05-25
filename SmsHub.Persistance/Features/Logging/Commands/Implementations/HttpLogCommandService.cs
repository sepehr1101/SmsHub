using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    internal sealed class HttpLogCommandService : IHttpLogCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<HttpLog> _httpLogs;
        public HttpLogCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _httpLogs = _uow.Set<HttpLog>();
            _httpLogs.NotNull(nameof(_httpLogs));
        }
        public async Task Add(HttpLog httpLog)
        {
            await _httpLogs.AddAsync(httpLog);
        }
    }
}
