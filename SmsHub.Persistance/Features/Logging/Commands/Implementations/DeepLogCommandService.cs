using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class DeepLogCommandService: IDeepLogCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.DeepLog> _deepLog;
        public DeepLogCommandService(IUnitOfWork uow)
        {
            _uow= uow;
            _deepLog = _uow.Set<Entities.DeepLog>();
        }
        public async Task Add(Entities.DeepLog deepLog)
        {
            await _deepLog.AddAsync(deepLog);
        }
        public async Task Add(ICollection<Entities.DeepLog> deepLogs)
        {
            await _deepLog.AddRangeAsync(deepLogs);
        }
    }
}
