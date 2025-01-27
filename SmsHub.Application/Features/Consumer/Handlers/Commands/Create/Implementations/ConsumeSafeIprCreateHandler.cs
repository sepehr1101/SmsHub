using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations
{
    public class ConsumeSafeIprCreateHandler :IConsumeSafeIprCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpCommandService _consumerSafeIpCommandService;
        private readonly IValidator<CreateConsumerSafeIpDto> _validator;

        public ConsumeSafeIprCreateHandler(
            IMapper mapper, 
            IConsumerSafeIpCommandService consumerSafeIpCommandService, 
            IValidator<CreateConsumerSafeIpDto> validator)
        {
            _consumerSafeIpCommandService = consumerSafeIpCommandService;
            _consumerSafeIpCommandService.NotNull(nameof(_consumerSafeIpCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateConsumerSafeIpDto createConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createConsumerSafeIpDto, cancellationToken);

            var consumerSafeIp = _mapper.Map<Entities.ConsumerSafeIp>(createConsumerSafeIpDto);
            await _consumerSafeIpCommandService.Add(consumerSafeIp);
        }

        private async Task CheckValidator(CreateConsumerSafeIpDto createConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createConsumerSafeIpDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
