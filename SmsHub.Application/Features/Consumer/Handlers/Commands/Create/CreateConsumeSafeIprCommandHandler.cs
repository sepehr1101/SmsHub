using AutoMapper;
using MediatR;
using SmsHub.Common;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create
{
    public class CreateConsumeSafeIprCommandHandler : IRequestHandler<CreateConsumerSafeIpDto>
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpCommandService _consumerSafeIpCommandService;
        public CreateConsumeSafeIprCommandHandler(IMapper mapper, IConsumerSafeIpCommandService consumerSafeIpCommandService)
        {
            _consumerSafeIpCommandService=consumerSafeIpCommandService;
            _consumerSafeIpCommandService.NotNull(nameof(_consumerSafeIpCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }

        public async Task Handle(CreateConsumerSafeIpDto request, CancellationToken cancellationToken)
        {
            var consumerSafeIp=_mapper.Map<Entities.ConsumerSafeIp>(request);
            await _consumerSafeIpCommandService.Add(consumerSafeIp);
        }
    }
}
