using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessagesDetailQueryService
    {
        Task<ICollection<MessagesDetail>> Get();
        Task<MessagesDetail> Get(long id);
        Task<ICollection<MobileText>> GetMobileTextList(Guid messageHolderId);
    }
}
