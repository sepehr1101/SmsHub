﻿using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class ConsumeSafeIprCreateHandler :/* IRequestHandler<CreateConsumerSafeIpDto>,*/IConsumeSafeIprCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpCommandService _consumerSafeIpCommandService;
        public ConsumeSafeIprCreateHandler(IMapper mapper, IConsumerSafeIpCommandService consumerSafeIpCommandService)
        {
            _consumerSafeIpCommandService = consumerSafeIpCommandService;
            _consumerSafeIpCommandService.NotNull(nameof(_consumerSafeIpCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }
        
        public async Task Handle(CreateConsumerSafeIpDto request, CancellationToken cancellationToken)
        {
            var consumerSafeIp = _mapper.Map<Entities.ConsumerSafeIp>(request);
            await _consumerSafeIpCommandService.Add(consumerSafeIp);
        }
    }
}
