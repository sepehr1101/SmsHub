﻿using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageDetailStatusGetByProviderResponseStatusIdHandler : IMessageDetailStatusGetByProviderResponseStatusIdHandler
    {

        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;

        public MessageDetailStatusGetByProviderResponseStatusIdHandler(
            IMapper mapper,
            IMessageDetailStatusQueryService messageDetailStatusQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusQueryService = messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));
        }


        public async Task<ICollection<GetMessageDetailStatusByProviderResponseStatusIdDto>> Handle(int Id)
        {
            var messageDetailStatuses = await _messageDetailStatusQueryService.GetByStatusId(Id);
            var getMessageDetailStatuses = _mapper
                .Map<ICollection<GetMessageDetailStatusByProviderResponseStatusIdDto>>(messageDetailStatuses);

            return getMessageDetailStatuses;
        }
    }
}