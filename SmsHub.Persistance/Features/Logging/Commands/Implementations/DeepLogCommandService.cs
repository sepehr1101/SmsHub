using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class DeepLogCommandService: IDeepLogCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<DeepLog> _deepLog;
        public DeepLogCommandService(IUnitOfWork uow)
        {
            _uow= uow;
            _deepLog = _uow.Set<DeepLog>();
        }
        public async Task Add(DeepLog deepLog)
        {
            await _deepLog.AddAsync(deepLog);
        }
        public async Task Add(ICollection<DeepLog> deepLogs)
        {
            await _deepLog.AddRangeAsync(deepLogs);
        }
        public void Delete(DeepLog deepLog)
        {
            _deepLog.Remove(deepLog);
        }
    }
}
