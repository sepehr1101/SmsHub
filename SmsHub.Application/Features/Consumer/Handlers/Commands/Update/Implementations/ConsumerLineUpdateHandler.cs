﻿using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Implementations
{
    public class ConsumerLineUpdateHandler: IConsumerLineUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineQueryService _consumerLineQueryService;
        public ConsumerLineUpdateHandler(IMapper mapper, IConsumerLineQueryService consumerLineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(Mapper));

            _consumerLineQueryService = consumerLineQueryService;
            _consumerLineQueryService.NotNull(nameof(consumerLineQueryService));
        }
        public async Task Handle(UpdateConsumerLineDto updateConsumerLineDto, CancellationToken cancellationToken)
        {
            var consumerLine = await _consumerLineQueryService.Get(updateConsumerLineDto.Id);
            _mapper.Map(updateConsumerLineDto, consumerLine);
        }

    }
}
