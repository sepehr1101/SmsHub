using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using FluentValidation;

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

        public async Task Handle(CreateConsumerSafeIpDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var consumerSafeIp = _mapper.Map<Entities.ConsumerSafeIp>(request);
            await _consumerSafeIpCommandService.Add(consumerSafeIp);
        }
    }
}
