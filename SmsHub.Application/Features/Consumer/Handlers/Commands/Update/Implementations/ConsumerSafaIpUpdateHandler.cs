using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Implementations
{
    public class ConsumerSafaIpUpdateHandler : IConsumerSafaIpUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpQueryService _consumerSafeIpQueryService;
        private readonly IValidator<UpdateConsumerSafeIpDto> _validator;

        public ConsumerSafaIpUpdateHandler(
            IMapper mapper,
            IConsumerSafeIpQueryService consumerSafeIpQueryService, 
            IValidator<UpdateConsumerSafeIpDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerSafeIpQueryService = consumerSafeIpQueryService;
            _consumerSafeIpQueryService.NotNull(nameof(consumerSafeIpQueryService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(UpdateConsumerSafeIpDto updateConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateConsumerSafeIpDto, cancellationToken);

            var consumerSafeIp = await _consumerSafeIpQueryService.Get(updateConsumerSafeIpDto.Id);
            _mapper.Map(updateConsumerSafeIpDto, consumerSafeIp);
        }

        private async Task CheckValidator(UpdateConsumerSafeIpDto updateConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateConsumerSafeIpDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
