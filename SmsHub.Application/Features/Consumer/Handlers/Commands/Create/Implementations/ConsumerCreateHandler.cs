using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using AutoMapper;
using SmsHub.Common.Extensions;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class ConsumerCreateHandler : IConsumerCreateHandler
    {
        private readonly IConsumerCommandService _consumerCommandService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateConsumerDto> _validator;
        public ConsumerCreateHandler(
            IMapper mapper,
            IConsumerCommandService consumerCommandService,
            IValidator<CreateConsumerDto> validator)
        {
            _consumerCommandService = consumerCommandService;
            _consumerCommandService.NotNull(nameof(_consumerCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(CreateConsumerDto createConsumerDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createConsumerDto, cancellationToken);

            var consumer = _mapper.Map<Entities.Consumer>(createConsumerDto);
            await _consumerCommandService.Add(consumer);
        }

        private async Task CheckValidator(CreateConsumerDto createConsumerDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createConsumerDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}