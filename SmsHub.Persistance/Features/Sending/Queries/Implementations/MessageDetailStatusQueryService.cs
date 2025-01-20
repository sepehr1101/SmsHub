using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageDetailStatusQueryService : IMessageDetailStatusQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageDetailStatus> _messageDetailStatus;
        public MessageDetailStatusQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _messageDetailStatus = _uow.Set<MessageDetailStatus>();
        }

        public async Task<ICollection<MessageDetailStatus>> GetAll()
        {
            return await _messageDetailStatus.ToListAsync();
        }

        public async Task<MessageDetailStatus> GetById(long Id)
        {
            return await _messageDetailStatus
                .Where(m => m.Id == Id)
                .FirstAsync();
        }

        public async Task<ICollection<MessageDetailStatus>> GetByMessageDetailId(long Id)
        {
            return await _messageDetailStatus
                .Include(m => m.MessagesDetail)
                .Where(m => m.MessagesDetailId == Id)
                .ToListAsync();
        }

        public async Task<MessageDetailStatus> GetByProviderServerId(long Id)
        {
            return await _messageDetailStatus
                  .Include(m => m.MessagesDetail)
                  .Where(m => m.ProviderServerId == Id)
                  .FirstAsync();
        }
    }
}
