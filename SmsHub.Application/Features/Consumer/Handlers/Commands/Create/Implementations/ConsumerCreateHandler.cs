using MediatR;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using AutoMapper;
using SmsHub.Common.Extensions;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class ConsumerCreateHandler : /*IRequestHandler<CreateConsumerDto>,*/ IConsumerCreateHandler
    {
        private readonly IConsumerCommandService _consumerCommandService;
        private readonly IMapper _mapper;
        public ConsumerCreateHandler(IConsumerCommandService consumerCommandService, IMapper mapper)
        {
            _consumerCommandService = consumerCommandService;
            _consumerCommandService.NotNull(nameof(_consumerCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }
        public async Task Handle(CreateConsumerDto request, CancellationToken cancellationToken)
        {
            var consumer = _mapper.Map<Entities.Consumer>(request);
            await _consumerCommandService.Add(consumer);
        }
    }
}