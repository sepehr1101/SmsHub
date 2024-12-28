using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class ConsumerLineCreateHandler :IConsumerLineCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineCommandService _consumerLineCommandService;
        private readonly IValidator<CreateConsumerLineDto> _validator;

        public ConsumerLineCreateHandler(
            IMapper mapper, 
            IConsumerLineCommandService consumerLineCommandService,
            IValidator<CreateConsumerLineDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _consumerLineCommandService = consumerLineCommandService;
            _consumerLineCommandService.NotNull(nameof(_consumerLineCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateConsumerLineDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var consumerLine = _mapper.Map<Entities.ConsumerLine>(request);
            await _consumerLineCommandService.Add(consumerLine);
        }
    }
}
