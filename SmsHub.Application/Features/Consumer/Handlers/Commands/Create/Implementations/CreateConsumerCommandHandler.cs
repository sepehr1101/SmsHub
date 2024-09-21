using MediatR;
using SmsHub.Domain.Features.Consumer.PersistenceDto.Commands;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using AutoMapper;
using SmsHub.Common.Extensions;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class CreateConsumerCommandHandler : /*IRequestHandler<CreateConsumerDto>,*/ ICreateConsumerCommandHandler
    {
        private readonly IConsumerCommandService _consumerCommandService;
        private readonly IMapper _mapper;
        public CreateConsumerCommandHandler(IConsumerCommandService consumerCommandService, IMapper mapper)
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