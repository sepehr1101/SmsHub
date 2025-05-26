using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    internal sealed class HttpLogQueryService : IHttpLogQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<HttpLog> _httpLogs;
        public HttpLogQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _httpLogs = _uow.Set<HttpLog>();
            _httpLogs.NotNull(nameof(_httpLogs));
        }

        public async Task<HttpLog?> Get(long id)
        {
            HttpLog? httpLog = await _httpLogs.FindAsync(id);
            return httpLog;
        }
    }
}
