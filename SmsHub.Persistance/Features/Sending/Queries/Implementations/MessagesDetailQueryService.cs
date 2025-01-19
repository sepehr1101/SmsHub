using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessagesDetailQueryService: IMessagesDetailQueryService
    {

        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessagesDetail> _messagesDetails;
        public MessagesDetailQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _messagesDetails = _uow.Set<MessagesDetail>();
            _messagesDetails.NotNull(nameof(_messagesDetails));
        }
        public async Task<ICollection<MessagesDetail>> Get()
        {
            return await _messagesDetails.ToListAsync();
        }
        public async Task<MessagesDetail> Get(long id)
        {
            return await _uow.FindOrThrowAsync<MessagesDetail>(id);
        }
        public async Task<ICollection<MobileText>> GetMobileTextList(Guid messageHolderId)
        {
            var mobileTexts = await _messagesDetails
                .Where(m => m.MessagesHolderId == messageHolderId)
                .Select(m => new MobileText()
                {
                    Mobile = m.Receptor,
                    Text = m.Text,
                    LocalId=m.Id
                })
                .ToListAsync();
            return mobileTexts;
        }
    }
}
