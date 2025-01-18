using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageDetailStatusCommandService : IMessageDetailStatusCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageDetailStatus> _messageDetailStatus;
        public MessageDetailStatusCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _messageDetailStatus = _uow.Set<MessageDetailStatus>();
        }
        public async Task Add(MessageDetailStatus messageDetailStatus)
        {
            await _messageDetailStatus.AddAsync(messageDetailStatus);
        }

        public async Task Add(ICollection<MessageDetailStatus> messsageDetailStatuses)
        {
            await _messageDetailStatus.AddRangeAsync(messsageDetailStatuses);
        }

        public void Delete(MessageDetailStatus messageDetailStatus)
        {
            _messageDetailStatus.Remove(messageDetailStatus);
        }
    }
}
