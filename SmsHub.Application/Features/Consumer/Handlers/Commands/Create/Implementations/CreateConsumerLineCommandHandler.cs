using AutoMapper;
using MediatR;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class CreateConsumerLineCommandHandler :/* IRequestHandler<CreateConsumerLineDto>,*/ICreateConsumerLineCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineCommandService _consumerLineCommandService;

        public CreateConsumerLineCommandHandler(IMapper mapper, IConsumerLineCommandService consumerLineCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _consumerLineCommandService = consumerLineCommandService;
            _consumerLineCommandService.NotNull(nameof(_consumerLineCommandService));
        }

        public async Task Handle(CreateConsumerLineDto request, CancellationToken cancellationToken)
        {
            var consumerLine = _mapper.Map<Entities.ConsumerLine>(request);
            await _consumerLineCommandService.Add(consumerLine);
        }
    }
}
