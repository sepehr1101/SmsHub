﻿using SmsHub.Persistence.Features.Sending.Queries.Contracts;
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
        private readonly DbSet<MessageDetail> _messagesDetails;
        public MessagesDetailQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _messagesDetails = _uow.Set<MessageDetail>();
            _messagesDetails.NotNull(nameof(_messagesDetails));
        }
        public async Task<ICollection<MessageDetail>> Get()
        {
            return await _messagesDetails.ToListAsync();
        }
        public async Task<MessageDetail> Get(long id)
        {
            return await _uow.FindOrThrowAsync<MessageDetail>(id);
        }
        public async Task<MessageDetail> GetInclude(long id)
        {
            var messageDetail= await _messagesDetails
                .AsNoTracking()
                .Include(m=>m.MessagesHolder)
                .ThenInclude(m=>m.MessageBatch)
                .SingleAsync(m=>m.Id== id); 
            return messageDetail;
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
